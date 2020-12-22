namespace BarcodeReaderSample.Forms
{
    partial class SettingsForm
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
            this.CameraPreviewLabel = new System.Windows.Forms.Label();
            this.CameraComboBox = new System.Windows.Forms.ComboBox();
            this.AppLogoTitle = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.CameraComboBoxLabel = new System.Windows.Forms.Label();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.CSVDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.CSVCheckBox = new System.Windows.Forms.CheckBox();
            this.CSVGroupBox = new System.Windows.Forms.GroupBox();
            this.ClipboardCheckBox = new System.Windows.Forms.CheckBox();
            this.BarcodeDataLabel = new System.Windows.Forms.Label();
            this.IsMirrorCheckBox = new System.Windows.Forms.CheckBox();
            this.CSVGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CameraPreviewLabel
            // 
            this.CameraPreviewLabel.AutoSize = true;
            this.CameraPreviewLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.CameraPreviewLabel.Location = new System.Drawing.Point(20, 15);
            this.CameraPreviewLabel.Name = "CameraPreviewLabel";
            this.CameraPreviewLabel.Size = new System.Drawing.Size(47, 15);
            this.CameraPreviewLabel.TabIndex = 1;
            this.CameraPreviewLabel.Text = "Camera";
            // 
            // CameraComboBox
            // 
            this.CameraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CameraComboBox.FormattingEnabled = true;
            this.CameraComboBox.Location = new System.Drawing.Point(23, 174);
            this.CameraComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CameraComboBox.Name = "CameraComboBox";
            this.CameraComboBox.Size = new System.Drawing.Size(120, 20);
            this.CameraComboBox.TabIndex = 4;
            this.CameraComboBox.SelectionChangeCommitted += new System.EventHandler(this.CameraComboBox_SelectionChangeCommitted);
            // 
            // AppLogoTitle
            // 
            this.AppLogoTitle.AutoSize = true;
            this.AppLogoTitle.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Italic);
            this.AppLogoTitle.Location = new System.Drawing.Point(231, 181);
            this.AppLogoTitle.Name = "AppLogoTitle";
            this.AppLogoTitle.Size = new System.Drawing.Size(151, 21);
            this.AppLogoTitle.TabIndex = 10;
            this.AppLogoTitle.Text = "Barcode Reader Tool";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Italic);
            this.VersionLabel.Location = new System.Drawing.Point(297, 198);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VersionLabel.Size = new System.Drawing.Size(72, 15);
            this.VersionLabel.TabIndex = 11;
            this.VersionLabel.Text = "Version 1.0.0";
            // 
            // CameraComboBoxLabel
            // 
            this.CameraComboBoxLabel.AutoSize = true;
            this.CameraComboBoxLabel.Location = new System.Drawing.Point(21, 160);
            this.CameraComboBoxLabel.Name = "CameraComboBoxLabel";
            this.CameraComboBoxLabel.Size = new System.Drawing.Size(83, 12);
            this.CameraComboBoxLabel.TabIndex = 12;
            this.CameraComboBoxLabel.Text = "Default camera";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Location = new System.Drawing.Point(23, 32);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(120, 120);
            this.videoSourcePlayer1.TabIndex = 15;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 18);
            this.button1.TabIndex = 17;
            this.button1.Text = "Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // CSVDirectoryTextBox
            // 
            this.CSVDirectoryTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.CSVDirectoryTextBox.Location = new System.Drawing.Point(6, 39);
            this.CSVDirectoryTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CSVDirectoryTextBox.Name = "CSVDirectoryTextBox";
            this.CSVDirectoryTextBox.ReadOnly = true;
            this.CSVDirectoryTextBox.Size = new System.Drawing.Size(173, 19);
            this.CSVDirectoryTextBox.TabIndex = 18;
            // 
            // CSVCheckBox
            // 
            this.CSVCheckBox.AutoSize = true;
            this.CSVCheckBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CSVCheckBox.Location = new System.Drawing.Point(187, 37);
            this.CSVCheckBox.Name = "CSVCheckBox";
            this.CSVCheckBox.Size = new System.Drawing.Size(90, 19);
            this.CSVCheckBox.TabIndex = 19;
            this.CSVCheckBox.Text = "Save to CSV";
            this.CSVCheckBox.UseVisualStyleBackColor = true;
            this.CSVCheckBox.Click += new System.EventHandler(this.CSVCheckBox_Click);
            // 
            // CSVGroupBox
            // 
            this.CSVGroupBox.Controls.Add(this.CSVDirectoryTextBox);
            this.CSVGroupBox.Controls.Add(this.button1);
            this.CSVGroupBox.Location = new System.Drawing.Point(197, 64);
            this.CSVGroupBox.Name = "CSVGroupBox";
            this.CSVGroupBox.Size = new System.Drawing.Size(185, 70);
            this.CSVGroupBox.TabIndex = 20;
            this.CSVGroupBox.TabStop = false;
            this.CSVGroupBox.Text = "Directory";
            // 
            // ClipboardCheckBox
            // 
            this.ClipboardCheckBox.AutoSize = true;
            this.ClipboardCheckBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClipboardCheckBox.Location = new System.Drawing.Point(187, 140);
            this.ClipboardCheckBox.Name = "ClipboardCheckBox";
            this.ClipboardCheckBox.Size = new System.Drawing.Size(120, 19);
            this.ClipboardCheckBox.TabIndex = 21;
            this.ClipboardCheckBox.Text = "Copy to clipboard";
            this.ClipboardCheckBox.UseVisualStyleBackColor = true;
            this.ClipboardCheckBox.Click += new System.EventHandler(this.ClipboardCheckBox_Click);
            // 
            // BarcodeDataLabel
            // 
            this.BarcodeDataLabel.AutoSize = true;
            this.BarcodeDataLabel.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.BarcodeDataLabel.Location = new System.Drawing.Point(184, 15);
            this.BarcodeDataLabel.Name = "BarcodeDataLabel";
            this.BarcodeDataLabel.Size = new System.Drawing.Size(76, 15);
            this.BarcodeDataLabel.TabIndex = 22;
            this.BarcodeDataLabel.Text = "Barcode data";
            // 
            // IsMirrorCheckBox
            // 
            this.IsMirrorCheckBox.AutoSize = true;
            this.IsMirrorCheckBox.Location = new System.Drawing.Point(89, 199);
            this.IsMirrorCheckBox.Name = "IsMirrorCheckBox";
            this.IsMirrorCheckBox.Size = new System.Drawing.Size(54, 16);
            this.IsMirrorCheckBox.TabIndex = 23;
            this.IsMirrorCheckBox.Text = "Mirror";
            this.IsMirrorCheckBox.UseVisualStyleBackColor = true;
            this.IsMirrorCheckBox.Click += new System.EventHandler(this.IsMirrorCheckBox_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 225);
            this.Controls.Add(this.IsMirrorCheckBox);
            this.Controls.Add(this.BarcodeDataLabel);
            this.Controls.Add(this.ClipboardCheckBox);
            this.Controls.Add(this.CSVGroupBox);
            this.Controls.Add(this.CSVCheckBox);
            this.Controls.Add(this.videoSourcePlayer1);
            this.Controls.Add(this.CameraComboBoxLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.AppLogoTitle);
            this.Controls.Add(this.CameraComboBox);
            this.Controls.Add(this.CameraPreviewLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.CSVGroupBox.ResumeLayout(false);
            this.CSVGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label CameraPreviewLabel;
        private System.Windows.Forms.ComboBox CameraComboBox;
        private System.Windows.Forms.Label AppLogoTitle;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label CameraComboBoxLabel;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox CSVDirectoryTextBox;
        private System.Windows.Forms.CheckBox CSVCheckBox;
        private System.Windows.Forms.GroupBox CSVGroupBox;
        private System.Windows.Forms.CheckBox ClipboardCheckBox;
        private System.Windows.Forms.Label BarcodeDataLabel;
        private System.Windows.Forms.CheckBox IsMirrorCheckBox;
    }
}