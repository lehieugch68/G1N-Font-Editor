using G1N_Font_Editor.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace G1N_Font_Editor.Components
{
    public partial class NewGlyphForm : Form
    {
        private char _character;
        public char Character { get { return _character; } }
        private Bitmap _glyphBitmap;
        public Bitmap GlyphBitmap { get { return _glyphBitmap; } }
        private int _baseline;
        public int Baseline { get { return _baseline; } }
        private int _xOffset;
        public int XOffset { get { return _xOffset; } }
        private int _xAdvance;
        public int XAdvance { get { return _xAdvance; } }
        public NewGlyphForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.AppIcon;
        }

        private void buttonNewGlyphImgPath_Click(object sender, EventArgs e)
        {
            string filePath = Utils.FileBrowser("", Global.PNG_FILE_FILTER);
            if (!string.IsNullOrEmpty(filePath))
            {
                var bmp = new Bitmap(filePath);
                if (bmp.Width > sbyte.MaxValue || bmp.Height > sbyte.MaxValue)
                {
                    MessageBox.Show(Global.MESSAGEBOX_MESSAGES["ImageTooLarge"], Global.MESSAGEBOX_TITLE);
                    return;
                } 
                textBoxNewGlyphImgPath.Text = filePath;
                _glyphBitmap = bmp;
                numericNewGlyphWidth.Value = _glyphBitmap.Width;
                numericNewGlyphHeight.Value = _glyphBitmap.Height;
                numericNewGlyphXAdv.Value = _glyphBitmap.Width;
                pictureBoxNewGlyph.BackColor = Color.Black;
                pictureBoxNewGlyph.Image = _glyphBitmap;
            }
        }

        private void buttonAddGlyph_Click(object sender, EventArgs e)
        {
            if (textBoxNewGlyphChar.Text.Length == 0) 
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["EmptyChar"], Global.MESSAGEBOX_TITLE);
            }
            else if (textBoxNewGlyphChar.Text.Length > 1)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["TooManyChars"], Global.MESSAGEBOX_TITLE);
            }
            else if (_glyphBitmap == null)
            {
                MessageBox.Show(Global.MESSAGEBOX_MESSAGES["EmptyImage"], Global.MESSAGEBOX_TITLE);
            }
            else
            {
                _character = textBoxNewGlyphChar.Text.ToCharArray().FirstOrDefault();
                _baseline = Convert.ToSByte(numericNewGlyphBaseline.Value);
                _xOffset = Convert.ToSByte(numericNewGlyphXOff.Value);
                _xAdvance = Convert.ToByte(numericNewGlyphXAdv.Value);
                DialogResult = DialogResult.OK;
            }
        }
    }
}
