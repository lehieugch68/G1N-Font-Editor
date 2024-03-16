namespace G1N_Font_Editor.Components
{
    partial class NewGlyphForm
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
            this.labelNewGlyphChar = new System.Windows.Forms.Label();
            this.textBoxNewGlyphChar = new System.Windows.Forms.TextBox();
            this.buttonNewGlyphImgPath = new System.Windows.Forms.Button();
            this.textBoxNewGlyphImgPath = new System.Windows.Forms.TextBox();
            this.pictureBoxNewGlyph = new System.Windows.Forms.PictureBox();
            this.labelNewGlyphWidth = new System.Windows.Forms.Label();
            this.numericNewGlyphWidth = new System.Windows.Forms.NumericUpDown();
            this.numericNewGlyphHeight = new System.Windows.Forms.NumericUpDown();
            this.labelNewGlyphHeight = new System.Windows.Forms.Label();
            this.numericNewGlyphBaseline = new System.Windows.Forms.NumericUpDown();
            this.labelNewGlyphBaseline = new System.Windows.Forms.Label();
            this.numericNewGlyphXOff = new System.Windows.Forms.NumericUpDown();
            this.labelNewGlyphXOff = new System.Windows.Forms.Label();
            this.numericNewGlyphXAdv = new System.Windows.Forms.NumericUpDown();
            this.labelNewGlyphXAdv = new System.Windows.Forms.Label();
            this.buttonAddGlyph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGlyph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphBaseline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphXOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphXAdv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNewGlyphChar
            // 
            this.labelNewGlyphChar.AutoSize = true;
            this.labelNewGlyphChar.Location = new System.Drawing.Point(13, 13);
            this.labelNewGlyphChar.Name = "labelNewGlyphChar";
            this.labelNewGlyphChar.Size = new System.Drawing.Size(56, 13);
            this.labelNewGlyphChar.TabIndex = 0;
            this.labelNewGlyphChar.Text = "Character:";
            // 
            // textBoxNewGlyphChar
            // 
            this.textBoxNewGlyphChar.Location = new System.Drawing.Point(93, 10);
            this.textBoxNewGlyphChar.Name = "textBoxNewGlyphChar";
            this.textBoxNewGlyphChar.Size = new System.Drawing.Size(279, 20);
            this.textBoxNewGlyphChar.TabIndex = 1;
            // 
            // buttonNewGlyphImgPath
            // 
            this.buttonNewGlyphImgPath.Location = new System.Drawing.Point(12, 38);
            this.buttonNewGlyphImgPath.Name = "buttonNewGlyphImgPath";
            this.buttonNewGlyphImgPath.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGlyphImgPath.TabIndex = 2;
            this.buttonNewGlyphImgPath.Text = "Image";
            this.buttonNewGlyphImgPath.UseVisualStyleBackColor = true;
            this.buttonNewGlyphImgPath.Click += new System.EventHandler(this.buttonNewGlyphImgPath_Click);
            // 
            // textBoxNewGlyphImgPath
            // 
            this.textBoxNewGlyphImgPath.Location = new System.Drawing.Point(93, 40);
            this.textBoxNewGlyphImgPath.MaxLength = 1;
            this.textBoxNewGlyphImgPath.Name = "textBoxNewGlyphImgPath";
            this.textBoxNewGlyphImgPath.ReadOnly = true;
            this.textBoxNewGlyphImgPath.Size = new System.Drawing.Size(279, 20);
            this.textBoxNewGlyphImgPath.TabIndex = 3;
            // 
            // pictureBoxNewGlyph
            // 
            this.pictureBoxNewGlyph.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxNewGlyph.Location = new System.Drawing.Point(232, 80);
            this.pictureBoxNewGlyph.Name = "pictureBoxNewGlyph";
            this.pictureBoxNewGlyph.Size = new System.Drawing.Size(140, 160);
            this.pictureBoxNewGlyph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNewGlyph.TabIndex = 4;
            this.pictureBoxNewGlyph.TabStop = false;
            // 
            // labelNewGlyphWidth
            // 
            this.labelNewGlyphWidth.AutoSize = true;
            this.labelNewGlyphWidth.Location = new System.Drawing.Point(13, 82);
            this.labelNewGlyphWidth.Name = "labelNewGlyphWidth";
            this.labelNewGlyphWidth.Size = new System.Drawing.Size(38, 13);
            this.labelNewGlyphWidth.TabIndex = 5;
            this.labelNewGlyphWidth.Text = "Width:";
            // 
            // numericNewGlyphWidth
            // 
            this.numericNewGlyphWidth.Location = new System.Drawing.Point(93, 80);
            this.numericNewGlyphWidth.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewGlyphWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNewGlyphWidth.Name = "numericNewGlyphWidth";
            this.numericNewGlyphWidth.ReadOnly = true;
            this.numericNewGlyphWidth.Size = new System.Drawing.Size(120, 20);
            this.numericNewGlyphWidth.TabIndex = 6;
            this.numericNewGlyphWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericNewGlyphHeight
            // 
            this.numericNewGlyphHeight.Location = new System.Drawing.Point(93, 106);
            this.numericNewGlyphHeight.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewGlyphHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNewGlyphHeight.Name = "numericNewGlyphHeight";
            this.numericNewGlyphHeight.ReadOnly = true;
            this.numericNewGlyphHeight.Size = new System.Drawing.Size(120, 20);
            this.numericNewGlyphHeight.TabIndex = 8;
            this.numericNewGlyphHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelNewGlyphHeight
            // 
            this.labelNewGlyphHeight.AutoSize = true;
            this.labelNewGlyphHeight.Location = new System.Drawing.Point(13, 108);
            this.labelNewGlyphHeight.Name = "labelNewGlyphHeight";
            this.labelNewGlyphHeight.Size = new System.Drawing.Size(41, 13);
            this.labelNewGlyphHeight.TabIndex = 7;
            this.labelNewGlyphHeight.Text = "Height:";
            // 
            // numericNewGlyphBaseline
            // 
            this.numericNewGlyphBaseline.Location = new System.Drawing.Point(93, 132);
            this.numericNewGlyphBaseline.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewGlyphBaseline.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericNewGlyphBaseline.Name = "numericNewGlyphBaseline";
            this.numericNewGlyphBaseline.Size = new System.Drawing.Size(120, 20);
            this.numericNewGlyphBaseline.TabIndex = 10;
            // 
            // labelNewGlyphBaseline
            // 
            this.labelNewGlyphBaseline.AutoSize = true;
            this.labelNewGlyphBaseline.Location = new System.Drawing.Point(13, 134);
            this.labelNewGlyphBaseline.Name = "labelNewGlyphBaseline";
            this.labelNewGlyphBaseline.Size = new System.Drawing.Size(50, 13);
            this.labelNewGlyphBaseline.TabIndex = 9;
            this.labelNewGlyphBaseline.Text = "Baseline:";
            // 
            // numericNewGlyphXOff
            // 
            this.numericNewGlyphXOff.Location = new System.Drawing.Point(93, 158);
            this.numericNewGlyphXOff.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewGlyphXOff.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericNewGlyphXOff.Name = "numericNewGlyphXOff";
            this.numericNewGlyphXOff.Size = new System.Drawing.Size(120, 20);
            this.numericNewGlyphXOff.TabIndex = 12;
            // 
            // labelNewGlyphXOff
            // 
            this.labelNewGlyphXOff.AutoSize = true;
            this.labelNewGlyphXOff.Location = new System.Drawing.Point(13, 160);
            this.labelNewGlyphXOff.Name = "labelNewGlyphXOff";
            this.labelNewGlyphXOff.Size = new System.Drawing.Size(45, 13);
            this.labelNewGlyphXOff.TabIndex = 11;
            this.labelNewGlyphXOff.Text = "XOffset:";
            // 
            // numericNewGlyphXAdv
            // 
            this.numericNewGlyphXAdv.Location = new System.Drawing.Point(93, 184);
            this.numericNewGlyphXAdv.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewGlyphXAdv.Name = "numericNewGlyphXAdv";
            this.numericNewGlyphXAdv.Size = new System.Drawing.Size(120, 20);
            this.numericNewGlyphXAdv.TabIndex = 14;
            // 
            // labelNewGlyphXAdv
            // 
            this.labelNewGlyphXAdv.AutoSize = true;
            this.labelNewGlyphXAdv.Location = new System.Drawing.Point(13, 186);
            this.labelNewGlyphXAdv.Name = "labelNewGlyphXAdv";
            this.labelNewGlyphXAdv.Size = new System.Drawing.Size(60, 13);
            this.labelNewGlyphXAdv.TabIndex = 13;
            this.labelNewGlyphXAdv.Text = "XAdvance:";
            // 
            // buttonAddGlyph
            // 
            this.buttonAddGlyph.Location = new System.Drawing.Point(16, 217);
            this.buttonAddGlyph.Name = "buttonAddGlyph";
            this.buttonAddGlyph.Size = new System.Drawing.Size(197, 23);
            this.buttonAddGlyph.TabIndex = 15;
            this.buttonAddGlyph.Text = "Add Glyph";
            this.buttonAddGlyph.UseVisualStyleBackColor = true;
            this.buttonAddGlyph.Click += new System.EventHandler(this.buttonAddGlyph_Click);
            // 
            // NewGlyphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.buttonAddGlyph);
            this.Controls.Add(this.numericNewGlyphXAdv);
            this.Controls.Add(this.labelNewGlyphXAdv);
            this.Controls.Add(this.numericNewGlyphXOff);
            this.Controls.Add(this.labelNewGlyphXOff);
            this.Controls.Add(this.numericNewGlyphBaseline);
            this.Controls.Add(this.labelNewGlyphBaseline);
            this.Controls.Add(this.numericNewGlyphHeight);
            this.Controls.Add(this.labelNewGlyphHeight);
            this.Controls.Add(this.numericNewGlyphWidth);
            this.Controls.Add(this.labelNewGlyphWidth);
            this.Controls.Add(this.pictureBoxNewGlyph);
            this.Controls.Add(this.textBoxNewGlyphImgPath);
            this.Controls.Add(this.buttonNewGlyphImgPath);
            this.Controls.Add(this.textBoxNewGlyphChar);
            this.Controls.Add(this.labelNewGlyphChar);
            this.MaximizeBox = false;
            this.Name = "NewGlyphForm";
            this.Text = "New Glyph";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGlyph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphBaseline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphXOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewGlyphXAdv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewGlyphChar;
        private System.Windows.Forms.TextBox textBoxNewGlyphChar;
        private System.Windows.Forms.Button buttonNewGlyphImgPath;
        private System.Windows.Forms.TextBox textBoxNewGlyphImgPath;
        private System.Windows.Forms.PictureBox pictureBoxNewGlyph;
        private System.Windows.Forms.Label labelNewGlyphWidth;
        private System.Windows.Forms.NumericUpDown numericNewGlyphWidth;
        private System.Windows.Forms.NumericUpDown numericNewGlyphHeight;
        private System.Windows.Forms.Label labelNewGlyphHeight;
        private System.Windows.Forms.NumericUpDown numericNewGlyphBaseline;
        private System.Windows.Forms.Label labelNewGlyphBaseline;
        private System.Windows.Forms.NumericUpDown numericNewGlyphXOff;
        private System.Windows.Forms.Label labelNewGlyphXOff;
        private System.Windows.Forms.NumericUpDown numericNewGlyphXAdv;
        private System.Windows.Forms.Label labelNewGlyphXAdv;
        private System.Windows.Forms.Button buttonAddGlyph;
    }
}