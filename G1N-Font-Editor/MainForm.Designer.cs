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
            this.comboBoxPage = new System.Windows.Forms.ComboBox();
            this.labelFont = new System.Windows.Forms.Label();
            this.labelBuildOptions = new System.Windows.Forms.Label();
            this.labelOptFont = new System.Windows.Forms.Label();
            this.comboBoxOptFont = new System.Windows.Forms.ComboBox();
            this.labelOptFontStyle = new System.Windows.Forms.Label();
            this.comboBoxOptFontStyle = new System.Windows.Forms.ComboBox();
            this.labelOptFontSize = new System.Windows.Forms.Label();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.labelCharsOpt = new System.Windows.Forms.Label();
            this.textBoxCharsOpt = new System.Windows.Forms.TextBox();
            this.buttonCharsFromFile = new System.Windows.Forms.Button();
            this.textBoxOptFontPath = new System.Windows.Forms.TextBox();
            this.buttonOptFontFromFile = new System.Windows.Forms.Button();
            this.labelGlyphOpt = new System.Windows.Forms.Label();
            this.labelOptBaseline = new System.Windows.Forms.Label();
            this.labelOptLeftSide = new System.Windows.Forms.Label();
            this.labelOptAdvWidth = new System.Windows.Forms.Label();
            this.labelPalettes = new System.Windows.Forms.Label();
            this.pictureBoxOptPalette = new System.Windows.Forms.PictureBox();
            this.contextMenuGlyph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripGlyphSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuGlyphImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGlyphExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGlyphMetrics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.numericOptFontSize = new System.Windows.Forms.NumericUpDown();
            this.numericOptCustomBaseline = new System.Windows.Forms.NumericUpDown();
            this.numericOptCustomLeftSide = new System.Windows.Forms.NumericUpDown();
            this.numericOptCustomXAdv = new System.Windows.Forms.NumericUpDown();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewG1N = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuOpenG1N = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuSaveG1N = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelStatusText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptPalette)).BeginInit();
            this.contextMenuGlyph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomBaseline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomLeftSide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomXAdv)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox.Location = new System.Drawing.Point(340, 37);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(512, 512);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            // 
            // comboBoxPage
            // 
            this.comboBoxPage.FormattingEnabled = true;
            this.comboBoxPage.Location = new System.Drawing.Point(88, 37);
            this.comboBoxPage.Name = "comboBoxPage";
            this.comboBoxPage.Size = new System.Drawing.Size(241, 21);
            this.comboBoxPage.TabIndex = 4;
            this.comboBoxPage.SelectedIndexChanged += new System.EventHandler(this.comboBoxPage_SelectedIndexChanged);
            // 
            // labelFont
            // 
            this.labelFont.AutoSize = true;
            this.labelFont.Location = new System.Drawing.Point(12, 40);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(60, 13);
            this.labelFont.TabIndex = 5;
            this.labelFont.Text = "G1N Page:";
            // 
            // labelBuildOptions
            // 
            this.labelBuildOptions.AutoSize = true;
            this.labelBuildOptions.Location = new System.Drawing.Point(12, 75);
            this.labelBuildOptions.Name = "labelBuildOptions";
            this.labelBuildOptions.Size = new System.Drawing.Size(116, 13);
            this.labelBuildOptions.TabIndex = 6;
            this.labelBuildOptions.Text = "TrueType Font Options";
            // 
            // labelOptFont
            // 
            this.labelOptFont.AutoSize = true;
            this.labelOptFont.Location = new System.Drawing.Point(12, 105);
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
            this.comboBoxOptFont.Location = new System.Drawing.Point(88, 102);
            this.comboBoxOptFont.Name = "comboBoxOptFont";
            this.comboBoxOptFont.Size = new System.Drawing.Size(241, 21);
            this.comboBoxOptFont.TabIndex = 8;
            this.comboBoxOptFont.SelectedIndexChanged += new System.EventHandler(this.comboBoxOptFont_SelectedIndexChanged);
            // 
            // labelOptFontStyle
            // 
            this.labelOptFontStyle.AutoSize = true;
            this.labelOptFontStyle.Location = new System.Drawing.Point(187, 170);
            this.labelOptFontStyle.Name = "labelOptFontStyle";
            this.labelOptFontStyle.Size = new System.Drawing.Size(36, 13);
            this.labelOptFontStyle.TabIndex = 64;
            this.labelOptFontStyle.Text = "Style: ";
            // 
            // comboBoxOptFontStyle
            // 
            this.comboBoxOptFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOptFontStyle.FormattingEnabled = true;
            this.comboBoxOptFontStyle.Location = new System.Drawing.Point(229, 167);
            this.comboBoxOptFontStyle.Name = "comboBoxOptFontStyle";
            this.comboBoxOptFontStyle.Size = new System.Drawing.Size(100, 21);
            this.comboBoxOptFontStyle.TabIndex = 63;
            // 
            // labelOptFontSize
            // 
            this.labelOptFontSize.AutoSize = true;
            this.labelOptFontSize.Location = new System.Drawing.Point(12, 170);
            this.labelOptFontSize.Name = "labelOptFontSize";
            this.labelOptFontSize.Size = new System.Drawing.Size(33, 13);
            this.labelOptFontSize.TabIndex = 61;
            this.labelOptFontSize.Text = "Size: ";
            // 
            // buttonBuild
            // 
            this.buttonBuild.Location = new System.Drawing.Point(12, 285);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(317, 25);
            this.buttonBuild.TabIndex = 65;
            this.buttonBuild.Text = "Build From TrueType Font";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // labelCharsOpt
            // 
            this.labelCharsOpt.AutoSize = true;
            this.labelCharsOpt.Location = new System.Drawing.Point(12, 205);
            this.labelCharsOpt.Name = "labelCharsOpt";
            this.labelCharsOpt.Size = new System.Drawing.Size(59, 13);
            this.labelCharsOpt.TabIndex = 66;
            this.labelCharsOpt.Text = "Add Chars:";
            // 
            // textBoxCharsOpt
            // 
            this.textBoxCharsOpt.Location = new System.Drawing.Point(88, 202);
            this.textBoxCharsOpt.Multiline = true;
            this.textBoxCharsOpt.Name = "textBoxCharsOpt";
            this.textBoxCharsOpt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCharsOpt.Size = new System.Drawing.Size(241, 70);
            this.textBoxCharsOpt.TabIndex = 67;
            // 
            // buttonCharsFromFile
            // 
            this.buttonCharsFromFile.Location = new System.Drawing.Point(12, 249);
            this.buttonCharsFromFile.Name = "buttonCharsFromFile";
            this.buttonCharsFromFile.Size = new System.Drawing.Size(70, 23);
            this.buttonCharsFromFile.TabIndex = 68;
            this.buttonCharsFromFile.Text = "From File";
            this.buttonCharsFromFile.UseVisualStyleBackColor = true;
            this.buttonCharsFromFile.Click += new System.EventHandler(this.buttonCharsFromFile_Click);
            // 
            // textBoxOptFontPath
            // 
            this.textBoxOptFontPath.Location = new System.Drawing.Point(88, 132);
            this.textBoxOptFontPath.Name = "textBoxOptFontPath";
            this.textBoxOptFontPath.ReadOnly = true;
            this.textBoxOptFontPath.Size = new System.Drawing.Size(241, 20);
            this.textBoxOptFontPath.TabIndex = 70;
            // 
            // buttonOptFontFromFile
            // 
            this.buttonOptFontFromFile.Location = new System.Drawing.Point(12, 130);
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
            this.labelGlyphOpt.Location = new System.Drawing.Point(9, 330);
            this.labelGlyphOpt.Name = "labelGlyphOpt";
            this.labelGlyphOpt.Size = new System.Drawing.Size(73, 13);
            this.labelGlyphOpt.TabIndex = 71;
            this.labelGlyphOpt.Text = "Glyph Options";
            // 
            // labelOptBaseline
            // 
            this.labelOptBaseline.AutoSize = true;
            this.labelOptBaseline.Location = new System.Drawing.Point(9, 357);
            this.labelOptBaseline.Name = "labelOptBaseline";
            this.labelOptBaseline.Size = new System.Drawing.Size(110, 13);
            this.labelOptBaseline.TabIndex = 72;
            this.labelOptBaseline.Text = "Add Custom Baseline:";
            // 
            // labelOptLeftSide
            // 
            this.labelOptLeftSide.AutoSize = true;
            this.labelOptLeftSide.Location = new System.Drawing.Point(9, 386);
            this.labelOptLeftSide.Name = "labelOptLeftSide";
            this.labelOptLeftSide.Size = new System.Drawing.Size(109, 13);
            this.labelOptLeftSide.TabIndex = 74;
            this.labelOptLeftSide.Text = "Add Custom LeftSide:";
            // 
            // labelOptAdvWidth
            // 
            this.labelOptAdvWidth.AutoSize = true;
            this.labelOptAdvWidth.Location = new System.Drawing.Point(9, 415);
            this.labelOptAdvWidth.Name = "labelOptAdvWidth";
            this.labelOptAdvWidth.Size = new System.Drawing.Size(141, 13);
            this.labelOptAdvWidth.TabIndex = 76;
            this.labelOptAdvWidth.Text = "Add Custom AdvanceWidth:";
            // 
            // labelPalettes
            // 
            this.labelPalettes.AutoSize = true;
            this.labelPalettes.Location = new System.Drawing.Point(12, 450);
            this.labelPalettes.Name = "labelPalettes";
            this.labelPalettes.Size = new System.Drawing.Size(45, 13);
            this.labelPalettes.TabIndex = 78;
            this.labelPalettes.Text = "Palettes";
            // 
            // pictureBoxOptPalette
            // 
            this.pictureBoxOptPalette.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxOptPalette.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOptPalette.Location = new System.Drawing.Point(12, 470);
            this.pictureBoxOptPalette.Name = "pictureBoxOptPalette";
            this.pictureBoxOptPalette.Size = new System.Drawing.Size(317, 50);
            this.pictureBoxOptPalette.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOptPalette.TabIndex = 79;
            this.pictureBoxOptPalette.TabStop = false;
            // 
            // contextMenuGlyph
            // 
            this.contextMenuGlyph.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripGlyphSeparator,
            this.toolStripMenuGlyphImport,
            this.toolStripMenuGlyphExport,
            this.toolStripMenuGlyphMetrics});
            this.contextMenuGlyph.Name = "contextMenuGlyph";
            this.contextMenuGlyph.Size = new System.Drawing.Size(148, 76);
            // 
            // toolStripGlyphSeparator
            // 
            this.toolStripGlyphSeparator.Name = "toolStripGlyphSeparator";
            this.toolStripGlyphSeparator.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuGlyphImport
            // 
            this.toolStripMenuGlyphImport.Name = "toolStripMenuGlyphImport";
            this.toolStripMenuGlyphImport.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphImport.Text = "Import Image";
            this.toolStripMenuGlyphImport.Click += new System.EventHandler(this.toolStripMenuGlyphImport_Click);
            // 
            // toolStripMenuGlyphExport
            // 
            this.toolStripMenuGlyphExport.Name = "toolStripMenuGlyphExport";
            this.toolStripMenuGlyphExport.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphExport.Text = "Export Image";
            this.toolStripMenuGlyphExport.Click += new System.EventHandler(this.toolStripMenuGlyphExport_Click);
            // 
            // toolStripMenuGlyphMetrics
            // 
            this.toolStripMenuGlyphMetrics.Name = "toolStripMenuGlyphMetrics";
            this.toolStripMenuGlyphMetrics.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuGlyphMetrics.Text = "Glyph Metrics";
            this.toolStripMenuGlyphMetrics.Click += new System.EventHandler(this.toolStripMenuGlyphMetrics_Click);
            // 
            // toolStripMenuExit
            // 
            this.toolStripMenuExit.Name = "toolStripMenuExit";
            this.toolStripMenuExit.ShortcutKeyDisplayString = "Alt+F4";
            this.toolStripMenuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.toolStripMenuExit.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuExit.Text = "Exit";
            this.toolStripMenuExit.Click += new System.EventHandler(this.toolStripMenuExit_Click);
            // 
            // numericOptFontSize
            // 
            this.numericOptFontSize.Location = new System.Drawing.Point(88, 168);
            this.numericOptFontSize.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericOptFontSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericOptFontSize.Name = "numericOptFontSize";
            this.numericOptFontSize.Size = new System.Drawing.Size(80, 20);
            this.numericOptFontSize.TabIndex = 81;
            this.numericOptFontSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericOptCustomBaseline
            // 
            this.numericOptCustomBaseline.Location = new System.Drawing.Point(166, 355);
            this.numericOptCustomBaseline.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericOptCustomBaseline.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericOptCustomBaseline.Name = "numericOptCustomBaseline";
            this.numericOptCustomBaseline.Size = new System.Drawing.Size(160, 20);
            this.numericOptCustomBaseline.TabIndex = 82;
            // 
            // numericOptCustomLeftSide
            // 
            this.numericOptCustomLeftSide.Location = new System.Drawing.Point(166, 384);
            this.numericOptCustomLeftSide.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericOptCustomLeftSide.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericOptCustomLeftSide.Name = "numericOptCustomLeftSide";
            this.numericOptCustomLeftSide.Size = new System.Drawing.Size(160, 20);
            this.numericOptCustomLeftSide.TabIndex = 83;
            // 
            // numericOptCustomXAdv
            // 
            this.numericOptCustomXAdv.Location = new System.Drawing.Point(166, 413);
            this.numericOptCustomXAdv.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericOptCustomXAdv.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericOptCustomXAdv.Name = "numericOptCustomXAdv";
            this.numericOptCustomXAdv.Size = new System.Drawing.Size(160, 20);
            this.numericOptCustomXAdv.TabIndex = 84;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFile,
            this.toolStripMenuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(864, 24);
            this.menuStrip.TabIndex = 85;
            this.menuStrip.Text = "File";
            // 
            // toolStripMenuFile
            // 
            this.toolStripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewG1N,
            this.toolStripMenuOpenG1N,
            this.toolStripSeparator1,
            this.toolStripMenuSaveG1N,
            this.toolStripMenuSaveAs,
            this.toolStripSeparator2,
            this.toolStripMenuExit});
            this.toolStripMenuFile.Name = "toolStripMenuFile";
            this.toolStripMenuFile.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuFile.Text = "File";
            // 
            // toolStripMenuNewG1N
            // 
            this.toolStripMenuNewG1N.Name = "toolStripMenuNewG1N";
            this.toolStripMenuNewG1N.ShortcutKeyDisplayString = "Ctrl+N";
            this.toolStripMenuNewG1N.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuNewG1N.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuNewG1N.Text = "New";
            this.toolStripMenuNewG1N.Click += new System.EventHandler(this.toolStripMenuNewG1N_Click);
            // 
            // toolStripMenuOpenG1N
            // 
            this.toolStripMenuOpenG1N.Name = "toolStripMenuOpenG1N";
            this.toolStripMenuOpenG1N.ShortcutKeyDisplayString = "Ctrl+O";
            this.toolStripMenuOpenG1N.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuOpenG1N.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuOpenG1N.Text = "Open";
            this.toolStripMenuOpenG1N.Click += new System.EventHandler(this.toolStripMenuOpenG1N_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // toolStripMenuSaveG1N
            // 
            this.toolStripMenuSaveG1N.Name = "toolStripMenuSaveG1N";
            this.toolStripMenuSaveG1N.ShortcutKeyDisplayString = "Ctrl+S";
            this.toolStripMenuSaveG1N.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuSaveG1N.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuSaveG1N.Text = "Save";
            this.toolStripMenuSaveG1N.Click += new System.EventHandler(this.toolStripMenuSaveG1N_Click);
            // 
            // toolStripMenuSaveAs
            // 
            this.toolStripMenuSaveAs.Name = "toolStripMenuSaveAs";
            this.toolStripMenuSaveAs.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.toolStripMenuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.toolStripMenuSaveAs.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuSaveAs.Text = "Save As";
            this.toolStripMenuSaveAs.Click += new System.EventHandler(this.toolStripMenuSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // toolStripMenuHelp
            // 
            this.toolStripMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuGuide,
            this.toolStripMenuAbout});
            this.toolStripMenuHelp.Name = "toolStripMenuHelp";
            this.toolStripMenuHelp.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuHelp.Text = "Help";
            // 
            // toolStripMenuGuide
            // 
            this.toolStripMenuGuide.Name = "toolStripMenuGuide";
            this.toolStripMenuGuide.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuGuide.Text = "Guide";
            // 
            // toolStripMenuAbout
            // 
            this.toolStripMenuAbout.Name = "toolStripMenuAbout";
            this.toolStripMenuAbout.Size = new System.Drawing.Size(107, 22);
            this.toolStripMenuAbout.Text = "About";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 535);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 86;
            this.labelStatus.Text = "Status:";
            // 
            // labelStatusText
            // 
            this.labelStatusText.AutoSize = true;
            this.labelStatusText.Location = new System.Drawing.Point(58, 535);
            this.labelStatusText.Name = "labelStatusText";
            this.labelStatusText.Size = new System.Drawing.Size(27, 13);
            this.labelStatusText.TabIndex = 87;
            this.labelStatusText.Text = "N/A";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 561);
            this.Controls.Add(this.labelStatusText);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.numericOptCustomXAdv);
            this.Controls.Add(this.numericOptCustomLeftSide);
            this.Controls.Add(this.numericOptCustomBaseline);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.numericOptFontSize);
            this.Controls.Add(this.pictureBoxOptPalette);
            this.Controls.Add(this.labelPalettes);
            this.Controls.Add(this.labelOptAdvWidth);
            this.Controls.Add(this.labelOptLeftSide);
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
            this.Controls.Add(this.labelOptFontSize);
            this.Controls.Add(this.comboBoxOptFont);
            this.Controls.Add(this.labelOptFont);
            this.Controls.Add(this.labelBuildOptions);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.comboBoxPage);
            this.Controls.Add(this.pictureBox);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(880, 600);
            this.Name = "MainForm";
            this.Text = "G1N Font Editor by LeHieu - VietHoaGame";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptPalette)).EndInit();
            this.contextMenuGlyph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericOptFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomBaseline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomLeftSide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericOptCustomXAdv)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox comboBoxPage;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.Label labelBuildOptions;
        private System.Windows.Forms.Label labelOptFont;
        private System.Windows.Forms.ComboBox comboBoxOptFont;
        private System.Windows.Forms.Label labelOptFontStyle;
        private System.Windows.Forms.ComboBox comboBoxOptFontStyle;
        private System.Windows.Forms.Label labelOptFontSize;
        private System.Windows.Forms.Button buttonBuild;
        private System.Windows.Forms.Label labelCharsOpt;
        private System.Windows.Forms.TextBox textBoxCharsOpt;
        private System.Windows.Forms.Button buttonCharsFromFile;
        private System.Windows.Forms.TextBox textBoxOptFontPath;
        private System.Windows.Forms.Button buttonOptFontFromFile;
        private System.Windows.Forms.Label labelGlyphOpt;
        private System.Windows.Forms.Label labelOptBaseline;
        private System.Windows.Forms.Label labelOptLeftSide;
        private System.Windows.Forms.Label labelOptAdvWidth;
        private System.Windows.Forms.Label labelPalettes;
        private System.Windows.Forms.PictureBox pictureBoxOptPalette;
        private System.Windows.Forms.ContextMenuStrip contextMenuGlyph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphImport;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphExport;
        private System.Windows.Forms.ToolStripSeparator toolStripGlyphSeparator;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGlyphMetrics;
        private System.Windows.Forms.NumericUpDown numericOptFontSize;
        private System.Windows.Forms.NumericUpDown numericOptCustomBaseline;
        private System.Windows.Forms.NumericUpDown numericOptCustomLeftSide;
        private System.Windows.Forms.NumericUpDown numericOptCustomXAdv;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewG1N;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuOpenG1N;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSaveG1N;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuGuide;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAbout;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelStatusText;
    }
}

