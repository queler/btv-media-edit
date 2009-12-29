/****************************************************************************
 * 
 * File:  BTVMediaEdit.Designer.cs
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

namespace BTVMediaEdit
{
    partial class BTVMediaEdit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BTVMediaEdit));
            this.gbBTVServerSettings = new System.Windows.Forms.GroupBox();
            this.btnLogon = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMinimizedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbMediaFolders = new System.Windows.Forms.GroupBox();
            this.cbMediaFolders = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbSeriesMap = new System.Windows.Forms.GroupBox();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lstSeriesMap = new System.Windows.Forms.ListView();
            this.chParsedName = new System.Windows.Forms.ColumnHeader();
            this.chSeriesName = new System.Windows.Forms.ColumnHeader();
            this.chSeriesID = new System.Windows.Forms.ColumnHeader();
            this.chSeriesOverview = new System.Windows.Forms.ColumnHeader();
            this.btnScan = new System.Windows.Forms.Button();
            this.cbSchedule = new System.Windows.Forms.CheckBox();
            this.nudSchedule = new System.Windows.Forms.NumericUpDown();
            this.gbSchedule = new System.Windows.Forms.GroupBox();
            this.cbUnknown = new System.Windows.Forms.CheckBox();
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.lblSplit = new System.Windows.Forms.Label();
            this.cbAutoID = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbBTVServerSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbMediaFolders.SuspendLayout();
            this.gbSeriesMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSchedule)).BeginInit();
            this.gbSchedule.SuspendLayout();
            this.gbControl.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBTVServerSettings
            // 
            this.gbBTVServerSettings.Controls.Add(this.btnLogon);
            this.gbBTVServerSettings.Controls.Add(this.lblPassword);
            this.gbBTVServerSettings.Controls.Add(this.txtPassword);
            this.gbBTVServerSettings.Controls.Add(this.lblUser);
            this.gbBTVServerSettings.Controls.Add(this.lblAddress);
            this.gbBTVServerSettings.Controls.Add(this.lblPort);
            this.gbBTVServerSettings.Controls.Add(this.txtUser);
            this.gbBTVServerSettings.Controls.Add(this.txtPort);
            this.gbBTVServerSettings.Controls.Add(this.txtAddress);
            this.gbBTVServerSettings.Location = new System.Drawing.Point(12, 27);
            this.gbBTVServerSettings.Name = "gbBTVServerSettings";
            this.gbBTVServerSettings.Size = new System.Drawing.Size(200, 155);
            this.gbBTVServerSettings.TabIndex = 1;
            this.gbBTVServerSettings.TabStop = false;
            this.gbBTVServerSettings.Text = "BTV Server Settings";
            // 
            // btnLogon
            // 
            this.btnLogon.Location = new System.Drawing.Point(119, 123);
            this.btnLogon.Name = "btnLogon";
            this.btnLogon.Size = new System.Drawing.Size(75, 23);
            this.btnLogon.TabIndex = 4;
            this.btnLogon.Text = "Logon";
            this.btnLogon.UseVisualStyleBackColor = true;
            this.btnLogon.Click += new System.EventHandler(this.btnLogon_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(6, 100);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(65, 97);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(129, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 74);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "User";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 22);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(45, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Address";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 48);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(65, 71);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(129, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "administrator";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(65, 45);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(129, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8129";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(65, 19);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(129, 20);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "localhost";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem1,
            this.moviesToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.optionsToolStripMenuItem.Text = "Edit";
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.moviesToolStripMenuItem.Text = "Movies...";
            this.moviesToolStripMenuItem.Click += new System.EventHandler(this.moviesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startWithWindowsToolStripMenuItem,
            this.startMinimizedToolStripMenuItem});
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem1.Text = "Options";
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start With Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // startMinimizedToolStripMenuItem
            // 
            this.startMinimizedToolStripMenuItem.Name = "startMinimizedToolStripMenuItem";
            this.startMinimizedToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startMinimizedToolStripMenuItem.Text = "Start Minimized";
            this.startMinimizedToolStripMenuItem.Click += new System.EventHandler(this.startMinimizedToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel1.Text = "Idle...";
            // 
            // gbMediaFolders
            // 
            this.gbMediaFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMediaFolders.Controls.Add(this.cbMediaFolders);
            this.gbMediaFolders.Controls.Add(this.btnRefresh);
            this.gbMediaFolders.Location = new System.Drawing.Point(424, 27);
            this.gbMediaFolders.Name = "gbMediaFolders";
            this.gbMediaFolders.Size = new System.Drawing.Size(250, 155);
            this.gbMediaFolders.TabIndex = 4;
            this.gbMediaFolders.TabStop = false;
            this.gbMediaFolders.Text = "Media Folders";
            // 
            // cbMediaFolders
            // 
            this.cbMediaFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMediaFolders.CheckOnClick = true;
            this.cbMediaFolders.FormattingEnabled = true;
            this.cbMediaFolders.HorizontalScrollbar = true;
            this.cbMediaFolders.Location = new System.Drawing.Point(6, 19);
            this.cbMediaFolders.Name = "cbMediaFolders";
            this.cbMediaFolders.Size = new System.Drawing.Size(238, 94);
            this.cbMediaFolders.Sorted = true;
            this.cbMediaFolders.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(169, 126);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbSeriesMap
            // 
            this.gbSeriesMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSeriesMap.Controls.Add(this.btnClearList);
            this.gbSeriesMap.Controls.Add(this.btnDelete);
            this.gbSeriesMap.Controls.Add(this.btnEdit);
            this.gbSeriesMap.Controls.Add(this.lstSeriesMap);
            this.gbSeriesMap.Location = new System.Drawing.Point(12, 188);
            this.gbSeriesMap.Name = "gbSeriesMap";
            this.gbSeriesMap.Size = new System.Drawing.Size(662, 178);
            this.gbSeriesMap.TabIndex = 5;
            this.gbSeriesMap.TabStop = false;
            this.gbSeriesMap.Text = "Series Map";
            // 
            // btnClearList
            // 
            this.btnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearList.Location = new System.Drawing.Point(581, 149);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(75, 23);
            this.btnClearList.TabIndex = 3;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(500, 149);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(6, 149);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lstSeriesMap
            // 
            this.lstSeriesMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSeriesMap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chParsedName,
            this.chSeriesName,
            this.chSeriesID,
            this.chSeriesOverview});
            this.lstSeriesMap.FullRowSelect = true;
            this.lstSeriesMap.GridLines = true;
            this.lstSeriesMap.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSeriesMap.Location = new System.Drawing.Point(6, 19);
            this.lstSeriesMap.MultiSelect = false;
            this.lstSeriesMap.Name = "lstSeriesMap";
            this.lstSeriesMap.Size = new System.Drawing.Size(650, 124);
            this.lstSeriesMap.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstSeriesMap.TabIndex = 0;
            this.lstSeriesMap.UseCompatibleStateImageBehavior = false;
            this.lstSeriesMap.View = System.Windows.Forms.View.Details;
            this.lstSeriesMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSeriesMap_MouseDoubleClick);
            this.lstSeriesMap.SelectedIndexChanged += new System.EventHandler(this.lstSeriesMap_SelectedIndexChanged);
            // 
            // chParsedName
            // 
            this.chParsedName.Text = "Parsed Name";
            this.chParsedName.Width = 160;
            // 
            // chSeriesName
            // 
            this.chSeriesName.Text = "Series Name";
            this.chSeriesName.Width = 160;
            // 
            // chSeriesID
            // 
            this.chSeriesID.Text = "SeriesID";
            // 
            // chSeriesOverview
            // 
            this.chSeriesOverview.Text = "Series Overview";
            this.chSeriesOverview.Width = 1024;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(6, 13);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 0;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // cbSchedule
            // 
            this.cbSchedule.AutoSize = true;
            this.cbSchedule.Location = new System.Drawing.Point(6, 19);
            this.cbSchedule.Name = "cbSchedule";
            this.cbSchedule.Size = new System.Drawing.Size(192, 17);
            this.cbSchedule.TabIndex = 0;
            this.cbSchedule.Text = "Update every                      minutes";
            this.cbSchedule.UseVisualStyleBackColor = true;
            this.cbSchedule.CheckedChanged += new System.EventHandler(this.cbSchedule_CheckedChanged);
            // 
            // nudSchedule
            // 
            this.nudSchedule.Location = new System.Drawing.Point(96, 18);
            this.nudSchedule.Maximum = new decimal(new int[] {
            1440,
            0,
            0,
            0});
            this.nudSchedule.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSchedule.Name = "nudSchedule";
            this.nudSchedule.Size = new System.Drawing.Size(50, 20);
            this.nudSchedule.TabIndex = 1;
            this.nudSchedule.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // gbSchedule
            // 
            this.gbSchedule.Controls.Add(this.nudSchedule);
            this.gbSchedule.Controls.Add(this.cbSchedule);
            this.gbSchedule.Location = new System.Drawing.Point(218, 137);
            this.gbSchedule.Name = "gbSchedule";
            this.gbSchedule.Size = new System.Drawing.Size(200, 45);
            this.gbSchedule.TabIndex = 3;
            this.gbSchedule.TabStop = false;
            this.gbSchedule.Text = "Schedule";
            // 
            // cbUnknown
            // 
            this.cbUnknown.AutoSize = true;
            this.cbUnknown.Checked = true;
            this.cbUnknown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnknown.Location = new System.Drawing.Point(6, 58);
            this.cbUnknown.Name = "cbUnknown";
            this.cbUnknown.Size = new System.Drawing.Size(149, 17);
            this.cbUnknown.TabIndex = 2;
            this.cbUnknown.Text = "Only Edit Unknown Series";
            this.cbUnknown.UseVisualStyleBackColor = true;
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.lblSplit);
            this.gbControl.Controls.Add(this.cbAutoID);
            this.gbControl.Controls.Add(this.btnUpdate);
            this.gbControl.Controls.Add(this.cbUnknown);
            this.gbControl.Controls.Add(this.btnScan);
            this.gbControl.Location = new System.Drawing.Point(218, 27);
            this.gbControl.Name = "gbControl";
            this.gbControl.Size = new System.Drawing.Size(200, 104);
            this.gbControl.TabIndex = 2;
            this.gbControl.TabStop = false;
            // 
            // lblSplit
            // 
            this.lblSplit.AutoSize = true;
            this.lblSplit.Location = new System.Drawing.Point(3, 39);
            this.lblSplit.Name = "lblSplit";
            this.lblSplit.Size = new System.Drawing.Size(193, 13);
            this.lblSplit.TabIndex = 4;
            this.lblSplit.Text = "--------------------------------------------------------------";
            // 
            // cbAutoID
            // 
            this.cbAutoID.AutoSize = true;
            this.cbAutoID.Checked = true;
            this.cbAutoID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoID.Location = new System.Drawing.Point(6, 81);
            this.cbAutoID.Name = "cbAutoID";
            this.cbAutoID.Size = new System.Drawing.Size(187, 17);
            this.cbAutoID.TabIndex = 3;
            this.cbAutoID.Text = "Auto-Lookup Unknown Series IDs";
            this.cbAutoID.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(118, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "BTV Media Edit";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.openToolStripMenuItem.Text = "  Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.exitToolStripMenuItem.Text = "  Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // BTVMediaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 401);
            this.Controls.Add(this.gbSchedule);
            this.Controls.Add(this.gbControl);
            this.Controls.Add(this.gbSeriesMap);
            this.Controls.Add(this.gbMediaFolders);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbBTVServerSettings);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(692, 428);
            this.Name = "BTVMediaEdit";
            this.Text = "BTV Media Edit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BTVMediaEdit_FormClosing);
            this.Resize += new System.EventHandler(this.BTVMediaEdit_Resize);
            this.gbBTVServerSettings.ResumeLayout(false);
            this.gbBTVServerSettings.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbMediaFolders.ResumeLayout(false);
            this.gbSeriesMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudSchedule)).EndInit();
            this.gbSchedule.ResumeLayout(false);
            this.gbSchedule.PerformLayout();
            this.gbControl.ResumeLayout(false);
            this.gbControl.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBTVServerSettings;
        private System.Windows.Forms.Button btnLogon;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbMediaFolders;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbSeriesMap;
        private System.Windows.Forms.ListView lstSeriesMap;
        private System.Windows.Forms.ColumnHeader chParsedName;
        private System.Windows.Forms.ColumnHeader chSeriesID;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox cbSchedule;
        private System.Windows.Forms.NumericUpDown nudSchedule;
        private System.Windows.Forms.GroupBox gbSchedule;
        private System.Windows.Forms.CheckBox cbUnknown;
        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ColumnHeader chSeriesOverview;
        private System.Windows.Forms.CheckedListBox cbMediaFolders;
        private System.Windows.Forms.ColumnHeader chSeriesName;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox cbAutoID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblSplit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMinimizedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
    }
}

