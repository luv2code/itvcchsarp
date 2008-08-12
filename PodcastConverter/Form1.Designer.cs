namespace PodcastConverter
{
    partial class Form1
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
            this.chkDeleteOriginals.Location = new System.Drawing.Point(232, 8);
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
            this.lstFeeds.Location = new System.Drawing.Point(12, 125);
            this.lstFeeds.Name = "lstFeeds";
            this.lstFeeds.Size = new System.Drawing.Size(403, 160);
            this.lstFeeds.TabIndex = 6;
            this.lstFeeds.SelectedIndexChanged += new System.EventHandler(this.lstFeeds_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Feeds";
            // 
            // txtFeedUrl
            // 
            this.txtFeedUrl.Location = new System.Drawing.Point(12, 316);
            this.txtFeedUrl.Name = "txtFeedUrl";
            this.txtFeedUrl.Size = new System.Drawing.Size(403, 20);
            this.txtFeedUrl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Feed URL";
            // 
            // btnFeedSave
            // 
            this.btnFeedSave.Location = new System.Drawing.Point(12, 343);
            this.btnFeedSave.Name = "btnFeedSave";
            this.btnFeedSave.Size = new System.Drawing.Size(75, 23);
            this.btnFeedSave.TabIndex = 10;
            this.btnFeedSave.Text = "Save Feed";
            this.btnFeedSave.UseVisualStyleBackColor = true;
            // 
            // btnAddFeed
            // 
            this.btnAddFeed.Location = new System.Drawing.Point(93, 343);
            this.btnAddFeed.Name = "btnAddFeed";
            this.btnAddFeed.Size = new System.Drawing.Size(75, 23);
            this.btnAddFeed.TabIndex = 11;
            this.btnAddFeed.Text = "Add Feed";
            this.btnAddFeed.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 424);
            this.Controls.Add(this.btnAddFeed);
            this.Controls.Add(this.btnFeedSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFeedUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstFeeds);
            this.Controls.Add(this.txtConvertFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkDeleteOriginals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDownloadFolder);
            this.Name = "Form1";
            this.Text = "ITVC Podcast Converter";
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

    }
}

