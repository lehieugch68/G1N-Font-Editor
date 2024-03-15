using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class GlyphMetricForm : Form
    {
        private int _baseline;
        public int Baseline { get { return _baseline; } }
        private int _leftSide;
        public int LeftSide { get { return _leftSide; } }
        private int _advanceWidth;
        public int AdvanceWidth { get { return _advanceWidth; } }
        
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
            _baseline = Convert.ToSByte(numericGlyphMetricBaseline.Value);
            _leftSide = Convert.ToSByte(numericGlyphMetricLeftSide.Value);
            _advanceWidth = Convert.ToByte(numericGlyphMetricXAdv.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
