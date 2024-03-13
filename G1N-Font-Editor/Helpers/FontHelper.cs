using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace G1N_Font_Editor.Helpers
{
    public static class FontHelper
    {
        private static Bitmap MEASURE_BMP = new Bitmap(1, 1);
        private struct FontStyleOpt
        {
            public System.Windows.FontStyle Style;
            public System.Windows.FontWeight Weight;
            public FontStyleOpt(FontStyle fontStyle)
            {
                switch (fontStyle)
                {
                    case FontStyle.Bold:
                        this.Style = System.Windows.FontStyles.Normal;
                        this.Weight = System.Windows.FontWeights.Bold;
                        break;
                    case FontStyle.Italic:
                        this.Style = System.Windows.FontStyles.Italic;
                        this.Weight = System.Windows.FontWeights.Normal;
                        break;
                    default:
                        this.Style = System.Windows.FontStyles.Normal;
                        this.Weight = System.Windows.FontWeights.Normal;
                        break;
                }
            }
        }
        public static System.Windows.Media.GlyphTypeface GetGlyphTypeface(string fontName, FontStyle fontStyle)
        {
            var fontFamily = new System.Windows.Media.FontFamily(fontName);
            System.Windows.Media.GlyphTypeface glyphTypeface;
            var fontStyleOpt = new FontStyleOpt(fontStyle);
            var typeface = new System.Windows.Media.Typeface(
                fontFamily,
                fontStyleOpt.Style,
                fontStyleOpt.Weight,
                System.Windows.FontStretches.Normal
            );
            typeface.TryGetGlyphTypeface(out glyphTypeface);
            return glyphTypeface;
        }
        public static SizeF MeasureSize(char character, Font font)
        {
            MEASURE_BMP.SetResolution(72, 72);
            using (var measureGraphics = Graphics.FromImage(MEASURE_BMP))
            {
                var charSize = measureGraphics.MeasureString(character.ToString(), font);
                return charSize;
            }
        }
        public static string[] GetFontStyles(FontFamily fontFamily)
        {
            var result = new List<string>();
            foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
            {
                if (fontFamily.IsStyleAvailable(style))
                {
                    result.Add(Enum.GetName(typeof(FontStyle), style));
                }
            }
            return result.ToArray();
        }
    }
}
