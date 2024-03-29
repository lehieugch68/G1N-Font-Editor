namespace G1N_Font_Editor.Components
{
    partial class AboutForm
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
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelThanks = new System.Windows.Forms.Label();
            this.labelAuthorValue = new System.Windows.Forms.Label();
            this.labelThanksValue1 = new System.Windows.Forms.Label();
            this.labelThanksValue2 = new System.Windows.Forms.Label();
            this.linkLabelPjRepository = new System.Windows.Forms.LinkLabel();
            this.linkLabelVHGForum = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.pictureBoxAboutImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAboutImg)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(20, 20);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Author:";
            // 
            // labelThanks
            // 
            this.labelThanks.AutoSize = true;
            this.labelThanks.Location = new System.Drawing.Point(20, 50);
            this.labelThanks.Name = "labelThanks";
            this.labelThanks.Size = new System.Drawing.Size(46, 13);
            this.labelThanks.TabIndex = 1;
            this.labelThanks.Text = "Thanks:";
            // 
            // labelAuthorValue
            // 
            this.labelAuthorValue.AutoSize = true;
            this.labelAuthorValue.Location = new System.Drawing.Point(100, 20);
            this.labelAuthorValue.Name = "labelAuthorValue";
            this.labelAuthorValue.Size = new System.Drawing.Size(44, 13);
            this.labelAuthorValue.TabIndex = 2;
            this.labelAuthorValue.Text = "Lê Hiếu";
            // 
            // labelThanksValue1
            // 
            this.labelThanksValue1.AutoSize = true;
            this.labelThanksValue1.Location = new System.Drawing.Point(100, 50);
            this.labelThanksValue1.Name = "labelThanksValue1";
            this.labelThanksValue1.Size = new System.Drawing.Size(43, 13);
            this.labelThanksValue1.TabIndex = 3;
            this.labelThanksValue1.Text = "oblivion";
            // 
            // labelThanksValue2
            // 
            this.labelThanksValue2.AutoSize = true;
            this.labelThanksValue2.Location = new System.Drawing.Point(100, 75);
            this.labelThanksValue2.Name = "labelThanksValue2";
            this.labelThanksValue2.Size = new System.Drawing.Size(51, 13);
            this.labelThanksValue2.TabIndex = 4;
            this.labelThanksValue2.Text = "haianh97";
            // 
            // linkLabelPjRepository
            // 
            this.linkLabelPjRepository.AutoSize = true;
            this.linkLabelPjRepository.Location = new System.Drawing.Point(20, 155);
            this.linkLabelPjRepository.Name = "linkLabelPjRepository";
            this.linkLabelPjRepository.Size = new System.Drawing.Size(93, 13);
            this.linkLabelPjRepository.TabIndex = 5;
            this.linkLabelPjRepository.TabStop = true;
            this.linkLabelPjRepository.Text = "Project Repository";
            this.linkLabelPjRepository.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelPjRepository_LinkClicked);
            // 
            // linkLabelVHGForum
            // 
            this.linkLabelVHGForum.AutoSize = true;
            this.linkLabelVHGForum.Location = new System.Drawing.Point(20, 180);
            this.linkLabelVHGForum.Name = "linkLabelVHGForum";
            this.linkLabelVHGForum.Size = new System.Drawing.Size(105, 13);
            this.linkLabelVHGForum.TabIndex = 6;
            this.linkLabelVHGForum.TabStop = true;
            this.linkLabelVHGForum.Text = "VietHoaGame Forum";
            this.linkLabelVHGForum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelVHGForum_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(300, 180);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(62, 13);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "Ver. 1.0.0.0";
            // 
            // pictureBoxAboutImg
            // 
            this.pictureBoxAboutImg.Location = new System.Drawing.Point(265, 15);
            this.pictureBoxAboutImg.Name = "pictureBoxAboutImg";
            this.pictureBoxAboutImg.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxAboutImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAboutImg.TabIndex = 7;
            this.pictureBoxAboutImg.TabStop = false;
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.pictureBoxAboutImg);
            this.Controls.Add(this.linkLabelVHGForum);
            this.Controls.Add(this.linkLabelPjRepository);
            this.Controls.Add(this.labelThanksValue2);
            this.Controls.Add(this.labelThanksValue1);
            this.Controls.Add(this.labelAuthorValue);
            this.Controls.Add(this.labelThanks);
            this.Controls.Add(this.labelAuthor);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "AboutForm";
            this.Text = "About";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AboutForm_FormClosing);
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAboutImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelThanks;
        private System.Windows.Forms.Label labelAuthorValue;
        private System.Windows.Forms.Label labelThanksValue1;
        private System.Windows.Forms.Label labelThanksValue2;
        private System.Windows.Forms.LinkLabel linkLabelPjRepository;
        private System.Windows.Forms.LinkLabel linkLabelVHGForum;
        private System.Windows.Forms.PictureBox pictureBoxAboutImg;
        private System.Windows.Forms.Label labelVersion;
    }
}