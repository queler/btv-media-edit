/****************************************************************************
 * 
 * File:  BTVMediaEdit.cs
 * 
 * Copyright (C) 2009  Brett Gronholz
 * 
 * This file is part of BTV Media Edit.
 * 
 * BTV Media Edit is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * BTV Media Edit is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with BTV Media Edit.  If not, see <http://www.gnu.org/licenses/>.
 ***************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using BTVMediaEdit.Properties;

namespace BTVMediaEdit
{
    using BTVServer;
    using TvdbLib;
    using TvdbLib.Data;

    public partial class BTVMediaEdit : Form
    {
        private const int TVDB_DELAY = 1000;

        //private BTVConnect btvConnect = new BTVConnect();
        //private BTVLibrarySoapClient btvLibrary;
        public BTVConnect btvConnect = new BTVConnect();
        public BTVLibrarySoapClient btvLibrary;

        private BackgroundWorker bwLogon = new BackgroundWorker();
        private BackgroundWorker bwRefresh = new BackgroundWorker();
        private BackgroundWorker bwScanUpdate = new BackgroundWorker();
        private BackgroundWorker bwSchedule = new BackgroundWorker();

        private bool cancelSchedule = false;
        private bool cancelScanUpdate = false;

        private StreamWriter logStream;

        //###################################################################

        public BTVMediaEdit()
        {
            InitializeComponent();

            logStream = new StreamWriter(
                Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "log.txt"), true );

            bwLogon.DoWork += new DoWorkEventHandler(bwLogon_DoWork);
            bwRefresh.DoWork += new DoWorkEventHandler(bwRefresh_DoWork);
            bwScanUpdate.DoWork += new DoWorkEventHandler(bwScanUpdate_DoWork);
            bwSchedule.DoWork += new DoWorkEventHandler(bwSchedule_DoWork);

            LoadSettings();
            CheckForUnknownSeries();

            this.Text += String.Format(" {0}", Application.ProductVersion);
        }

        //###################################################################

        private void Shutdown()
        {
            SaveSettings();
            logStream.Close();
        }

        private void BTVMediaEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Shutdown();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //###################################################################

        private void BTVMediaEdit_Resize(object sender, EventArgs e)
        {
            if (WindowState.Equals(FormWindowState.Minimized))
            {
                Hide();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        //###################################################################

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Startup.IsAutoStartEnabled("BTVMediaEdit", Application.ExecutablePath))
            {
                startWithWindowsToolStripMenuItem.Checked = false;
                Startup.UnSetAutoStart("BTVMediaEdit");
            }
            else
            {
                startWithWindowsToolStripMenuItem.Checked = true;
                Startup.SetAutoStart("BTVMediaEdit", Application.ExecutablePath);
            }
        }

        private void startMinimizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startMinimizedToolStripMenuItem.Checked = !startMinimizedToolStripMenuItem.Checked;
        }

        //###################################################################

        private void LoadSettings()
        {
            string[] sServer = Settings.Default.Server.Split('|');
            if (sServer.Length.Equals(4))
            {
                txtAddress.Text = sServer[0];
                txtPort.Text = sServer[1];
                txtUser.Text = sServer[2];
                txtPassword.Text = sServer[3];
            }

            string[] mediaFolders = Settings.Default.MediaFolders.Split('|');
            foreach (string mediaFolder in mediaFolders)
            {
                if (!mediaFolder.Equals(String.Empty))
                {
                    cbMediaFolders.Items.Add(mediaFolder, true);
                }
            }

            string[] seriesMap = Settings.Default.SeriesMap.Split('|');
            foreach (string sm in seriesMap)
            {
                if (!sm.Equals(String.Empty))
                {
                    string[] sms = sm.Split('^');
                    if (sms.Length.Equals(4))
                    {
                        lstSeriesMap.Items.Add(new ListViewItem(sms));
                    }
                }
            }

            string[] misc = Settings.Default.Misc.Split('|');
            if (misc.Length.Equals(5))
            {
                nudSchedule.Value = decimal.Parse(misc[1]);
                cbSchedule.Checked = misc[0].Equals("1") ? true : false;
                cbUnknown.Checked = misc[2].Equals("1") ? true : false;
                cbAutoID.Checked = misc[3].Equals("1") ? true : false;
                if (misc[4].Equals("1"))
                {
                    WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    startMinimizedToolStripMenuItem.Checked = true;
                }
            }

            if (Startup.IsAutoStartEnabled("BTVMediaEdit", Application.ExecutablePath))
            {
                startWithWindowsToolStripMenuItem.Checked = true;
            }
        }

        private void SaveSettings()
        {
            Settings.Default.Server = String.Format("{0}|{1}|{2}|{3}",
                txtAddress.Text, txtPort.Text, txtUser.Text, txtPassword.Text);

            Settings.Default.MediaFolders = "";
            foreach (object o in cbMediaFolders.CheckedItems)
            {
                Settings.Default.MediaFolders += String.Format("{0}|", o.ToString());
            }
            Settings.Default.MediaFolders.TrimEnd('|');

            Settings.Default.SeriesMap = "";
            foreach (ListViewItem lvi in lstSeriesMap.Items)
            {
                try
                {
                    Settings.Default.SeriesMap += String.Format("{0}^{1}^{2}^{3}|",
                        lvi.SubItems[0].Text, lvi.SubItems[1].Text, 
                        lvi.SubItems[2].Text, lvi.SubItems[3].Text);
                }
                catch
                {
                }
            }
            Settings.Default.SeriesMap.TrimEnd('|');

            Settings.Default.Misc = String.Format("{0}|{1}|{2}|{3}|{4}",
                cbSchedule.Checked ? "1" : "0",
                nudSchedule.Value.ToString(),
                cbUnknown.Checked ? "1" : "0",
                cbAutoID.Checked ? "1" : "0",
                startMinimizedToolStripMenuItem.Checked ? "1" : "0");

            Settings.Default.Save();
        }

        //###################################################################

        private void Log(string s)
        {
            logStream.WriteLine(String.Format("{0}:  {1}", DateTime.Now.ToString(), s));
            logStream.Flush();
        }

        private void _CheckForUnknownSeries()
        {
            int nUnknown = 0;
            foreach (ListViewItem lvi in lstSeriesMap.Items)
            {
                if (lvi.SubItems[2].Text.Equals("Unknown"))
                {
                    nUnknown++;
                }
            }

            if (nUnknown > 0)
            {
                notifyIcon1.Icon = new Icon(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "btvMEx.ico"));
                notifyIcon1.Text = String.Format("BTV Media Edit ({0} unknown)", nUnknown);
            }
            else
            {
                notifyIcon1.Icon = new Icon(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "btvME.ico"));
                notifyIcon1.Text = String.Format("BTV Media Edit", nUnknown);
            }
        }

        private void CheckForUnknownSeries()
        {
            if (lstSeriesMap.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(delegate
                {
                    _CheckForUnknownSeries();
                }));
            }
            else
            {
                _CheckForUnknownSeries();
            }
        }

        //###################################################################
        // SERVER

        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (btnLogon.Text.Equals("Logon"))
            {
                bwLogon.RunWorkerAsync();
            }
            else
            {
                Logoff();
            }
        }

        private void bwLogon_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.Invoke(new EventHandler(delegate 
                {
                    btnLogon.Enabled = false;
                    txtAddress.Enabled = txtPort.Enabled = txtUser.Enabled = txtPassword.Enabled = false;
                    toolStripStatusLabel1.Text = "Logging on...";
                }));

                Log("-- Logging on...");

                btvConnect.Logon(txtAddress.Text, txtPort.Text, txtUser.Text, txtPassword.Text);
                btvLibrary = new BTVLibrarySoapClient("BTVLibrarySoap",
                    String.Format("http://{0}:{1}/wsdl/BTVLibrary.asmx", txtAddress.Text, txtPort.Text));

                this.Invoke(new EventHandler(delegate
                {
                    btnLogon.Text = "Logoff";
                    toolStripStatusLabel1.Text = "Idle...";
                    btnLogon.Enabled = true;
                }));
            }
            catch (Exception ex)
            {
                this.Invoke(new EventHandler(delegate
                {
                    Log("!! " + ex.Message);
                    btnLogon.Text = "Logon";
                    toolStripStatusLabel1.Text = "Idle...";
                    txtAddress.Enabled = txtPort.Enabled = txtUser.Enabled = txtPassword.Enabled = true;
                    btnLogon.Enabled = true;
                }));
            }
        }

        private void Logoff()
        {
            Log("-- Logging off...");
            btnLogon.Enabled = false;
            btvConnect.Logoff();
            btnLogon.Text = "Logon";
            txtAddress.Enabled = txtPort.Enabled = txtUser.Enabled = txtPassword.Enabled = true;
            btnLogon.Enabled = true;
        }

        //private bool Connect()
        public bool Connect()
        {
            int logonTO = 0;
            if (!bwLogon.IsBusy)
            {
                bwLogon.RunWorkerAsync();
            }
            while (bwLogon.IsBusy)
            {
                Thread.Sleep(1000);
                if (++logonTO > 60)
                {
                    bwLogon.CancelAsync();
                    Log("!! Connect timed out.");
                    break;
                }
            }

            return btvConnect.IsConnected();
        }

        //###################################################################
        // MEDIA FOLDERS

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Log("-- Refreshing media folders...");
            bwRefresh.RunWorkerAsync();
        }

        private void bwRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                btnRefresh.Enabled = btnLogon.Enabled = btnScan.Enabled = false;
                toolStripStatusLabel1.Text = "Refreshing media folders...";
                cbMediaFolders.Items.Clear();
            }));

            if (Connect())
            {
                ArrayOfPVSPropertyBag bags = btvLibrary.GetFolders(btvConnect.AuthTicket, String.Empty);
                foreach (PVSPropertyBag bag in bags)
                {
                    foreach (PVSProperty prop in bag.Properties)
                    {
                        if (prop.Name.Equals("FullName"))
                        {
                            this.Invoke(new EventHandler(delegate { cbMediaFolders.Items.Add(prop.Value); }));
                        }
                    }
                }
            }
            else
            {
                Log("!! Error connecting for media folder refresh");
                return;
            }

            this.BeginInvoke(new EventHandler(delegate
            {
                btnRefresh.Enabled = btnLogon.Enabled = btnScan.Enabled = true;
                toolStripStatusLabel1.Text = "Idle...";
            }));
        }

        private List<string> GetEnabledMediaFolders()
        {
            List<string> ls = new List<string>();

            this.Invoke(new EventHandler(delegate
            {
                foreach (object o in cbMediaFolders.CheckedItems)
                {
                    ls.Add(o.ToString());
                }
            }));

            return ls;
        }

        //###################################################################
        // SERIES MAP

        private void EditSeriesMap()
        {
            if (lstSeriesMap.SelectedItems.Count > 0)
            {
                SeriesID sID = new SeriesID(lstSeriesMap.SelectedItems[0].SubItems[0].Text,
                                            lstSeriesMap.SelectedItems[0].SubItems[1].Text, 
                                            lstSeriesMap.SelectedItems[0].SubItems[2].Text,
                                            lstSeriesMap.SelectedItems[0].SubItems[3].Text);

                if (sID.ShowDialog().Equals(DialogResult.OK))
                {
                    lstSeriesMap.SelectedItems[0].SubItems[1].Text = sID._SeriesName;
                    lstSeriesMap.SelectedItems[0].SubItems[2].Text = sID._SeriesID.Equals(String.Empty)
                                                                        ? "Unknown" : sID._SeriesID;
                    lstSeriesMap.SelectedItems[0].SubItems[3].Text = sID._SeriesOverview;
                }
            }

            CheckForUnknownSeries();
        }

        private void lstSeriesMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = btnEdit.Enabled = (lstSeriesMap.SelectedItems.Count > 0);
        }

        private void lstSeriesMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditSeriesMap();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSeriesMap();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSeriesMap.SelectedItems.Count > 0)
            {
                lstSeriesMap.SelectedItems[0].Remove();
                CheckForUnknownSeries();
            }
        }

        private void btnClearList_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure?", "Verify", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                lstSeriesMap.Items.Clear();
                CheckForUnknownSeries();
            }
        }

        private Dictionary<string, string[]> GetSeriesMap()
        {
            Dictionary<string, string[]> sm = new Dictionary<string, string[]>();

            this.Invoke(new EventHandler(delegate
            {
                foreach (ListViewItem lvi in lstSeriesMap.Items)
                {
                    try
                    {
                        sm.Add(lvi.SubItems[0].Text, new string[] { lvi.SubItems[1].Text, lvi.SubItems[2].Text, lvi.SubItems[3].Text });
                    }
                    catch
                    {
                        sm.Add(lvi.SubItems[0].Text, new string[] { String.Empty, "Unknown", String.Empty });
                    }
                }
            }));

            return sm;
        }

        //###################################################################

        private void bwScanUpdate_DoWork(object sender, DoWorkEventArgs ev)
        {
            this.BeginInvoke(new EventHandler(delegate
            {
                btnLogon.Enabled = btnRefresh.Enabled = cbMediaFolders.Enabled = false;
                if (ev.Argument.Equals("Scan"))
                {
                    btnScan.Text = "Cancel";
                    btnUpdate.Enabled = false;
                    toolStripStatusLabel1.Text = "Starting scan...";
                }
                else
                {
                    btnUpdate.Text = "Cancel";
                    btnScan.Enabled = false;
                    toolStripStatusLabel1.Text = "Starting update...";
                }
            }));

            if (Connect())
            {
                Dictionary<string, string[]> seriesMap = GetSeriesMap();

#if false
                // get array of media library items
                ArrayOfPVSPropertyBag bags;
                if (cbUnknown.Checked)
                {
                    bags = btvLibrary.GetItemsBySeries(btvConnect.AuthTicket, "Unknown");
                }
                else
                {
                    bags = btvLibrary.FlatViewByTitle(btvConnect.AuthTicket);
                }
#else
                // get array of media library items
                ArrayOfPVSPropertyBag bags;
                if (cbUnknown.Checked)
                {
                    bags = btvLibrary.GetItemsBySeries(btvConnect.AuthTicket, "Unknown");
                    ArrayOfPVSPropertyBag allBags = btvLibrary.FlatViewByTitle(btvConnect.AuthTicket);
                    
                    //
                    foreach (PVSPropertyBag bag in allBags)
                    {
                        foreach (PVSProperty prop in bag.Properties)
                        {
                            if (prop.Name.Equals("EpisodeTitle"))
                            {
                                if (prop.Value.Equals("Unknown"))
                                {
                                    bags.Add(bag);
                                }
                            }
                            else if (prop.Name.Equals("EpisodeDescription"))
                            {
                                if (prop.Value.Length < 16)
                                {
                                    bags.Add(bag);
                                }
                            }
                        }
                    }
                }
                else
                {
                    bags = btvLibrary.FlatViewByTitle(btvConnect.AuthTicket);
                }
#endif

                // scan for media library items on selected paths
                List<string> fullNames = new List<string>();
                foreach (PVSPropertyBag bag in bags)
                {
                    foreach (PVSProperty prop in bag.Properties)
                    {
                        if (prop.Name.Equals("FullName"))
                        {
                            foreach (string path in GetEnabledMediaFolders())
                            {
                                if (prop.Value.ToLower().StartsWith(path.ToLower()))
                                {
                                    fullNames.Add(prop.Value);
                                }
                            }
                        }
                    }
                }

                // process media files
                int n = 1;
                foreach (string path in fullNames)
                {
                    if (cancelScanUpdate)
                    {
                        break;
                    }

                    this.BeginInvoke(new EventHandler(delegate
                    {
                        toolStripStatusLabel1.Text = 
                            String.Format("Processing ({0}/{1}): {2}", 
                                            n, fullNames.Count, Path.GetFileName(path));
                    }));

                    MediaFile m = new MediaFile(path);
                    if (m.IsValid())
                    {
                        if (!seriesMap.ContainsKey(m.Title))
                        {
                            seriesMap.Add(m.Title, new string[] { String.Empty, "Unknown", String.Empty });
                            Log("-- Added " + m.Title + " to Series Map");
                        }

                        if (cbAutoID.Checked && seriesMap[m.Title][1].Equals("Unknown"))
                        {
                            string seriesName = String.Empty;
                            string id = String.Empty;
                            string overview = String.Empty;
                            string searchName = m.Title;

                            this.Invoke(new EventHandler(delegate
                            {
                                toolStripStatusLabel1.Text = "Searching: " + searchName;
                            }));

                            Log("-- Searching for " + searchName);
                            
                            int seriesID = SeriesID.SearchSeries(searchName, out seriesName, out overview);
                            seriesMap[m.Title][1] = (seriesID < 0) ? "Unknown" : seriesID.ToString();
                            seriesMap[m.Title][0] = seriesName;
                            seriesMap[m.Title][2] = overview;

                            if (seriesID >= 0)
                            {
                                Log("-- Found series " + seriesName + " with ID " + seriesID.ToString());
                            }
                            else
                            {
                                Log("-- Did not find series for " + searchName);
                            }

                            Thread.Sleep(TVDB_DELAY);
                        }

                        if (ev.Argument.Equals("Update") && (seriesMap[m.Title][1] != "Unknown"))
                        {
                            if (m.RetrieveInfo(seriesMap[m.Title][0], int.Parse(seriesMap[m.Title][1])))
                            {
                                Log("-- Retrieved info for " + m.FullName);
                            }
                            else
                            {
                                Log("!! Error retrieving info for " + m.FullName);
                            }

                            PVSPropertyBag emBag = m.ToPVSPropertyBag();
                            btvLibrary.EditMedia(btvConnect.AuthTicket, m.FullName, emBag);

                            Thread.Sleep(TVDB_DELAY);
                        }
                    }
                    else
                    {
                        Log("?? Unable to process " + m.FullName);
                    }

                    n++;
                }

                this.Invoke(new EventHandler(delegate
                {
                    // update series map
                    foreach (KeyValuePair<string, string[]> pair in seriesMap)
                    {
                        bool hasEntry = false;
                        
                        foreach (ListViewItem lvi in lstSeriesMap.Items)
                        {
                            if (lvi.SubItems[0].Text.Equals(pair.Key))
                            {
                                hasEntry = true;
                                //lvi.SubItems[0].Text = pair.Key;
                                lvi.SubItems[1].Text = pair.Value[0];
                                lvi.SubItems[2].Text = pair.Value[1];
                                lvi.SubItems[3].Text = pair.Value[2];
                            }
                        }

                        if (!hasEntry)
                        {
                            lstSeriesMap.Items.Add(new ListViewItem(new string[] { pair.Key, pair.Value[0], pair.Value[1], pair.Value[2] }));
                        }
                    }
                }));
            }
            else
            {
                Log("!! Error connecting for scan/update.");
            }

            CheckForUnknownSeries();

            this.BeginInvoke(new EventHandler(delegate
            {
                toolStripStatusLabel1.Text = "Idle...";
                btnScan.Text = "Scan";
                btnUpdate.Text = "Update";
                btnLogon.Enabled = btnRefresh.Enabled = cbMediaFolders.Enabled = 
                    btnScan.Enabled = btnUpdate.Enabled = true;
            }));
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (btnScan.Text.Equals("Scan"))
            {
                cancelScanUpdate = false;
                Log("-- Running scan...");
                bwScanUpdate.RunWorkerAsync("Scan");
            }
            else
            {
                btnScan.Enabled = false;
                cancelScanUpdate = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (btnUpdate.Text.Equals("Update"))
            {
                cancelScanUpdate = false;
                Log("-- Running update...");
                bwScanUpdate.RunWorkerAsync("Update");
            }
            else
            {
                btnUpdate.Enabled = false;
                cancelScanUpdate = true;
            }
        }

        //###################################################################
        // SCHEDULE

        private void cbSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSchedule.Checked)
            {
                nudSchedule.Enabled = false;
                cancelSchedule = false;
                bwSchedule.RunWorkerAsync(nudSchedule.Value);
            }
            else
            {
                if (bwSchedule.IsBusy)
                {
                    cbSchedule.Enabled = false;
                    cancelSchedule = true;
                }
                else
                {
                    cbSchedule.Enabled = true;
                    nudSchedule.Enabled = true;
                }
            }
        }

        private void bwSchedule_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (Connect())
                {
                    cancelScanUpdate = false;
                    Log("-- Running scheduled update...");
                    bwScanUpdate.RunWorkerAsync("Update");
                    while (bwScanUpdate.IsBusy) { Thread.Sleep(1000); }
                }
                else
                {
                    Log("!! Error connecting for scheduled update.");
                }

                for (int n = 0; n < Convert.ToInt32(e.Argument) * 60; n++)
                {
                    Thread.Sleep(1000);
                    if (cancelSchedule)
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            cbSchedule.Enabled = true;
                            nudSchedule.Enabled = true;
                        }));
                        return;
                    }
                }
            }
        }

        private void moviesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovieEditor movEd = new MovieEditor(this);
            movEd.ShowDialog();
        }
    }
}
