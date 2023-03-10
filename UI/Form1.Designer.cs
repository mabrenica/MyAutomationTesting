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
            testCasesList = new CheckedListBox();
            runButtonEnabled = new Button();
            logsDisplayBox = new TextBox();
            stopButtonEnabled = new Button();
            selectAll = new CheckBox();
            welcomeTextBox = new TextBox();
            runButtonDisabled = new Button();
            stopButtonDisabled = new Button();
            SuspendLayout();
            // 
            // testCasesList
            // 
            testCasesList.CheckOnClick = true;
            testCasesList.FormattingEnabled = true;
            testCasesList.Location = new Point(41, 142);
            testCasesList.Name = "testCasesList";
            testCasesList.Size = new Size(623, 312);
            testCasesList.TabIndex = 0;
            testCasesList.SelectedIndexChanged += testCasesList_SelectedIndexChanged;
            // 
            // runButtonEnabled
            // 
            runButtonEnabled.Location = new Point(1076, 45);
            runButtonEnabled.Name = "runButtonEnabled";
            runButtonEnabled.Size = new Size(97, 37);
            runButtonEnabled.TabIndex = 1;
            runButtonEnabled.Text = "Run";
            runButtonEnabled.UseVisualStyleBackColor = true;
            runButtonEnabled.Click += button1_Click;
            // 
            // logsDisplayBox
            // 
            logsDisplayBox.BackColor = Color.FromArgb(192, 255, 255);
            logsDisplayBox.Location = new Point(701, 142);
            logsDisplayBox.Multiline = true;
            logsDisplayBox.Name = "logsDisplayBox";
            logsDisplayBox.ReadOnly = true;
            logsDisplayBox.Size = new Size(472, 312);
            logsDisplayBox.TabIndex = 2;
            logsDisplayBox.TextChanged += logsDisplayBox_TextChanged;
            // 
            // stopButtonEnabled
            // 
            stopButtonEnabled.Location = new Point(1076, 88);
            stopButtonEnabled.Name = "stopButtonEnabled";
            stopButtonEnabled.Size = new Size(97, 37);
            stopButtonEnabled.TabIndex = 3;
            stopButtonEnabled.Text = "Stop";
            stopButtonEnabled.UseVisualStyleBackColor = true;
            stopButtonEnabled.Visible = false;
            stopButtonEnabled.Click += stopButton_Click;
            // 
            // selectAll
            // 
            selectAll.AutoSize = true;
            selectAll.Location = new Point(43, 118);
            selectAll.Name = "selectAll";
            selectAll.Size = new Size(93, 24);
            selectAll.TabIndex = 4;
            selectAll.Text = "Select All";
            selectAll.UseVisualStyleBackColor = true;
            selectAll.CheckedChanged += selectAll_CheckedChanged;
            // 
            // welcomeTextBox
            // 
            welcomeTextBox.BackColor = Color.FromArgb(192, 255, 255);
            welcomeTextBox.Enabled = false;
            welcomeTextBox.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            welcomeTextBox.ForeColor = SystemColors.MenuText;
            welcomeTextBox.Location = new Point(701, 142);
            welcomeTextBox.Multiline = true;
            welcomeTextBox.Name = "welcomeTextBox";
            welcomeTextBox.Size = new Size(472, 312);
            welcomeTextBox.TabIndex = 5;
            welcomeTextBox.Text = "Select a test case . . .";
            // 
            // runButtonDisabled
            // 
            runButtonDisabled.BackColor = Color.LightGray;
            runButtonDisabled.Enabled = false;
            runButtonDisabled.Location = new Point(1076, 46);
            runButtonDisabled.Name = "runButtonDisabled";
            runButtonDisabled.Size = new Size(97, 36);
            runButtonDisabled.TabIndex = 6;
            runButtonDisabled.Text = "Run";
            runButtonDisabled.UseVisualStyleBackColor = false;
            // 
            // stopButtonDisabled
            // 
            stopButtonDisabled.BackColor = Color.LightGray;
            stopButtonDisabled.BackgroundImageLayout = ImageLayout.None;
            stopButtonDisabled.Enabled = false;
            stopButtonDisabled.Location = new Point(1076, 88);
            stopButtonDisabled.Name = "stopButtonDisabled";
            stopButtonDisabled.Size = new Size(97, 37);
            stopButtonDisabled.TabIndex = 7;
            stopButtonDisabled.Text = "Stop";
            stopButtonDisabled.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1213, 493);
            Controls.Add(welcomeTextBox);
            Controls.Add(selectAll);
            Controls.Add(stopButtonEnabled);
            Controls.Add(logsDisplayBox);
            Controls.Add(testCasesList);
            Controls.Add(runButtonEnabled);
            Controls.Add(runButtonDisabled);
            Controls.Add(stopButtonDisabled);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Curogram Automation Testing";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public CheckedListBox testCasesList;
        public Button runButtonEnabled;
        public TextBox logsDisplayBox;
        public Button stopButtonEnabled;
        public CheckBox selectAll;
        public TextBox welcomeTextBox;
        private Button runButtonDisabled;
        private Button stopButtonDisabled;
    }
}