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
            runButton = new Button();
            logsDisplay = new TextBox();
            stopButton = new Button();
            fontDialog1 = new FontDialog();
            fontDialog2 = new FontDialog();
            selectAll = new CheckBox();
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
            // runButton
            // 
            runButton.Location = new Point(1076, 45);
            runButton.Name = "runButton";
            runButton.Size = new Size(97, 37);
            runButton.TabIndex = 1;
            runButton.Text = "Run";
            runButton.UseVisualStyleBackColor = true;
            runButton.Click += button1_Click;
            // 
            // logsDisplay
            // 
            logsDisplay.BackColor = Color.FromArgb(192, 255, 255);
            logsDisplay.Enabled = false;
            logsDisplay.Location = new Point(701, 142);
            logsDisplay.Multiline = true;
            logsDisplay.Name = "logsDisplay";
            logsDisplay.ReadOnly = true;
            logsDisplay.Size = new Size(472, 312);
            logsDisplay.TabIndex = 2;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(1076, 88);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(97, 37);
            stopButton.TabIndex = 3;
            stopButton.Text = "Stop";
            stopButton.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1213, 493);
            Controls.Add(selectAll);
            Controls.Add(stopButton);
            Controls.Add(logsDisplay);
            Controls.Add(runButton);
            Controls.Add(testCasesList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Curogram Automation Testing";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox testCasesList;
        private Button runButton;
        private TextBox logsDisplay;
        private Button stopButton;
        private FontDialog fontDialog1;
        private FontDialog fontDialog2;
        private CheckBox selectAll;
    }
}