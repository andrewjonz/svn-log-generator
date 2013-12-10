namespace Release_Note_Generator
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.TextFileOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.HeadingLabel = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.FileDetailsLabel = new System.Windows.Forms.Label();
            this.FileDetailsLabel1 = new System.Windows.Forms.Label();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.FileDetailsLabel2 = new System.Windows.Forms.Label();
            this.OrLabel = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.EnterFreeTextButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SvnRadioButton = new System.Windows.Forms.RadioButton();
            this.TFSRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // TextFileOpenFileDialog
            // 
            this.TextFileOpenFileDialog.FileName = "openFileDialog1";
            // 
            // HeadingLabel
            // 
            this.HeadingLabel.AutoSize = true;
            this.HeadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.HeadingLabel.ForeColor = System.Drawing.Color.White;
            this.HeadingLabel.Location = new System.Drawing.Point(128, 24);
            this.HeadingLabel.Name = "HeadingLabel";
            this.HeadingLabel.Size = new System.Drawing.Size(101, 13);
            this.HeadingLabel.TabIndex = 1;
            this.HeadingLabel.Text = "Choose the file here";
            // 
            // BrowseButton
            // 
            this.BrowseButton.BackColor = System.Drawing.Color.Transparent;
            this.BrowseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BrowseButton.Location = new System.Drawing.Point(235, 19);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // FileDetailsLabel
            // 
            this.FileDetailsLabel.AutoSize = true;
            this.FileDetailsLabel.BackColor = System.Drawing.Color.Transparent;
            this.FileDetailsLabel.ForeColor = System.Drawing.Color.White;
            this.FileDetailsLabel.Location = new System.Drawing.Point(42, 64);
            this.FileDetailsLabel.Name = "FileDetailsLabel";
            this.FileDetailsLabel.Size = new System.Drawing.Size(0, 13);
            this.FileDetailsLabel.TabIndex = 3;
            // 
            // FileDetailsLabel1
            // 
            this.FileDetailsLabel1.AutoSize = true;
            this.FileDetailsLabel1.BackColor = System.Drawing.Color.Transparent;
            this.FileDetailsLabel1.ForeColor = System.Drawing.Color.White;
            this.FileDetailsLabel1.Location = new System.Drawing.Point(42, 82);
            this.FileDetailsLabel1.Name = "FileDetailsLabel1";
            this.FileDetailsLabel1.Size = new System.Drawing.Size(0, 13);
            this.FileDetailsLabel1.TabIndex = 4;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.GenerateButton.Location = new System.Drawing.Point(170, 120);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(138, 23);
            this.GenerateButton.TabIndex = 5;
            this.GenerateButton.Text = "Generate ExcelSheet";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // FileDetailsLabel2
            // 
            this.FileDetailsLabel2.AutoSize = true;
            this.FileDetailsLabel2.BackColor = System.Drawing.Color.Transparent;
            this.FileDetailsLabel2.ForeColor = System.Drawing.Color.White;
            this.FileDetailsLabel2.Location = new System.Drawing.Point(42, 99);
            this.FileDetailsLabel2.Name = "FileDetailsLabel2";
            this.FileDetailsLabel2.Size = new System.Drawing.Size(0, 13);
            this.FileDetailsLabel2.TabIndex = 6;
            // 
            // OrLabel
            // 
            this.OrLabel.AutoSize = true;
            this.OrLabel.BackColor = System.Drawing.Color.Transparent;
            this.OrLabel.ForeColor = System.Drawing.Color.White;
            this.OrLabel.Location = new System.Drawing.Point(316, 24);
            this.OrLabel.Name = "OrLabel";
            this.OrLabel.Size = new System.Drawing.Size(16, 13);
            this.OrLabel.TabIndex = 7;
            this.OrLabel.Text = "or";
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.Black;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox.ForeColor = System.Drawing.Color.White;
            this.richTextBox.Location = new System.Drawing.Point(12, 61);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(450, 275);
            this.richTextBox.TabIndex = 9;
            this.richTextBox.Text = "";
            this.richTextBox.Visible = false;
            this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.BackColor = System.Drawing.Color.Transparent;
            this.ClearLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ClearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearLabel.ForeColor = System.Drawing.Color.White;
            this.ClearLabel.Location = new System.Drawing.Point(393, 45);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(69, 13);
            this.ClearLabel.TabIndex = 10;
            this.ClearLabel.Text = "Clear All Text";
            this.ClearLabel.Visible = false;
            this.ClearLabel.Click += new System.EventHandler(this.ClearLabel_Click_1);
            // 
            // EnterFreeTextButton
            // 
            this.EnterFreeTextButton.Location = new System.Drawing.Point(338, 19);
            this.EnterFreeTextButton.Name = "EnterFreeTextButton";
            this.EnterFreeTextButton.Size = new System.Drawing.Size(94, 23);
            this.EnterFreeTextButton.TabIndex = 11;
            this.EnterFreeTextButton.Text = "Enter Free Text";
            this.EnterFreeTextButton.UseVisualStyleBackColor = true;
            this.EnterFreeTextButton.Click += new System.EventHandler(this.EnterFreeTextButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 150);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(350, 1);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // SvnRadioButton
            // 
            this.SvnRadioButton.AutoSize = true;
            this.SvnRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.SvnRadioButton.Checked = true;
            this.SvnRadioButton.ForeColor = System.Drawing.Color.White;
            this.SvnRadioButton.Location = new System.Drawing.Point(24, 22);
            this.SvnRadioButton.Name = "SvnRadioButton";
            this.SvnRadioButton.Size = new System.Drawing.Size(44, 17);
            this.SvnRadioButton.TabIndex = 13;
            this.SvnRadioButton.TabStop = true;
            this.SvnRadioButton.Text = "Svn";
            this.SvnRadioButton.UseVisualStyleBackColor = false;
            this.SvnRadioButton.CheckedChanged += new System.EventHandler(this.SvnRadioButton_CheckedChanged);
            // 
            // TFSRadioButton
            // 
            this.TFSRadioButton.AutoSize = true;
            this.TFSRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.TFSRadioButton.ForeColor = System.Drawing.Color.White;
            this.TFSRadioButton.Location = new System.Drawing.Point(74, 22);
            this.TFSRadioButton.Name = "TFSRadioButton";
            this.TFSRadioButton.Size = new System.Drawing.Size(45, 17);
            this.TFSRadioButton.TabIndex = 13;
            this.TFSRadioButton.Text = "TFS";
            this.TFSRadioButton.UseVisualStyleBackColor = false;
            this.TFSRadioButton.CheckedChanged += new System.EventHandler(this.TFSRadioButton_CheckedChanged);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Release_Note_Generator.Properties.Resources.wood;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(474, 72);
            this.Controls.Add(this.TFSRadioButton);
            this.Controls.Add(this.SvnRadioButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.EnterFreeTextButton);
            this.Controls.Add(this.ClearLabel);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.OrLabel);
            this.Controls.Add(this.FileDetailsLabel2);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.FileDetailsLabel1);
            this.Controls.Add(this.FileDetailsLabel);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.HeadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Home";
            this.Text = "ReleaseNoteGenerator";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog TextFileOpenFileDialog;
        private System.Windows.Forms.Label HeadingLabel;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label FileDetailsLabel;
        private System.Windows.Forms.Label FileDetailsLabel1;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Label FileDetailsLabel2;
        private System.Windows.Forms.Label OrLabel;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.Button EnterFreeTextButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton SvnRadioButton;
        private System.Windows.Forms.RadioButton TFSRadioButton;
    }
}

