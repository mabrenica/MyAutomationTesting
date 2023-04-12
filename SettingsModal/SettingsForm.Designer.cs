namespace SettingsModal
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonReset1 = new System.Windows.Forms.Button();
            this.environmentsBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maxParallelBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelCheckCredentials = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonResetStaging = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(447, 491);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 40);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(349, 491);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 40);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 473);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonReset1);
            this.tabPage1.Controls.Add(this.environmentsBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.maxParallelBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonReset1
            // 
            this.buttonReset1.Location = new System.Drawing.Point(6, 400);
            this.buttonReset1.Name = "buttonReset1";
            this.buttonReset1.Size = new System.Drawing.Size(69, 34);
            this.buttonReset1.TabIndex = 5;
            this.buttonReset1.Text = "Reset";
            this.buttonReset1.UseVisualStyleBackColor = true;
            this.buttonReset1.Click += new System.EventHandler(this.buttonDefault1_Click);
            // 
            // environmentsBox
            // 
            this.environmentsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.environmentsBox.Enabled = false;
            this.environmentsBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.environmentsBox.FormattingEnabled = true;
            this.environmentsBox.Items.AddRange(new object[] {
            "Development",
            "Staging",
            "Production"});
            this.environmentsBox.Location = new System.Drawing.Point(179, 44);
            this.environmentsBox.Name = "environmentsBox";
            this.environmentsBox.Size = new System.Drawing.Size(329, 28);
            this.environmentsBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Execution Environment";
            // 
            // maxParallelBox
            // 
            this.maxParallelBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.maxParallelBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.maxParallelBox.FormattingEnabled = true;
            this.maxParallelBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.maxParallelBox.Location = new System.Drawing.Point(179, 6);
            this.maxParallelBox.Name = "maxParallelBox";
            this.maxParallelBox.Size = new System.Drawing.Size(329, 28);
            this.maxParallelBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Max Parallel Run";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonResetStaging);
            this.tabPage2.Controls.Add(this.labelCheckCredentials);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBoxPassword);
            this.tabPage2.Controls.Add(this.textBoxUserEmail);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Staging";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelCheckCredentials
            // 
            this.labelCheckCredentials.AutoSize = true;
            this.labelCheckCredentials.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCheckCredentials.Location = new System.Drawing.Point(147, 97);
            this.labelCheckCredentials.Name = "labelCheckCredentials";
            this.labelCheckCredentials.Size = new System.Drawing.Size(0, 19);
            this.labelCheckCredentials.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(419, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPassword.Location = new System.Drawing.Point(147, 64);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(334, 27);
            this.textBoxPassword.TabIndex = 4;
            // 
            // textBoxUserEmail
            // 
            this.textBoxUserEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxUserEmail.Location = new System.Drawing.Point(147, 31);
            this.textBoxUserEmail.Name = "textBoxUserEmail";
            this.textBoxUserEmail.Size = new System.Drawing.Size(334, 27);
            this.textBoxUserEmail.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "User Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Provider Login Credentials";
            // 
            // buttonResetStaging
            // 
            this.buttonResetStaging.Location = new System.Drawing.Point(6, 400);
            this.buttonResetStaging.Name = "buttonResetStaging";
            this.buttonResetStaging.Size = new System.Drawing.Size(69, 34);
            this.buttonResetStaging.TabIndex = 7;
            this.buttonResetStaging.Text = "Reset";
            this.buttonResetStaging.UseVisualStyleBackColor = true;
            this.buttonResetStaging.Click += new System.EventHandler(this.buttonResetStaging_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 538);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private ComboBox maxParallelBox;
        private ComboBox environmentsBox;
        private Label label2;
        private Button buttonReset1;
        private TabPage tabPage2;
        private TextBox textBoxPassword;
        private TextBox textBoxUserEmail;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label labelCheckCredentials;
        private Button button1;
        private Button buttonResetStaging;
    }
}