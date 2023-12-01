namespace G1N_Font_Editor
{
    partial class MainForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.comboBoxFont = new System.Windows.Forms.ComboBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.labelBuildOptions = new System.Windows.Forms.Label();
            this.labelOptFont = new System.Windows.Forms.Label();
            this.comboBoxOptFont = new System.Windows.Forms.ComboBox();
            this.labelOptFontStyle = new System.Windows.Forms.Label();
            this.comboBoxOptFontStyle = new System.Windows.Forms.ComboBox();
            this.textBoxOptFontSize = new System.Windows.Forms.TextBox();
            this.labelOptFontSize = new System.Windows.Forms.Label();
            this.buttonBuild = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox.Location = new System.Drawing.Point(340, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(93, 30);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.Size = new System.Drawing.Size(236, 20);
            this.textBoxFilePath.TabIndex = 2;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(12, 10);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(81, 13);
            this.labelFilePath.TabIndex = 3;
            this.labelFilePath.Text = "Select G1N File";
            // 
            // comboBoxFont
            // 
            this.comboBoxFont.FormattingEnabled = true;
            this.comboBoxFont.Location = new System.Drawing.Point(12, 80);
            this.comboBoxFont.Name = "comboBoxFont";
            this.comboBoxFont.Size = new System.Drawing.Size(317, 21);
            this.comboBoxFont.TabIndex = 4;
            this.comboBoxFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxFont_SelectedIndexChanged);
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(12, 60);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(61, 13);
            this.labelFont.TabIndex = 5;
            this.labelFont.Text = "Select Font";
            // 
            // labelBuildOptions
            // 
            this.labelBuildOptions.AutoSize = true;
            this.labelBuildOptions.Location = new System.Drawing.Point(12, 115);
            this.labelBuildOptions.Name = "labelBuildOptions";
            this.labelBuildOptions.Size = new System.Drawing.Size(69, 13);
            this.labelBuildOptions.TabIndex = 6;
            this.labelBuildOptions.Text = "Build Options";
            // 
            // labelOptFont
            // 
            this.labelOptFont.AutoSize = true;
            this.labelOptFont.Location = new System.Drawing.Point(12, 140);
            this.labelOptFont.Name = "labelOptFont";
            this.labelOptFont.Size = new System.Drawing.Size(31, 13);
            this.labelOptFont.TabIndex = 7;
            this.labelOptFont.Text = "Font:";
            // 
            // comboBoxOptFont
            // 
            this.comboBoxOptFont.FormattingEnabled = true;
            this.comboBoxOptFont.Location = new System.Drawing.Point(49, 137);
            this.comboBoxOptFont.Name = "comboBoxOptFont";
            this.comboBoxOptFont.Size = new System.Drawing.Size(280, 21);
            this.comboBoxOptFont.TabIndex = 8;
            this.comboBoxOptFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxOptFont_SelectedIndexChanged);
            // 
            // labelOptFontStyle
            // 
            this.labelOptFontStyle.AutoSize = true;
            this.labelOptFontStyle.Location = new System.Drawing.Point(147, 175);
            this.labelOptFontStyle.Name = "labelOptFontStyle";
            this.labelOptFontStyle.Size = new System.Drawing.Size(36, 13);
            this.labelOptFontStyle.TabIndex = 64;
            this.labelOptFontStyle.Text = "Style: ";
            // 
            // comboBoxOptFontStyle
            // 
            this.comboBoxOptFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptFontStyle.FormattingEnabled = true;
            this.comboBoxOptFontStyle.Location = new System.Drawing.Point(189, 172);
            this.comboBoxOptFontStyle.Name = "comboBoxOptFontStyle";
            this.comboBoxOptFontStyle.Size = new System.Drawing.Size(140, 21);
            this.comboBoxOptFontStyle.TabIndex = 63;
            // 
            // textBoxOptFontSize
            // 
            this.textBoxOptFontSize.Location = new System.Drawing.Point(49, 172);
            this.textBoxOptFontSize.Name = "textBoxOptFontSize";
            this.textBoxOptFontSize.ShortcutsEnabled = false;
            this.textBoxOptFontSize.Size = new System.Drawing.Size(80, 20);
            this.textBoxOptFontSize.TabIndex = 62;
            // 
            // labelOptFontSize
            // 
            this.labelOptFontSize.AutoSize = true;
            this.labelOptFontSize.Location = new System.Drawing.Point(12, 175);
            this.labelOptFontSize.Name = "labelOptFontSize";
            this.labelOptFontSize.Size = new System.Drawing.Size(33, 13);
            this.labelOptFontSize.TabIndex = 61;
            this.labelOptFontSize.Text = "Size: ";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(12, 210);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(317, 23);
            this.buttonBuild.TabIndex = 65;
            this.buttonBuild.Text = "Build";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 541);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.labelOptFontStyle);
            this.Controls.Add(this.comboBoxOptFontStyle);
            this.Controls.Add(this.textBoxOptFontSize);
            this.Controls.Add(this.labelOptFontSize);
            this.Controls.Add(this.comboBoxOptFont);
            this.Controls.Add(this.labelOptFont);
            this.Controls.Add(this.labelBuildOptions);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.comboBoxFont);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.pictureBox);
            this.MinimumSize = new System.Drawing.Size(880, 580);
            this.Name = "MainForm";
            this.Text = "G1N Font Editor by LeHieu - VietHoaGame";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.ComboBox comboBoxFont;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelBuildOptions;
        private System.Windows.Forms.Label labelOptFont;
        private System.Windows.Forms.ComboBox comboBoxOptFont;
        private System.Windows.Forms.Label labelOptFontStyle;
        private System.Windows.Forms.ComboBox comboBoxOptFontStyle;
        private System.Windows.Forms.TextBox textBoxOptFontSize;
        private System.Windows.Forms.Label labelOptFontSize;
        private System.Windows.Forms.Button buttonBuild;
    }
}

