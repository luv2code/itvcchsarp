namespace PodcastConverter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.txtDownloadFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDeleteOriginals = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConvertFolder = new System.Windows.Forms.TextBox();
            this.lstFeeds = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFeedUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFeedSave = new System.Windows.Forms.Button();
            this.btnAddFeed = new System.Windows.Forms.Button();
            this.SysTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mnuSystray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuShowSettingsForm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNumberItems = new System.Windows.Forms.ComboBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFeedDelete = new System.Windows.Forms.Button();
            this.mnuSystray.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDownloadFolder
            // 
            this.txtDownloadFolder.Location = new System.Drawing.Point(12, 25);
            this.txtDownloadFolder.Name = "txtDownloadFolder";
            this.txtDownloadFolder.Size = new System.Drawing.Size(403, 20);
            this.txtDownloadFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Download to";
            // 
            // chkDeleteOriginals
            // 
            this.chkDeleteOriginals.AutoSize = true;
            this.chkDeleteOriginals.Location = new System.Drawing.Point(232, 57);
            this.chkDeleteOriginals.Name = "chkDeleteOriginals";
            this.chkDeleteOriginals.Size = new System.Drawing.Size(183, 17);
            this.chkDeleteOriginals.TabIndex = 3;
            this.chkDeleteOriginals.Text = "Delete originals after conversion?";
            this.chkDeleteOriginals.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Store converted files to";
            // 
            // txtConvertFolder
            // 
            this.txtConvertFolder.Location = new System.Drawing.Point(12, 74);
            this.txtConvertFolder.Name = "txtConvertFolder";
            this.txtConvertFolder.Size = new System.Drawing.Size(403, 20);
            this.txtConvertFolder.TabIndex = 5;
            // 
            // lstFeeds
            // 
            this.lstFeeds.FormattingEnabled = true;
            this.lstFeeds.Location = new System.Drawing.Point(3, 3);
            this.lstFeeds.Name = "lstFeeds";
            this.lstFeeds.Size = new System.Drawing.Size(390, 186);
            this.lstFeeds.TabIndex = 6;
            this.lstFeeds.SelectedIndexChanged += new System.EventHandler(this.lstFeeds_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Feeds";
            // 
            // txtFeedUrl
            // 
            this.txtFeedUrl.Location = new System.Drawing.Point(6, 214);
            this.txtFeedUrl.Name = "txtFeedUrl";
            this.txtFeedUrl.Size = new System.Drawing.Size(387, 20);
            this.txtFeedUrl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Feed URL";
            // 
            // btnFeedSave
            // 
            this.btnFeedSave.Location = new System.Drawing.Point(6, 267);
            this.btnFeedSave.Name = "btnFeedSave";
            this.btnFeedSave.Size = new System.Drawing.Size(75, 23);
            this.btnFeedSave.TabIndex = 10;
            this.btnFeedSave.Text = "Save Feed";
            this.btnFeedSave.UseVisualStyleBackColor = true;
            this.btnFeedSave.Click += new System.EventHandler(this.btnFeedSave_Click);
            // 
            // btnAddFeed
            // 
            this.btnAddFeed.Location = new System.Drawing.Point(86, 267);
            this.btnAddFeed.Name = "btnAddFeed";
            this.btnAddFeed.Size = new System.Drawing.Size(75, 23);
            this.btnAddFeed.TabIndex = 11;
            this.btnAddFeed.Text = "Add Feed";
            this.btnAddFeed.UseVisualStyleBackColor = true;
            this.btnAddFeed.Click += new System.EventHandler(this.btnAddFeed_Click);
            // 
            // SysTrayIcon
            // 
            this.SysTrayIcon.ContextMenuStrip = this.mnuSystray;
            this.SysTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("SysTrayIcon.Icon")));
            this.SysTrayIcon.Text = "Podcast Converter";
            this.SysTrayIcon.Visible = true;
            // 
            // mnuSystray
            // 
            this.mnuSystray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuShowSettingsForm,
            this.mnuExit});
            this.mnuSystray.Name = "mnuSystray";
            this.mnuSystray.Size = new System.Drawing.Size(125, 48);
            // 
            // mnuShowSettingsForm
            // 
            this.mnuShowSettingsForm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuShowSettingsForm.Name = "mnuShowSettingsForm";
            this.mnuShowSettingsForm.Size = new System.Drawing.Size(124, 22);
            this.mnuShowSettingsForm.Text = "Settings";
            this.mnuShowSettingsForm.Click += new System.EventHandler(this.mnuShowSettingsForm_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(124, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Max number of new items to download";
            // 
            // cboNumberItems
            // 
            this.cboNumberItems.FormattingEnabled = true;
            this.cboNumberItems.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cboNumberItems.Location = new System.Drawing.Point(6, 240);
            this.cboNumberItems.Name = "cboNumberItems";
            this.cboNumberItems.Size = new System.Drawing.Size(71, 21);
            this.cboNumberItems.TabIndex = 14;
            this.cboNumberItems.Text = "1";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(13, 433);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(186, 23);
            this.btnSaveSettings.TabIndex = 15;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFeedDelete);
            this.panel1.Controls.Add(this.lstFeeds);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnAddFeed);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboNumberItems);
            this.panel1.Controls.Add(this.btnFeedSave);
            this.panel1.Controls.Add(this.txtFeedUrl);
            this.panel1.Location = new System.Drawing.Point(17, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 298);
            this.panel1.TabIndex = 16;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(217, 433);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(198, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFeedDelete
            // 
            this.btnFeedDelete.Location = new System.Drawing.Point(167, 267);
            this.btnFeedDelete.Name = "btnFeedDelete";
            this.btnFeedDelete.Size = new System.Drawing.Size(75, 23);
            this.btnFeedDelete.TabIndex = 15;
            this.btnFeedDelete.Text = "Delete Feed";
            this.btnFeedDelete.UseVisualStyleBackColor = true;
            this.btnFeedDelete.Click += new System.EventHandler(this.btnFeedDelete_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 478);
            this.Controls.Add(this.txtConvertFolder);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkDeleteOriginals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDownloadFolder);
            this.Name = "SettingsForm";
            this.Text = "ITVC Podcast Converter";
            this.mnuSystray.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDownloadFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDeleteOriginals;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConvertFolder;
        private System.Windows.Forms.ListBox lstFeeds;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFeedUrl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFeedSave;
        private System.Windows.Forms.Button btnAddFeed;
        private System.Windows.Forms.NotifyIcon SysTrayIcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboNumberItems;
        private System.Windows.Forms.ContextMenuStrip mnuSystray;
        private System.Windows.Forms.ToolStripMenuItem mnuShowSettingsForm;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFeedDelete;

    }
}

