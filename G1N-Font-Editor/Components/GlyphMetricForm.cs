using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class GlyphMetricForm : Form
    {
        public int Baseline { get; set; }
        public int LeftSide { get; set; }
        public int AdvanceWidth { get; set; }
        
        public GlyphMetricForm(Glyph glyph)
        {
            InitializeComponent();
            numericGlyphMetricBaseline.Value = glyph.Baseline;
            numericGlyphMetricLeftSide.Value = glyph.LeftSide;
            numericGlyphMetricXAdv.Value = glyph.XAdv;
            pictureBoxGlyphMetric.BackColor = Color.Black;
            pictureBoxGlyphMetric.Image = glyph.GetBitmap();
            labelGlyphMetricCharValue.Text = $"{glyph.Character} ({ string.Format(@"0x{0:X2}", (ushort)glyph.Character) })";
        }

        private void buttonGlyphMetricSave_Click(object sender, EventArgs e)
        {
            this.Baseline = Convert.ToByte(numericGlyphMetricBaseline.Value);
            this.LeftSide = Convert.ToByte(numericGlyphMetricLeftSide.Value);
            this.AdvanceWidth = Convert.ToByte(numericGlyphMetricXAdv.Value);
            this.DialogResult = DialogResult.OK;
        }
    }
}
