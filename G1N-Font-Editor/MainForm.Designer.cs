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
            this.components = new System.ComponentModel.Container();
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
            this.labelCharsOpt = new System.Windows.Forms.Label();
            this.textBoxCharsOpt = new System.Windows.Forms.TextBox();
            this.buttonCharsFromFile = new System.Windows.Forms.Button();
            this.textBoxOptFontPath = new System.Windows.Forms.TextBox();
            this.buttonOptFontFromFile = new System.Windows.Forms.Button();
            this.labelGlyphOpt = new System.Windows.Forms.Label();
            this.labelOptBaseline = new System.Windows.Forms.Label();
            this.textBoxOptBaseline = new System.Windows.Forms.TextBox();
            this.textBoxOptLeftSide = new System.Windows.Forms.TextBox();
            this.labelOptLeftSide = new System.Windows.Forms.Label();
            this.textBoxOptAdvWidth = new System.Windows.Forms.TextBox();
            this.labelOptAdvWidth = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxOptPalette = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.contextMenuGlyph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuGlyphExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGlyphImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripGlyphSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuGlyphMetrics = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptPalette)).BeginInit();
            this.contextMenuGlyph.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox.Location = new System.Drawing.Point(340, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(12, 28);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(70, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(88, 30);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(241, 20);
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
            this.labelBuildOptions.Size = new System.Drawing.Size(67, 13);
            this.labelBuildOptions.TabIndex = 6;
            this.labelBuildOptions.Text = "Font Options";
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
            this.comboBoxOptFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxOptFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxOptFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptFont.FormattingEnabled = true;
            this.comboBoxOptFont.Location = new System.Drawing.Point(88, 137);
            this.comboBoxOptFont.Name = "comboBoxOptFont";
            this.comboBoxOptFont.Size = new System.Drawing.Size(241, 21);
            this.comboBoxOptFont.TabIndex = 8;
            this.comboBoxOptFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxOptFont_SelectedIndexChanged);
            // 
            // labelOptFontStyle
            // 
            this.labelOptFontStyle.AutoSize = true;
            this.labelOptFontStyle.Location = new System.Drawing.Point(187, 198);
            this.labelOptFontStyle.Name = "labelOptFontStyle";
            this.labelOptFontStyle.Size = new System.Drawing.Size(36, 13);
            this.labelOptFontStyle.TabIndex = 64;
            this.labelOptFontStyle.Text = "Style: ";
            // 
            // comboBoxOptFontStyle
            // 
            this.comboBoxOptFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptFontStyle.FormattingEnabled = true;
            this.comboBoxOptFontStyle.Location = new System.Drawing.Point(229, 195);
            this.comboBoxOptFontStyle.Name = "comboBoxOptFontStyle";
            this.comboBoxOptFontStyle.Size = new System.Drawing.Size(100, 21);
            this.comboBoxOptFontStyle.TabIndex = 63;
            // 
            // textBoxOptFontSize
            // 
            this.textBoxOptFontSize.Location = new System.Drawing.Point(88, 195);
            this.textBoxOptFontSize.Name = "textBoxOptFontSize";
            this.textBoxOptFontSize.ShortcutsEnabled = false;
            this.textBoxOptFontSize.Size = new System.Drawing.Size(80, 20);
            this.textBoxOptFontSize.TabIndex = 62;
            // 
            // labelOptFontSize
            // 
            this.labelOptFontSize.AutoSize = true;
            this.labelOptFontSize.Location = new System.Drawing.Point(12, 198);
            this.labelOptFontSize.Name = "labelOptFontSize";
            this.labelOptFontSize.Size = new System.Drawing.Size(33, 13);
            this.labelOptFontSize.TabIndex = 61;
            this.labelOptFontSize.Text = "Size: ";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(12, 475);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(317, 23);
            this.buttonBuild.TabIndex = 65;
            this.buttonBuild.Text = "Build From TrueType Font";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // labelCharsOpt
            // 
            this.labelCharsOpt.AutoSize = true;
            this.labelCharsOpt.Location = new System.Drawing.Point(12, 230);
            this.labelCharsOpt.Name = "labelCharsOpt";
            this.labelCharsOpt.Size = new System.Drawing.Size(59, 13);
            this.labelCharsOpt.TabIndex = 66;
            this.labelCharsOpt.Text = "Add Chars:";
            // 
            // textBoxCharsOpt
            // 
            this.textBoxCharsOpt.Location = new System.Drawing.Point(88, 227);
            this.textBoxCharsOpt.Multiline = true;
            this.textBoxCharsOpt.Name = "textBoxCharsOpt";
            this.textBoxCharsOpt.Size = new System.Drawing.Size(241, 20);
            this.textBoxCharsOpt.TabIndex = 67;
            // 
            // buttonCharsFromFile
            // 
            this.buttonCharsFromFile.Location = new System.Drawing.Point(199, 253);
            this.buttonCharsFromFile.Name = "buttonCharsFromFile";
            this.buttonCharsFromFile.Size = new System.Drawing.Size(130, 23);
            this.buttonCharsFromFile.TabIndex = 68;
            this.buttonCharsFromFile.Text = "Select Chars From File";
            this.buttonCharsFromFile.UseVisualStyleBackColor = true;
            this.buttonCharsFromFile.Click += new System.EventHandler(this.buttonCharsFromFile_Click);
            // 
            // textBoxOptFontPath
            // 
            this.textBoxOptFontPath.Location = new System.Drawing.Point(88, 164);
            this.textBoxOptFontPath.Name = "textBoxOptFontPath";
            this.textBoxOptFontPath.ReadOnly = true;
            this.textBoxOptFontPath.Size = new System.Drawing.Size(241, 20);
            this.textBoxOptFontPath.TabIndex = 70;
            // 
            // buttonOptFontFromFile
            // 
            this.buttonOptFontFromFile.Location = new System.Drawing.Point(12, 162);
            this.buttonOptFontFromFile.Name = "buttonOptFontFromFile";
            this.buttonOptFontFromFile.Size = new System.Drawing.Size(70, 23);
            this.buttonOptFontFromFile.TabIndex = 69;
            this.buttonOptFontFromFile.Text = "Select";
            this.buttonOptFontFromFile.UseVisualStyleBackColor = true;
            this.buttonOptFontFromFile.Click += new System.EventHandler(this.buttonOptFontFromFile_Click);
            // 
            // labelGlyphOpt
            // 
            this.labelGlyphOpt.AutoSize = true;
            this.labelGlyphOpt.Location = new System.Drawing.Point(12, 275);
            this.labelGlyphOpt.Name = "labelGlyphOpt";
            this.labelGlyphOpt.Size = new System.Drawing.Size(73, 13);
            this.labelGlyphOpt.TabIndex = 71;
            this.labelGlyphOpt.Text = "Glyph Options";
            // 
            // labelOptBaseline
            // 
            this.labelOptBaseline.AutoSize = true;
            this.labelOptBaseline.Location = new System.Drawing.Point(12, 300);
            this.labelOptBaseline.Name = "labelOptBaseline";
            this.labelOptBaseline.Size = new System.Drawing.Size(110, 13);
            this.labelOptBaseline.TabIndex = 72;
            this.labelOptBaseline.Text = "Add Custom Baseline:";
            // 
            // textBoxOptBaseline
            // 
            this.textBoxOptBaseline.Location = new System.Drawing.Point(169, 297);
            this.textBoxOptBaseline.Name = "textBoxOptBaseline";
            this.textBoxOptBaseline.ShortcutsEnabled = false;
            this.textBoxOptBaseline.Size = new System.Drawing.Size(160, 20);
            this.textBoxOptBaseline.TabIndex = 73;
            // 
            // textBoxOptLeftSide
            // 
            this.textBoxOptLeftSide.Location = new System.Drawing.Point(169, 323);
            this.textBoxOptLeftSide.Name = "textBoxOptLeftSide";
            this.textBoxOptLeftSide.ShortcutsEnabled = false;
            this.textBoxOptLeftSide.Size = new System.Drawing.Size(160, 20);
            this.textBoxOptLeftSide.TabIndex = 75;
            // 
            // labelOptLeftSide
            // 
            this.labelOptLeftSide.AutoSize = true;
            this.labelOptLeftSide.Location = new System.Drawing.Point(12, 326);
            this.labelOptLeftSide.Name = "labelOptLeftSide";
            this.labelOptLeftSide.Size = new System.Drawing.Size(109, 13);
            this.labelOptLeftSide.TabIndex = 74;
            this.labelOptLeftSide.Text = "Add Custom LeftSide:";
            // 
            // textBoxOptAdvWidth
            // 
            this.textBoxOptAdvWidth.Location = new System.Drawing.Point(169, 349);
            this.textBoxOptAdvWidth.Name = "textBoxOptAdvWidth";
            this.textBoxOptAdvWidth.ShortcutsEnabled = false;
            this.textBoxOptAdvWidth.Size = new System.Drawing.Size(160, 20);
            this.textBoxOptAdvWidth.TabIndex = 77;
            // 
            // labelOptAdvWidth
            // 
            this.labelOptAdvWidth.AutoSize = true;
            this.labelOptAdvWidth.Location = new System.Drawing.Point(12, 352);
            this.labelOptAdvWidth.Name = "labelOptAdvWidth";
            this.labelOptAdvWidth.Size = new System.Drawing.Size(141, 13);
            this.labelOptAdvWidth.TabIndex = 76;
            this.labelOptAdvWidth.Text = "Add Custom AdvanceWidth:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Palettes";
            // 
            // pictureBoxOptPalette
            // 
            this.pictureBoxOptPalette.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxOptPalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOptPalette.Location = new System.Drawing.Point(12, 400);
            this.pictureBoxOptPalette.Name = "pictureBoxOptPalette";
            this.pictureBoxOptPalette.Size = new System.Drawing.Size(317, 40);
            this.pictureBoxOptPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOptPalette.TabIndex = 79;
            this.pictureBoxOptPalette.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 501);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(317, 23);
            this.buttonSave.TabIndex = 80;
            this.buttonSave.Text = "Save As G1N";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // contextMenuGlyph
            // 
            this.contextMenuGlyph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGlyphSeparator,
            this.toolStripMenuGlyphImport,
            this.toolStripMenuGlyphExport,
            this.toolStripMenuGlyphMetrics});
            this.contextMenuGlyph.Name = "contextMenuGlyph";
            this.contextMenuGlyph.Size = new System.Drawing.Size(114, 76);
            // 
            // toolStripMenuGlyphExport
            // 
            this.toolStripMenuGlyphExport.Name = "toolStripMenuGlyphExport";
            this.toolStripMenuGlyphExport.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphExport.Text = "Export";
            this.toolStripMenuGlyphExport.Click += new System.EventHandler(this.toolStripMenuGlyphExport_Click);
            // 
            // toolStripMenuGlyphImport
            // 
            this.toolStripMenuGlyphImport.Name = "toolStripMenuGlyphImport";
            this.toolStripMenuGlyphImport.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphImport.Text = "Import";
            this.toolStripMenuGlyphImport.Click += new System.EventHandler(this.toolStripMenuGlyphImport_Click);
            // 
            // toolStripGlyphSeparator
            // 
            this.toolStripGlyphSeparator.Name = "toolStripGlyphSeparator";
            this.toolStripGlyphSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuGlyphMetrics
            // 
            this.toolStripMenuGlyphMetrics.Name = "toolStripMenuGlyphMetrics";
            this.toolStripMenuGlyphMetrics.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphMetrics.Text = "Metrics";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 541);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.pictureBoxOptPalette);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOptAdvWidth);
            this.Controls.Add(this.labelOptAdvWidth);
            this.Controls.Add(this.textBoxOptLeftSide);
            this.Controls.Add(this.labelOptLeftSide);
            this.Controls.Add(this.textBoxOptBaseline);
            this.Controls.Add(this.labelOptBaseline);
            this.Controls.Add(this.labelGlyphOpt);
            this.Controls.Add(this.textBoxOptFontPath);
            this.Controls.Add(this.buttonOptFontFromFile);
            this.Controls.Add(this.buttonCharsFromFile);
            this.Controls.Add(this.textBoxCharsOpt);
            this.Controls.Add(this.labelCharsOpt);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptPalette)).EndInit();
            this.contextMenuGlyph.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelCharsOpt;
        private System.Windows.Forms.TextBox textBoxCharsOpt;
        private System.Windows.Forms.Button buttonCharsFromFile;
        private System.Windows.Forms.TextBox textBoxOptFontPath;
        private System.Windows.Forms.Button buttonOptFontFromFile;
        private System.Windows.Forms.Label labelGlyphOpt;
        private System.Windows.Forms.Label labelOptBaseline;
        private System.Windows.Forms.TextBox textBoxOptBaseline;
        private System.Windows.Forms.TextBox textBoxOptLeftSide;
        private System.Windows.Forms.Label labelOptLeftSide;
        private System.Windows.Forms.TextBox textBoxOptAdvWidth;
        private System.Windows.Forms.Label labelOptAdvWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxOptPalette;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ContextMenuStrip contextMenuGlyph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphExport;
        private System.Windows.Forms.ToolStripSeparator toolStripGlyphSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphMetrics;
    }
}

