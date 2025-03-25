namespace G1N_Font_Editor.Components
{
    partial class NewG1NForm
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
            this.labelNewG1NTotalPage = new System.Windows.Forms.Label();
            this.numericNewG1NTotalPage = new System.Windows.Forms.NumericUpDown();
            this.buttonNewG1NCreate = new System.Windows.Forms.Button();
            this.checkBox8Bpp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewG1NTotalPage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNewG1NTotalPage
            // 
            this.labelNewG1NTotalPage.AutoSize = true;
            this.labelNewG1NTotalPage.Location = new System.Drawing.Point(12, 25);
            this.labelNewG1NTotalPage.Name = "labelNewG1NTotalPage";
            this.labelNewG1NTotalPage.Size = new System.Drawing.Size(62, 13);
            this.labelNewG1NTotalPage.TabIndex = 0;
            this.labelNewG1NTotalPage.Text = "Total Page:";
            // 
            // numericNewG1NTotalPage
            // 
            this.numericNewG1NTotalPage.Location = new System.Drawing.Point(80, 23);
            this.numericNewG1NTotalPage.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
            this.numericNewG1NTotalPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNewG1NTotalPage.Name = "numericNewG1NTotalPage";
            this.numericNewG1NTotalPage.Size = new System.Drawing.Size(142, 20);
            this.numericNewG1NTotalPage.TabIndex = 1;
            this.numericNewG1NTotalPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonNewG1NCreate
            // 
            this.buttonNewG1NCreate.Location = new System.Drawing.Point(12, 86);
            this.buttonNewG1NCreate.Name = "buttonNewG1NCreate";
            this.buttonNewG1NCreate.Size = new System.Drawing.Size(210, 23);
            this.buttonNewG1NCreate.TabIndex = 2;
            this.buttonNewG1NCreate.Text = "Create";
            this.buttonNewG1NCreate.UseVisualStyleBackColor = true;
            this.buttonNewG1NCreate.Click += new System.EventHandler(this.buttonNewG1NCreate_Click);
            // 
            // checkBox8Bpp
            // 
            this.checkBox8Bpp.AutoSize = true;
            this.checkBox8Bpp.Location = new System.Drawing.Point(12, 55);
            this.checkBox8Bpp.Name = "checkBox8Bpp";
            this.checkBox8Bpp.Size = new System.Drawing.Size(54, 17);
            this.checkBox8Bpp.TabIndex = 3;
            this.checkBox8Bpp.Text = "8 Bpp";
            this.checkBox8Bpp.UseVisualStyleBackColor = true;
            // 
            // NewG1NForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 121);
            this.Controls.Add(this.checkBox8Bpp);
            this.Controls.Add(this.buttonNewG1NCreate);
            this.Controls.Add(this.numericNewG1NTotalPage);
            this.Controls.Add(this.labelNewG1NTotalPage);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 160);
            this.MinimumSize = new System.Drawing.Size(250, 160);
            this.Name = "NewG1NForm";
            this.Text = "New G1N";
            this.Load += new System.EventHandler(this.NewG1NForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericNewG1NTotalPage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNewG1NTotalPage;
        private System.Windows.Forms.NumericUpDown numericNewG1NTotalPage;
        private System.Windows.Forms.Button buttonNewG1NCreate;
        private System.Windows.Forms.CheckBox checkBox8Bpp;
    }
}