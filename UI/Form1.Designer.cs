namespace UI
{
    partial class Form1
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.runButtonEnabled = new System.Windows.Forms.Button();
            this.logsDisplayBox = new System.Windows.Forms.TextBox();
            this.stopButtonEnabled = new System.Windows.Forms.Button();
            this.selectAll = new System.Windows.Forms.CheckBox();
            this.welcomeTextBox = new System.Windows.Forms.TextBox();
            this.runButtonDisabled = new System.Windows.Forms.Button();
            this.stopButtonDisabled = new System.Windows.Forms.Button();
            this.TestCasesTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // runButtonEnabled
            // 
            this.runButtonEnabled.Location = new System.Drawing.Point(1076, 45);
            this.runButtonEnabled.Name = "runButtonEnabled";
            this.runButtonEnabled.Size = new System.Drawing.Size(97, 37);
            this.runButtonEnabled.TabIndex = 1;
            this.runButtonEnabled.Text = "Run";
            this.runButtonEnabled.UseVisualStyleBackColor = true;
            // 
            // logsDisplayBox
            // 
            this.logsDisplayBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.logsDisplayBox.Location = new System.Drawing.Point(701, 142);
            this.logsDisplayBox.Multiline = true;
            this.logsDisplayBox.Name = "logsDisplayBox";
            this.logsDisplayBox.ReadOnly = true;
            this.logsDisplayBox.Size = new System.Drawing.Size(472, 312);
            this.logsDisplayBox.TabIndex = 2;
            // 
            // stopButtonEnabled
            // 
            this.stopButtonEnabled.Location = new System.Drawing.Point(1076, 88);
            this.stopButtonEnabled.Name = "stopButtonEnabled";
            this.stopButtonEnabled.Size = new System.Drawing.Size(97, 37);
            this.stopButtonEnabled.TabIndex = 3;
            this.stopButtonEnabled.Text = "Stop";
            this.stopButtonEnabled.UseVisualStyleBackColor = true;
            this.stopButtonEnabled.Visible = false;
            // 
            // selectAll
            // 
            this.selectAll.AutoSize = true;
            this.selectAll.Location = new System.Drawing.Point(43, 118);
            this.selectAll.Name = "selectAll";
            this.selectAll.Size = new System.Drawing.Size(93, 24);
            this.selectAll.TabIndex = 4;
            this.selectAll.Text = "Select All";
            this.selectAll.UseVisualStyleBackColor = true;
            // 
            // welcomeTextBox
            // 
            this.welcomeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.welcomeTextBox.Enabled = false;
            this.welcomeTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeTextBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.welcomeTextBox.Location = new System.Drawing.Point(701, 142);
            this.welcomeTextBox.Multiline = true;
            this.welcomeTextBox.Name = "welcomeTextBox";
            this.welcomeTextBox.Size = new System.Drawing.Size(472, 312);
            this.welcomeTextBox.TabIndex = 5;
            this.welcomeTextBox.Text = "Select a test case . . .";
            // 
            // runButtonDisabled
            // 
            this.runButtonDisabled.BackColor = System.Drawing.Color.LightGray;
            this.runButtonDisabled.Enabled = false;
            this.runButtonDisabled.Location = new System.Drawing.Point(1076, 46);
            this.runButtonDisabled.Name = "runButtonDisabled";
            this.runButtonDisabled.Size = new System.Drawing.Size(97, 36);
            this.runButtonDisabled.TabIndex = 6;
            this.runButtonDisabled.Text = "Run";
            this.runButtonDisabled.UseVisualStyleBackColor = false;
            // 
            // stopButtonDisabled
            // 
            this.stopButtonDisabled.BackColor = System.Drawing.Color.LightGray;
            this.stopButtonDisabled.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stopButtonDisabled.Enabled = false;
            this.stopButtonDisabled.Location = new System.Drawing.Point(1076, 88);
            this.stopButtonDisabled.Name = "stopButtonDisabled";
            this.stopButtonDisabled.Size = new System.Drawing.Size(97, 37);
            this.stopButtonDisabled.TabIndex = 7;
            this.stopButtonDisabled.Text = "Stop";
            this.stopButtonDisabled.UseVisualStyleBackColor = false;
            // 
            // TestCasesTreeView
            // 
            this.TestCasesTreeView.CheckBoxes = true;
            this.TestCasesTreeView.Location = new System.Drawing.Point(43, 148);
            this.TestCasesTreeView.Name = "TestCasesTreeView";
            this.TestCasesTreeView.Size = new System.Drawing.Size(606, 312);
            this.TestCasesTreeView.TabIndex = 8;
            this.TestCasesTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TestCasesTreeView_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 500);
            this.Controls.Add(this.TestCasesTreeView);
            this.Controls.Add(this.welcomeTextBox);
            this.Controls.Add(this.selectAll);
            this.Controls.Add(this.stopButtonEnabled);
            this.Controls.Add(this.logsDisplayBox);
            this.Controls.Add(this.runButtonEnabled);
            this.Controls.Add(this.runButtonDisabled);
            this.Controls.Add(this.stopButtonDisabled);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Curogram Automation Testing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Button runButtonEnabled;
        public TextBox logsDisplayBox;
        public Button stopButtonEnabled;
        public CheckBox selectAll;
        public TextBox welcomeTextBox;
        private Button runButtonDisabled;
        private Button stopButtonDisabled;
        private TreeView TestCasesTreeView;
    }
}