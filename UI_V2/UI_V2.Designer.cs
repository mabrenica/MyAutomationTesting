﻿namespace UI_V2
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.ContainerTestCases = new System.Windows.Forms.Panel();
            this.treeViewTestCases = new System.Windows.Forms.TreeView();
            this.ContainerSelectAll = new System.Windows.Forms.Panel();
            this.buttonDeselectAllEnabled = new System.Windows.Forms.Button();
            this.buttonSelectAllEnabled = new System.Windows.Forms.Button();
            this.buttonSelectAllDisabled = new System.Windows.Forms.Button();
            this.ContainerLogs = new System.Windows.Forms.Panel();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.textBoxLogs = new System.Windows.Forms.TextBox();
            this.buttonStartEnabled = new System.Windows.Forms.Button();
            this.buttonStartDisabled = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.process1 = new System.Diagnostics.Process();
            this.ContainerTestCases.SuspendLayout();
            this.ContainerSelectAll.SuspendLayout();
            this.ContainerLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContainerTestCases
            // 
            this.ContainerTestCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.ContainerTestCases.Controls.Add(this.treeViewTestCases);
            this.ContainerTestCases.Controls.Add(this.ContainerSelectAll);
            this.ContainerTestCases.Location = new System.Drawing.Point(26, 40);
            this.ContainerTestCases.Name = "ContainerTestCases";
            this.ContainerTestCases.Size = new System.Drawing.Size(572, 561);
            this.ContainerTestCases.TabIndex = 0;
            // 
            // treeViewTestCases
            // 
            this.treeViewTestCases.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.treeViewTestCases.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeViewTestCases.CheckBoxes = true;
            this.treeViewTestCases.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.treeViewTestCases.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(177)))));
            this.treeViewTestCases.HideSelection = false;
            this.treeViewTestCases.Indent = 25;
            this.treeViewTestCases.ItemHeight = 25;
            this.treeViewTestCases.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.treeViewTestCases.Location = new System.Drawing.Point(21, 59);
            this.treeViewTestCases.Margin = new System.Windows.Forms.Padding(0);
            this.treeViewTestCases.Name = "treeViewTestCases";
            this.treeViewTestCases.ShowLines = false;
            this.treeViewTestCases.Size = new System.Drawing.Size(538, 502);
            this.treeViewTestCases.TabIndex = 1;
            this.treeViewTestCases.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTestCases_AfterSelect);
            // 
            // ContainerSelectAll
            // 
            this.ContainerSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(58)))), ((int)(((byte)(88)))));
            this.ContainerSelectAll.Controls.Add(this.buttonDeselectAllEnabled);
            this.ContainerSelectAll.Controls.Add(this.buttonSelectAllEnabled);
            this.ContainerSelectAll.Controls.Add(this.buttonSelectAllDisabled);
            this.ContainerSelectAll.Location = new System.Drawing.Point(21, 14);
            this.ContainerSelectAll.Name = "ContainerSelectAll";
            this.ContainerSelectAll.Size = new System.Drawing.Size(538, 42);
            this.ContainerSelectAll.TabIndex = 0;
            // 
            // buttonDeselectAllEnabled
            // 
            this.buttonDeselectAllEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonDeselectAllEnabled.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDeselectAllEnabled.ForeColor = System.Drawing.Color.White;
            this.buttonDeselectAllEnabled.Location = new System.Drawing.Point(3, 7);
            this.buttonDeselectAllEnabled.Name = "buttonDeselectAllEnabled";
            this.buttonDeselectAllEnabled.Size = new System.Drawing.Size(89, 32);
            this.buttonDeselectAllEnabled.TabIndex = 2;
            this.buttonDeselectAllEnabled.Text = "Deselect All";
            this.buttonDeselectAllEnabled.UseVisualStyleBackColor = false;
            this.buttonDeselectAllEnabled.Click += new System.EventHandler(this.buttonDeselectAllEnabled_Click);
            // 
            // buttonSelectAllEnabled
            // 
            this.buttonSelectAllEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonSelectAllEnabled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonSelectAllEnabled.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSelectAllEnabled.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonSelectAllEnabled.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSelectAllEnabled.ForeColor = System.Drawing.Color.White;
            this.buttonSelectAllEnabled.Location = new System.Drawing.Point(3, 7);
            this.buttonSelectAllEnabled.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectAllEnabled.Name = "buttonSelectAllEnabled";
            this.buttonSelectAllEnabled.Size = new System.Drawing.Size(89, 32);
            this.buttonSelectAllEnabled.TabIndex = 0;
            this.buttonSelectAllEnabled.Text = "Select All";
            this.buttonSelectAllEnabled.UseVisualStyleBackColor = false;
            this.buttonSelectAllEnabled.Click += new System.EventHandler(this.buttonSelectAllEnabled_Click);
            // 
            // buttonSelectAllDisabled
            // 
            this.buttonSelectAllDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonSelectAllDisabled.Enabled = false;
            this.buttonSelectAllDisabled.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSelectAllDisabled.ForeColor = System.Drawing.Color.White;
            this.buttonSelectAllDisabled.Location = new System.Drawing.Point(3, 7);
            this.buttonSelectAllDisabled.Name = "buttonSelectAllDisabled";
            this.buttonSelectAllDisabled.Size = new System.Drawing.Size(89, 32);
            this.buttonSelectAllDisabled.TabIndex = 1;
            this.buttonSelectAllDisabled.Text = "Select All";
            this.buttonSelectAllDisabled.UseVisualStyleBackColor = false;
            this.buttonSelectAllDisabled.Click += new System.EventHandler(this.buttonSelectAllDisabled_Click);
            // 
            // ContainerLogs
            // 
            this.ContainerLogs.Controls.Add(this.textBoxSummary);
            this.ContainerLogs.Controls.Add(this.textBoxLogs);
            this.ContainerLogs.Location = new System.Drawing.Point(623, 81);
            this.ContainerLogs.Name = "ContainerLogs";
            this.ContainerLogs.Size = new System.Drawing.Size(501, 520);
            this.ContainerLogs.TabIndex = 1;
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxSummary.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSummary.Location = new System.Drawing.Point(3, 3);
            this.textBoxSummary.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.Size = new System.Drawing.Size(498, 514);
            this.textBoxSummary.TabIndex = 1;
            this.textBoxSummary.WordWrap = false;
            // 
            // textBoxLogs
            // 
            this.textBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.textBoxLogs.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxLogs.Location = new System.Drawing.Point(3, 3);
            this.textBoxLogs.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.textBoxLogs.Multiline = true;
            this.textBoxLogs.Name = "textBoxLogs";
            this.textBoxLogs.Size = new System.Drawing.Size(498, 514);
            this.textBoxLogs.TabIndex = 0;
            this.textBoxLogs.TextChanged += new System.EventHandler(this.textBoxLogs_TextChanged);
            // 
            // buttonStartEnabled
            // 
            this.buttonStartEnabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonStartEnabled.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStartEnabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(202)))));
            this.buttonStartEnabled.Location = new System.Drawing.Point(998, 40);
            this.buttonStartEnabled.Name = "buttonStartEnabled";
            this.buttonStartEnabled.Size = new System.Drawing.Size(112, 35);
            this.buttonStartEnabled.TabIndex = 2;
            this.buttonStartEnabled.Text = "Start";
            this.buttonStartEnabled.UseVisualStyleBackColor = false;
            this.buttonStartEnabled.Click += new System.EventHandler(this.buttonStartEnabled_Click);
            // 
            // buttonStartDisabled
            // 
            this.buttonStartDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonStartDisabled.Enabled = false;
            this.buttonStartDisabled.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStartDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(202)))));
            this.buttonStartDisabled.Location = new System.Drawing.Point(998, 40);
            this.buttonStartDisabled.Name = "buttonStartDisabled";
            this.buttonStartDisabled.Size = new System.Drawing.Size(112, 35);
            this.buttonStartDisabled.TabIndex = 3;
            this.buttonStartDisabled.Text = "Start";
            this.buttonStartDisabled.UseVisualStyleBackColor = false;
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(51)))), ((int)(((byte)(82)))));
            this.buttonStop.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(202)))));
            this.buttonStop.Location = new System.Drawing.Point(998, 40);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(112, 35);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardInputEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(28)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(1149, 631);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStartDisabled);
            this.Controls.Add(this.buttonStartEnabled);
            this.Controls.Add(this.ContainerLogs);
            this.Controls.Add(this.ContainerTestCases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1167, 678);
            this.MinimumSize = new System.Drawing.Size(1167, 678);
            this.Name = "MainPage";
            this.Text = "Curogram Automation Testing";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPage_FormClosing);
            this.Load += new System.EventHandler(this.UI_V2_Load);
            this.ContainerTestCases.ResumeLayout(false);
            this.ContainerSelectAll.ResumeLayout(false);
            this.ContainerLogs.ResumeLayout(false);
            this.ContainerLogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Panel ContainerTestCases;
        public Panel ContainerSelectAll;
        public Button buttonDeselectAllEnabled;
        public Button buttonSelectAllDisabled;
        public Button buttonSelectAllEnabled;
        public Panel ContainerLogs;
        public TextBox textBoxSummary;
        public TextBox textBoxLogs;
        public Button buttonStartEnabled;
        public Button buttonStartDisabled;
        public Button buttonStop;
        public TreeView treeViewTestCases;
        public System.Diagnostics.Process process1;
    }
}