/****************************************************************************
 * 
 * File:  SeriesID.Designer.cs
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
    partial class SeriesID
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lstResults = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chSeriesID = new System.Windows.Forms.ColumnHeader();
            this.txtSeriesID = new System.Windows.Forms.TextBox();
            this.lblSeriesID = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSeriesOverview = new System.Windows.Forms.TextBox();
            this.txtSeriesName = new System.Windows.Forms.TextBox();
            this.lblSeriesName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(286, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(305, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lstResults
            // 
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSeriesID});
            this.lstResults.FullRowSelect = true;
            this.lstResults.GridLines = true;
            this.lstResults.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstResults.Location = new System.Drawing.Point(13, 39);
            this.lstResults.MultiSelect = false;
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(367, 125);
            this.lstResults.TabIndex = 2;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.SelectedIndexChanged += new System.EventHandler(this.lstResults_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Series Name";
            this.chName.Width = 300;
            // 
            // chSeriesID
            // 
            this.chSeriesID.Text = "SeriesID";
            // 
            // txtSeriesID
            // 
            this.txtSeriesID.Location = new System.Drawing.Point(85, 196);
            this.txtSeriesID.Name = "txtSeriesID";
            this.txtSeriesID.Size = new System.Drawing.Size(135, 20);
            this.txtSeriesID.TabIndex = 6;
            // 
            // lblSeriesID
            // 
            this.lblSeriesID.AutoSize = true;
            this.lblSeriesID.Location = new System.Drawing.Point(29, 199);
            this.lblSeriesID.Name = "lblSeriesID";
            this.lblSeriesID.Size = new System.Drawing.Size(50, 13);
            this.lblSeriesID.TabIndex = 9;
            this.lblSeriesID.Text = "Series ID";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(226, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(305, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSeriesOverview
            // 
            this.txtSeriesOverview.Location = new System.Drawing.Point(12, 225);
            this.txtSeriesOverview.Multiline = true;
            this.txtSeriesOverview.Name = "txtSeriesOverview";
            this.txtSeriesOverview.ReadOnly = true;
            this.txtSeriesOverview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSeriesOverview.Size = new System.Drawing.Size(368, 168);
            this.txtSeriesOverview.TabIndex = 7;
            // 
            // txtSeriesName
            // 
            this.txtSeriesName.Location = new System.Drawing.Point(85, 170);
            this.txtSeriesName.Name = "txtSeriesName";
            this.txtSeriesName.Size = new System.Drawing.Size(295, 20);
            this.txtSeriesName.TabIndex = 3;
            // 
            // lblSeriesName
            // 
            this.lblSeriesName.AutoSize = true;
            this.lblSeriesName.Location = new System.Drawing.Point(12, 173);
            this.lblSeriesName.Name = "lblSeriesName";
            this.lblSeriesName.Size = new System.Drawing.Size(67, 13);
            this.lblSeriesName.TabIndex = 8;
            this.lblSeriesName.Text = "Series Name";
            // 
            // SeriesID
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(392, 413);
            this.ControlBox = false;
            this.Controls.Add(this.lblSeriesName);
            this.Controls.Add(this.txtSeriesName);
            this.Controls.Add(this.txtSeriesOverview);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSeriesID);
            this.Controls.Add(this.txtSeriesID);
            this.Controls.Add(this.lstResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 440);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 440);
            this.Name = "SeriesID";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Series Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.TextBox txtSeriesID;
        private System.Windows.Forms.Label lblSeriesID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSeriesID;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSeriesOverview;
        private System.Windows.Forms.TextBox txtSeriesName;
        private System.Windows.Forms.Label lblSeriesName;
    }
}