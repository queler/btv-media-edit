/****************************************************************************
 * 
 * File:  SeriesID.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BTVMediaEdit
{
    using TvdbLib;
    using TvdbLib.Cache;
    using TvdbLib.Data;

    public partial class SeriesID : Form
    {
        private BackgroundWorker bwSearch = new BackgroundWorker();

        //###################################################################

        public SeriesID(string searchName, string seriesName, string id, string overview)
        {
            InitializeComponent();

            txtSearch.Text = searchName;
            if (!id.Equals("Unknown"))
            {
                txtSeriesName.Text = seriesName;
                txtSeriesID.Text = id;
                txtSeriesOverview.Text = overview;
                ListViewItem lvi = new ListViewItem(new string[] { seriesName, id });
                lvi.ToolTipText = overview;
                lstResults.Items.Add(lvi);
            }

            bwSearch.DoWork += new DoWorkEventHandler(bwSearch_DoWork);
        }

        public static int SearchSeries(string searchName, out string seriesName, out string overview)
        {
            try
            {
                TvdbHandler t;
                string cachePath = TvDb.GetCachePath();
                if (cachePath.Equals(String.Empty))
                {
                    t = new TvdbHandler(TvDb.TVDB_API_KEY);
                }
                else
                {
                    t = new TvdbHandler(new XmlCacheProvider(cachePath), TvDb.TVDB_API_KEY);
                }

                List<TvdbSearchResult> ss = t.SearchSeries(searchName);

                if (ss.Count > 0)
                {
                    overview = ss[0].Overview;
                    seriesName = ss[0].SeriesName;
                    return ss[0].Id;
                }
            }
            catch{}

            seriesName = String.Empty;
            overview = String.Empty;
            return -1;
        }

        public string _SeriesName
        {
            get { return txtSeriesName.Text;  }
            set { txtSeriesName.Text = value; }
        }

        public string _SeriesID
        {
            get { return txtSeriesID.Text;  }
            set { txtSeriesID.Text = value; }
        }

        public string _SeriesOverview
        {
            get { return txtSeriesOverview.Text;  }
            set { txtSeriesOverview.Text = value; }
        }

        //###################################################################

        private void bwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string series = String.Empty;
                this.Invoke(new EventHandler(delegate
                {
                    btnSearch.Enabled = false;
                    btnSearch.Text = "Searching...";
                    series = txtSearch.Text;
                }));

                TvdbHandler t;
                string cachePath = TvDb.GetCachePath();
                if (cachePath.Equals(String.Empty))
                {
                    t = new TvdbHandler(TvDb.TVDB_API_KEY);
                }
                else
                {
                    t = new TvdbHandler(new XmlCacheProvider(cachePath), TvDb.TVDB_API_KEY);
                }

                List<TvdbSearchResult> ss = t.SearchSeries(series);

                this.Invoke(new EventHandler(delegate
                {
                    lstResults.Items.Clear();
                    foreach (TvdbSearchResult sr in ss)
                    {
                        ListViewItem lvi = new ListViewItem(new string[] { sr.SeriesName, sr.Id.ToString() });
                        lvi.ToolTipText = sr.Overview.Replace("\n", "  ").Replace("|", "  ");
                        lstResults.Items.Add(lvi);
                    }
                    btnSearch.Text = "Search";
                    btnSearch.Enabled = true;
                }));
            }
            catch
            {
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bwSearch.RunWorkerAsync();
        }

        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResults.SelectedItems.Count > 0)
            {
                txtSeriesName.Text = lstResults.SelectedItems[0].SubItems[0].Text;
                txtSeriesID.Text = lstResults.SelectedItems[0].SubItems[1].Text;
                txtSeriesOverview.Text = lstResults.SelectedItems[0].ToolTipText;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
