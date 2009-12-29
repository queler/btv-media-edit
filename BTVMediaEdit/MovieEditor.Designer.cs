namespace BTVMediaEdit
{
    partial class MovieEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMovieFolders = new System.Windows.Forms.GroupBox();
            this.clbMovieFolders = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.lvSearchResults = new System.Windows.Forms.ListView();
            this.chTitle = new System.Windows.Forms.ColumnHeader();
            this.chYear = new System.Windows.Forms.ColumnHeader();
            this.chPlot = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.cbSelect = new System.Windows.Forms.CheckBox();
            this.lblSplit = new System.Windows.Forms.Label();
            this.cbUnknown = new System.Windows.Forms.CheckBox();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.gbMovieFolders.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMovieFolders
            // 
            this.gbMovieFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMovieFolders.Controls.Add(this.clbMovieFolders);
            this.gbMovieFolders.Controls.Add(this.btnRefresh);
            this.gbMovieFolders.Location = new System.Drawing.Point(281, 12);
            this.gbMovieFolders.Name = "gbMovieFolders";
            this.gbMovieFolders.Size = new System.Drawing.Size(391, 130);
            this.gbMovieFolders.TabIndex = 5;
            this.gbMovieFolders.TabStop = false;
            this.gbMovieFolders.Text = "Movie Folders";
            // 
            // clbMovieFolders
            // 
            this.clbMovieFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbMovieFolders.CheckOnClick = true;
            this.clbMovieFolders.FormattingEnabled = true;
            this.clbMovieFolders.HorizontalScrollbar = true;
            this.clbMovieFolders.Location = new System.Drawing.Point(6, 19);
            this.clbMovieFolders.Name = "clbMovieFolders";
            this.clbMovieFolders.Size = new System.Drawing.Size(379, 79);
            this.clbMovieFolders.Sorted = true;
            this.clbMovieFolders.TabIndex = 6;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(310, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnScan
            // 
            this.btnScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScan.Location = new System.Drawing.Point(6, 19);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(247, 23);
            this.btnScan.TabIndex = 1;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // lvSearchResults
            // 
            this.lvSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSearchResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chTitle,
            this.chYear,
            this.chPlot});
            this.lvSearchResults.FullRowSelect = true;
            this.lvSearchResults.GridLines = true;
            this.lvSearchResults.Location = new System.Drawing.Point(9, 19);
            this.lvSearchResults.Name = "lvSearchResults";
            this.lvSearchResults.Size = new System.Drawing.Size(645, 167);
            this.lvSearchResults.TabIndex = 9;
            this.lvSearchResults.UseCompatibleStateImageBehavior = false;
            this.lvSearchResults.View = System.Windows.Forms.View.Details;
            this.lvSearchResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSearchResults_MouseDoubleClick);
            // 
            // chTitle
            // 
            this.chTitle.Text = "Title";
            this.chTitle.Width = 240;
            // 
            // chYear
            // 
            this.chYear.Text = "Year";
            // 
            // chPlot
            // 
            this.chPlot.Text = "Plot";
            this.chPlot.Width = 480;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel1.Text = "Idle...";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(9, 192);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSkip.Enabled = false;
            this.btnSkip.Location = new System.Drawing.Point(90, 192);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(75, 23);
            this.btnSkip.TabIndex = 11;
            this.btnSkip.Text = "Skip";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(171, 194);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(402, 20);
            this.txtSearch.TabIndex = 12;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(579, 192);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.cbAuto);
            this.gbControl.Controls.Add(this.cbSelect);
            this.gbControl.Controls.Add(this.lblSplit);
            this.gbControl.Controls.Add(this.cbUnknown);
            this.gbControl.Controls.Add(this.btnScan);
            this.gbControl.Location = new System.Drawing.Point(12, 12);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(259, 130);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(9, 84);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(211, 17);
            this.cbAuto.TabIndex = 3;
            this.cbAuto.Text = "Auto-Update When One Search Result";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // cbSelect
            // 
            this.cbSelect.AutoSize = true;
            this.cbSelect.Location = new System.Drawing.Point(9, 107);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(175, 17);
            this.cbSelect.TabIndex = 4;
            this.cbSelect.Text = "Select Movies To Edit From List";
            this.cbSelect.UseVisualStyleBackColor = true;
            // 
            // lblSplit
            // 
            this.lblSplit.AutoSize = true;
            this.lblSplit.Location = new System.Drawing.Point(6, 45);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(250, 13);
            this.lblSplit.TabIndex = 5;
            this.lblSplit.Text = "---------------------------------------------------------------------------------" +
                "";
            // 
            // cbUnknown
            // 
            this.cbUnknown.AutoSize = true;
            this.cbUnknown.Checked = true;
            this.cbUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnknown.Location = new System.Drawing.Point(9, 61);
            this.cbUnknown.Name = "cbUnknown";
            this.cbUnknown.Size = new System.Drawing.Size(154, 17);
            this.cbUnknown.TabIndex = 2;
            this.cbUnknown.Text = "Only Edit Unknown Movies";
            this.cbUnknown.UseVisualStyleBackColor = true;
            // 
            // gbResults
            // 
            this.gbResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResults.Controls.Add(this.btnUpdate);
            this.gbResults.Controls.Add(this.btnSearch);
            this.gbResults.Controls.Add(this.btnSkip);
            this.gbResults.Controls.Add(this.txtSearch);
            this.gbResults.Controls.Add(this.lvSearchResults);
            this.gbResults.Location = new System.Drawing.Point(12, 148);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(660, 225);
            this.gbResults.TabIndex = 8;
            this.gbResults.TabStop = false;
            // 
            // MovieEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 401);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbMovieFolders);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 428);
            this.Name = "MovieEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieEditor_FormClosing);
            this.gbMovieFolders.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMovieFolders;
        private System.Windows.Forms.CheckedListBox clbMovieFolders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ListView lvSearchResults;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.ColumnHeader chPlot;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.CheckBox cbUnknown;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.ColumnHeader chYear;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.CheckBox cbSelect;
        private System.Windows.Forms.CheckBox cbAuto;

    }
}