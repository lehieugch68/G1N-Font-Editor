namespace G1N_Font_Editor.Components
{
    partial class GlyphMetricForm
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
            this.labelGlyphMetricChar = new System.Windows.Forms.Label();
            this.labelGlyphMetricAdvWidth = new System.Windows.Forms.Label();
            this.labelGlyphMetricXOffset = new System.Windows.Forms.Label();
            this.labelGlyphMetricBaseline = new System.Windows.Forms.Label();
            this.pictureBoxGlyphMetric = new System.Windows.Forms.PictureBox();
            this.buttonGlyphMetricSave = new System.Windows.Forms.Button();
            this.labelGlyphMetricCharValue = new System.Windows.Forms.Label();
            this.numericGlyphMetricBaseline = new System.Windows.Forms.NumericUpDown();
            this.numericGlyphMetricXOffset = new System.Windows.Forms.NumericUpDown();
            this.numericGlyphMetricXAdv = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlyphMetric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricBaseline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricXOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricXAdv)).BeginInit();
            this.SuspendLayout();
            // 
            // labelGlyphMetricChar
            // 
            this.labelGlyphMetricChar.AutoSize = true;
            this.labelGlyphMetricChar.Location = new System.Drawing.Point(12, 14);
            this.labelGlyphMetricChar.Name = "labelGlyphMetricChar";
            this.labelGlyphMetricChar.Size = new System.Drawing.Size(56, 13);
            this.labelGlyphMetricChar.TabIndex = 0;
            this.labelGlyphMetricChar.Text = "Character:";
            // 
            // labelGlyphMetricAdvWidth
            // 
            this.labelGlyphMetricAdvWidth.AutoSize = true;
            this.labelGlyphMetricAdvWidth.Location = new System.Drawing.Point(12, 97);
            this.labelGlyphMetricAdvWidth.Name = "labelGlyphMetricAdvWidth";
            this.labelGlyphMetricAdvWidth.Size = new System.Drawing.Size(60, 13);
            this.labelGlyphMetricAdvWidth.TabIndex = 82;
            this.labelGlyphMetricAdvWidth.Text = "XAdvance:";
            // 
            // labelGlyphMetricXOffset
            // 
            this.labelGlyphMetricXOffset.AutoSize = true;
            this.labelGlyphMetricXOffset.Location = new System.Drawing.Point(12, 71);
            this.labelGlyphMetricXOffset.Name = "labelGlyphMetricXOffset";
            this.labelGlyphMetricXOffset.Size = new System.Drawing.Size(45, 13);
            this.labelGlyphMetricXOffset.TabIndex = 80;
            this.labelGlyphMetricXOffset.Text = "XOffset:";
            // 
            // labelGlyphMetricBaseline
            // 
            this.labelGlyphMetricBaseline.AutoSize = true;
            this.labelGlyphMetricBaseline.Location = new System.Drawing.Point(12, 45);
            this.labelGlyphMetricBaseline.Name = "labelGlyphMetricBaseline";
            this.labelGlyphMetricBaseline.Size = new System.Drawing.Size(50, 13);
            this.labelGlyphMetricBaseline.TabIndex = 78;
            this.labelGlyphMetricBaseline.Text = "Baseline:";
            // 
            // pictureBoxGlyphMetric
            // 
            this.pictureBoxGlyphMetric.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBoxGlyphMetric.Location = new System.Drawing.Point(252, 14);
            this.pictureBoxGlyphMetric.Name = "pictureBoxGlyphMetric";
            this.pictureBoxGlyphMetric.Size = new System.Drawing.Size(120, 140);
            this.pictureBoxGlyphMetric.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxGlyphMetric.TabIndex = 84;
            this.pictureBoxGlyphMetric.TabStop = false;
            // 
            // buttonGlyphMetricSave
            // 
            this.buttonGlyphMetricSave.Location = new System.Drawing.Point(12, 131);
            this.buttonGlyphMetricSave.Name = "buttonGlyphMetricSave";
            this.buttonGlyphMetricSave.Size = new System.Drawing.Size(228, 23);
            this.buttonGlyphMetricSave.TabIndex = 85;
            this.buttonGlyphMetricSave.Text = "Save";
            this.buttonGlyphMetricSave.UseVisualStyleBackColor = true;
            this.buttonGlyphMetricSave.Click += new System.EventHandler(this.buttonGlyphMetricSave_Click);
            // 
            // labelGlyphMetricCharValue
            // 
            this.labelGlyphMetricCharValue.AutoSize = true;
            this.labelGlyphMetricCharValue.Location = new System.Drawing.Point(110, 14);
            this.labelGlyphMetricCharValue.Name = "labelGlyphMetricCharValue";
            this.labelGlyphMetricCharValue.Size = new System.Drawing.Size(27, 13);
            this.labelGlyphMetricCharValue.TabIndex = 86;
            this.labelGlyphMetricCharValue.Text = "N/A";
            // 
            // numericGlyphMetricBaseline
            // 
            this.numericGlyphMetricBaseline.Location = new System.Drawing.Point(110, 43);
            this.numericGlyphMetricBaseline.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericGlyphMetricBaseline.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericGlyphMetricBaseline.Name = "numericGlyphMetricBaseline";
            this.numericGlyphMetricBaseline.Size = new System.Drawing.Size(130, 20);
            this.numericGlyphMetricBaseline.TabIndex = 87;
            // 
            // numericGlyphMetricXOffset
            // 
            this.numericGlyphMetricXOffset.Location = new System.Drawing.Point(110, 69);
            this.numericGlyphMetricXOffset.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericGlyphMetricXOffset.Minimum = new decimal(new int[] {
            127,
            0,
            0,
            -2147483648});
            this.numericGlyphMetricXOffset.Name = "numericGlyphMetricXOffset";
            this.numericGlyphMetricXOffset.Size = new System.Drawing.Size(130, 20);
            this.numericGlyphMetricXOffset.TabIndex = 88;
            // 
            // numericGlyphMetricXAdv
            // 
            this.numericGlyphMetricXAdv.Location = new System.Drawing.Point(110, 95);
            this.numericGlyphMetricXAdv.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericGlyphMetricXAdv.Name = "numericGlyphMetricXAdv";
            this.numericGlyphMetricXAdv.Size = new System.Drawing.Size(130, 20);
            this.numericGlyphMetricXAdv.TabIndex = 89;
            // 
            // GlyphMetricForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 171);
            this.Controls.Add(this.numericGlyphMetricXAdv);
            this.Controls.Add(this.numericGlyphMetricXOffset);
            this.Controls.Add(this.numericGlyphMetricBaseline);
            this.Controls.Add(this.labelGlyphMetricCharValue);
            this.Controls.Add(this.buttonGlyphMetricSave);
            this.Controls.Add(this.pictureBoxGlyphMetric);
            this.Controls.Add(this.labelGlyphMetricAdvWidth);
            this.Controls.Add(this.labelGlyphMetricXOffset);
            this.Controls.Add(this.labelGlyphMetricBaseline);
            this.Controls.Add(this.labelGlyphMetricChar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 210);
            this.MinimumSize = new System.Drawing.Size(400, 210);
            this.Name = "GlyphMetricForm";
            this.Text = "Glyph Metrics";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGlyphMetric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricBaseline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricXOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGlyphMetricXAdv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelGlyphMetricChar;
        private System.Windows.Forms.Label labelGlyphMetricAdvWidth;
        private System.Windows.Forms.Label labelGlyphMetricXOffset;
        private System.Windows.Forms.Label labelGlyphMetricBaseline;
        private System.Windows.Forms.PictureBox pictureBoxGlyphMetric;
        private System.Windows.Forms.Button buttonGlyphMetricSave;
        private System.Windows.Forms.Label labelGlyphMetricCharValue;
        private System.Windows.Forms.NumericUpDown numericGlyphMetricBaseline;
        private System.Windows.Forms.NumericUpDown numericGlyphMetricXOffset;
        private System.Windows.Forms.NumericUpDown numericGlyphMetricXAdv;
    }
}