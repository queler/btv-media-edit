using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using BTVMediaEdit.Properties;

namespace BTVMediaEdit
{
    using BTVServer;
    using MovieDbLib;
    using MovieDbLib.Cache;
    using MovieDbLib.Data;
    using MovieDbLib.Data.Persons;

    public partial class MovieEditor : Form
    {
        private BTVMediaEdit btvME;
        private MovieDbHandler mDbH;

        private BackgroundWorker bwRefresh = new BackgroundWorker();
        private BackgroundWorker bwScan = new BackgroundWorker();

        private bool rcvdInput = false;
        private bool altSearch = false;

        public MovieEditor(BTVMediaEdit _btvME)
        {
            InitializeComponent();

            LoadSettings();

            btvME = _btvME;
            
            string cachePath = MovieDb.GetCachePath();
            if (cachePath.Equals(String.Empty))
            {
                mDbH = new MovieDbHandler(MovieDb.MOVIEDB_API_KEY);
            }
            else
            {
                mDbH = new MovieDbHandler(MovieDb.MOVIEDB_API_KEY, new XmlCacheProvider(cachePath));
            }

            bwRefresh.DoWork += new DoWorkEventHandler(bwRefresh_DoWork);
            bwScan.DoWork += new DoWorkEventHandler(bwScan_DoWork);
            bwScan.WorkerSupportsCancellation = true;
        }

        private void LoadSettings()
        {
            string[] movieFolders = Settings.Default.MovieFolders.Split('|');
            foreach (string movieFolder in movieFolders)
            {
                if (!movieFolder.Equals(String.Empty))
                {
                    clbMovieFolders.Items.Add(movieFolder, true);
                }
            }
        }

        private void SaveSettings()
        {
            Settings.Default.MovieFolders = "";
            foreach (object o in clbMovieFolders.CheckedItems)
            {
                Settings.Default.MovieFolders += String.Format("{0}|", o.ToString());
            }
            Settings.Default.MovieFolders.TrimEnd('|');
        }

        private void MovieEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        //###################################################################

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bwRefresh.RunWorkerAsync();
        }

        private void bwRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                btnRefresh.Enabled = false;
                toolStripStatusLabel1.Text = "Refreshing media folders...";
                clbMovieFolders.Items.Clear();
            }));

            if (btvME.Connect())
            {
                ArrayOfPVSPropertyBag bags = btvME.btvLibrary.GetFolders(btvME.btvConnect.AuthTicket, String.Empty);
                foreach (PVSPropertyBag bag in bags)
                {
                    foreach (PVSProperty prop in bag.Properties)
                    {
                        if (prop.Name.Equals("FullName"))
                        {
                            this.Invoke(new EventHandler(delegate { clbMovieFolders.Items.Add(prop.Value); }));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Error connecting for movie folder refresh.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.BeginInvoke(new EventHandler(delegate
            {
                btnRefresh.Enabled = true;
                toolStripStatusLabel1.Text = "Idle...";
            }));
        }

        private List<string> GetEnabledMovieFolders()
        {
            List<string> ls = new List<string>();

            this.Invoke(new EventHandler(delegate
            {
                foreach (object o in clbMovieFolders.CheckedItems)
                {
                    ls.Add(o.ToString());
                }
            }));

            return ls;
        }

        //###################################################################

        private void bwScan_DoWork(object sender, DoWorkEventArgs ev)
        {
            this.Invoke(new EventHandler(delegate
            {
                cbAuto.Enabled = cbSelect.Enabled = cbUnknown.Enabled = false;
                clbMovieFolders.Enabled = btnRefresh.Enabled = false;
                btnScan.Text = "Cancel";
                btnScan.Enabled = true;
                toolStripStatusLabel1.Text = "Starting Scan...";
            }));

            if (btvME.Connect())
            {
                // get array of media library items
                ArrayOfPVSPropertyBag bags;
                if (cbUnknown.Checked)
                {
                    bags = btvME.btvLibrary.GetItemsBySeries(btvME.btvConnect.AuthTicket, "Unknown");
                }
                else
                {
                    bags = btvME.btvLibrary.FlatViewByTitle(btvME.btvConnect.AuthTicket);
                }

                // scan for media library items on selected paths
                List<string> fullNames = new List<string>();
                foreach (PVSPropertyBag bag in bags)
                {
                    foreach (PVSProperty prop in bag.Properties)
                    {
                        if (prop.Name.Equals("FullName"))
                        {
                            foreach (string path in GetEnabledMovieFolders())
                            {
                                if (prop.Value.ToLower().StartsWith(path.ToLower()))
                                {
                                    fullNames.Add(prop.Value);
                                }
                            }
                        }
                    }
                }

                if (cbSelect.Checked && (fullNames.Count > 0))
                {
                    // select movie files to edit from list box
                    MovieSelect ms = new MovieSelect(fullNames);
                    DialogResult result = DialogResult.Cancel;
                    this.Invoke(new EventHandler(delegate
                    {
                        result = ms.ShowDialog(this);
                    }));

                    if (result.Equals(DialogResult.OK))
                    {
                        fullNames = ms.GetSelected();
                    }
                    else
                    {
                        goto ExitScan;
                    }
                }

                // process media files
                int n = 1;
                foreach (string path in fullNames)
                {
                    if (this.bwScan.CancellationPending)
                    {
                        ev.Cancel = true;
                        goto ExitScan;
                    }

                    rcvdInput = false;
                    altSearch = false;

                    MovieFile mf = new MovieFile(path);

                    this.Invoke(new EventHandler(delegate
                    {
                        toolStripStatusLabel1.Text =
                            String.Format("Processing ({0}/{1}): {2}",
                                            n, fullNames.Count, mf.FileName);
                        lvSearchResults.Items.Clear();
                        txtSearch.Text = mf.MovieName;
                        btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
                    }));

                    List<MovieDbMovie> searchMovies = mDbH.SearchMovie(mf.MovieName, new MovieDbLanguage(0, "en", "English"));

                    int selIndex = -1;
                    if (cbAuto.Checked && searchMovies.Count.Equals(1))
                    {
                        selIndex = 0;
                    }
                    else
                    {
                        this.Invoke(new EventHandler(delegate
                        {
                            foreach (MovieDbMovie movie in searchMovies)
                            {
                                lvSearchResults.Items.Add(new ListViewItem(new string[] { movie.MovieName, movie.Released.ToString("yyyy"), movie.Overview }));
                            }

                            if (lvSearchResults.Items.Count > 0)
                            {
                                lvSearchResults.Focus();
                                lvSearchResults.Items[0].Selected = true;
                                btnUpdate.Enabled = true;
                            }
                            btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = true;
                        }));

                        // wait for user input
                        while (true)
                        {
                            if (this.bwScan.CancellationPending)
                            {
                                ev.Cancel = true;
                                goto ExitScan;
                            }

                            System.Threading.Thread.Sleep(100);

                            if (rcvdInput)
                            {
                                break;
                            }

                            if (altSearch)
                            {
                                altSearch = false;

                                searchMovies = mDbH.SearchMovie(txtSearch.Text, new MovieDbLanguage(0, "en", "English"));

                                this.Invoke(new EventHandler(delegate
                                {
                                    lvSearchResults.Items.Clear();
                                    foreach (MovieDbMovie movie in searchMovies)
                                    {
                                        lvSearchResults.Items.Add(new ListViewItem(new string[] { movie.MovieName, movie.Released.ToString("yyyy"), movie.Overview }));
                                    }
                                    if (lvSearchResults.Items.Count > 0)
                                    {
                                        lvSearchResults.Focus();
                                        lvSearchResults.Items[0].Selected = true;
                                        btnUpdate.Enabled = true;
                                    }
                                    btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = true;
                                }));
                            }
                        }

                        this.Invoke(new EventHandler(delegate
                        {
                            if (lvSearchResults.SelectedIndices.Count > 0)
                            {
                                selIndex = lvSearchResults.SelectedIndices[0];
                            }
                        }));
                    }

                    if (selIndex >= 0)
                    {
                        MovieDbMovie movie = searchMovies[selIndex];
                        if ((mf.Part == null) || (mf.Part.Length == 0))
                            mf.MovieName = movie.MovieName;
                        else
                            mf.MovieName = movie.MovieName + " (Part " + mf.Part + ")";
                        mf.Overview = movie.Overview.TrimEnd(new char[] { '\n' });
                        mf.Released = movie.Released;
                        mf.Rating = movie.Rating;

                        if (movie.Cast == null)
                        {
                            // try to get cast info using TMDb ID
                            int tmdbID = searchMovies[selIndex].Id;
                            movie = mDbH.GetMovie(tmdbID, new MovieDbLanguage(0, "en", "English"));
                        }

                        if (movie.Cast != null)
                        {
                            foreach (MovieDbCast member in movie.Cast)
                            {
                                if (member.Job.Equals("Actor"))
                                {
                                    mf.Actors += String.Format("{0}, ", member.Name);
                                }
                            }
                            mf.Actors = mf.Actors.TrimEnd(new char[] { ',', ' ' });
                        }

                        PVSPropertyBag emBag = mf.ToPVSPropertyBag();
                        btvME.btvLibrary.EditMedia(btvME.btvConnect.AuthTicket, path, emBag);
                    }

                    n++;
                }
            }
            else
            {
                MessageBox.Show("Error connecting for scan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        ExitScan:
            this.BeginInvoke(new EventHandler(delegate
            {
                lvSearchResults.Items.Clear();
                txtSearch.Text = String.Empty;
                toolStripStatusLabel1.Text = "Idle...";
                btnScan.Text = "Scan";
                cbAuto.Enabled = cbSelect.Enabled = cbUnknown.Enabled = true;
                clbMovieFolders.Enabled = btnRefresh.Enabled = btnScan.Enabled = true;
                btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
            }));
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (btnScan.Text.Equals("Scan"))
            {
                bwScan.RunWorkerAsync();
            }
            else
            {
                btnScan.Enabled = false;
                bwScan.CancelAsync();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
            rcvdInput = true;
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
            lvSearchResults.Items.Clear();
            rcvdInput = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
            altSearch = true;
        }

        private void lvSearchResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSearchResults.SelectedItems.Count > 0)
            {
                btnUpdate.Enabled = btnSkip.Enabled = btnSearch.Enabled = txtSearch.Enabled = false;
                rcvdInput = true;
            }
        }
    }

    //#######################################################################

    public class MovieFile
    {
        private const int MAX_OVERVIEW = 303;

        public string FullName = String.Empty;
        public string FileName = String.Empty;
        public string MovieName = String.Empty;
        public string Overview = String.Empty;
        public string Actors = String.Empty;
        public DateTime Released = new DateTime(2000,1,1);
        public double Rating;
        public string Part = String.Empty;

        public MovieFile(string path)
        {
            FullName = path;
            FileName = Path.GetFileName(path);
            MovieName = FileName.Remove(FileName.LastIndexOf('.')).Replace('_', ' ').Replace('.', ' ');
            // check for partN,cdN,-DiscN
            Match partMatch = Regex.Match(MovieName, "[pP]art[0-9]+|[cC][dD][0-9]+|-Disc[0-9]+");
            if (partMatch.Success)
            {
                // get the number
                Match partNumMatch = Regex.Match(partMatch.Groups[0].Value, "([0-9]+)");
                Part = partNumMatch.Groups[0].Value;
                MovieName = MovieName.Remove(MovieName.IndexOf(partMatch.Groups[0].Value)).TrimEnd(' ');
            }
        }

        public PVSPropertyBag ToPVSPropertyBag()
        {
            List<PVSProperty> propList = new List<PVSProperty>();

            if (Overview.Length > MAX_OVERVIEW)
            {
                Overview = Overview.Substring(0, MAX_OVERVIEW) + "...";
            }

            PVSProperty pTitle = new PVSProperty();
            pTitle.Name = "Title";
            pTitle.Value = "Movies";
            propList.Add(pTitle);

            PVSProperty pEpisodeTitle = new PVSProperty();
            pEpisodeTitle.Name = "EpisodeTitle";
            pEpisodeTitle.Value = String.Empty;
            propList.Add(pEpisodeTitle);

            PVSProperty pDisplayTitle = new PVSProperty();
            pDisplayTitle.Name = "DisplayTitle";
            pDisplayTitle.Value = MovieName;
            propList.Add(pDisplayTitle);

            PVSProperty pEpisodeDescription = new PVSProperty();
            pEpisodeDescription.Name = "EpisodeDescription";
            pEpisodeDescription.Value = String.Format("[{0}] {1} (Rating: {2:0.0})", Released.ToString("yyyy"), Overview, Rating);
            propList.Add(pEpisodeDescription);

            PVSProperty pActors = new PVSProperty();
            pActors.Name = "Actors";
            pActors.Value = Actors;
            propList.Add(pActors);

            PVSProperty pOriginalAirDate = new PVSProperty();
            pOriginalAirDate.Name = "OriginalAirDate";
            pOriginalAirDate.Value = Released.ToString("yyyyMMdd");
            propList.Add(pOriginalAirDate);

            try
            {
                PVSProperty pActualStart = new PVSProperty();
                pActualStart.Name = "ActualStart";
                pActualStart.Value = Released.ToFileTime().ToString();
                propList.Add(pActualStart);
            }
            catch { }

            PVSPropertyBag bag = new PVSPropertyBag();
            bag.Properties = (PVSProperty[])propList.ToArray<PVSProperty>();
            return bag;
        }
    }
}
