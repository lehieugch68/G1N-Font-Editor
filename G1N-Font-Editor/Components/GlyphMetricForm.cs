using System;
using System.Drawing;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class GlyphMetricForm : Form
    {
        private int _baseline;
        public int Baseline { get { return _baseline; } }
        private int _xOffset;
        public int XOffset { get { return _xOffset; } }
        private int _xAdvance;
        public int XAdvance { get { return _xAdvance; } }
        
        public GlyphMetricForm(Glyph glyph)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
            numericGlyphMetricBaseline.Value = glyph.Baseline;
            numericGlyphMetricXOffset.Value = glyph.XOffset;
            numericGlyphMetricXAdv.Value = glyph.XAdvance;
            pictureBoxGlyphMetric.BackColor = Color.Black;
            pictureBoxGlyphMetric.Image = glyph.GetBitmap();
            labelGlyphMetricCharValue.Text = $"{glyph.Character} ({ string.Format(@"0x{0:X2}", (ushort)glyph.Character) })";
        }

        private void buttonGlyphMetricSave_Click(object sender, EventArgs e)
        {
            _baseline = Convert.ToSByte(numericGlyphMetricBaseline.Value);
            _xOffset = Convert.ToSByte(numericGlyphMetricXOffset.Value);
            _xAdvance = Convert.ToByte(numericGlyphMetricXAdv.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
