using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace G1N_Font_Editor
{
    public class GlyphTable
    {
        public int Index { get; set; }
        public List<Glyph> Glyphs { get; set; }
        private Bitmap _tablePreview;
        public Bitmap TablePreview { get { return _tablePreview; } }
        public Color[] Palettes { get; set; }
        private Bitmap _palettePreview;
        public Bitmap PalettePreview { get { return _palettePreview; } }
        public GlyphTable(int index, Color[] palettes)
        {
            Index = index;
            Glyphs = new List<Glyph>();
            Palettes = new Color[0x10];
            Array.Copy(palettes, Palettes, 0x10);
        }
        public void AddGlyph(Glyph glyph)
        {
            if (Glyphs.Any(g => g.Character == glyph.Character))
                throw new Exception(Global.MESSAGEBOX_MESSAGES["CharExists"]);
            Glyphs.Add(glyph);
        }
        public Bitmap ReloadTablePreview(bool isReMeasure = true, int padx = 4, int pady = 4)
        {
            int width = _tablePreview == null ? Constant.MIN_WIDTH : _tablePreview.Width,
                height = _tablePreview == null ? Constant.MIN_HEIGHT : _tablePreview.Height;
            if (_tablePreview == null || isReMeasure)
            {
                MeasureBitmapSizeFromGlyphs(Glyphs, padx, pady, ref width, ref height);
            }
            else
            {
                width = _tablePreview.Width;
                height = _tablePreview.Height;
            }
            var result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                foreach (var glyph in Glyphs)
                {
                    var bmp = glyph.GetBitmap();
                    g.DrawImage(bmp, glyph.Rect);
                    using (Pen pen = new Pen(Color.Red, 1))
                    {
                        g.DrawRectangle(
                            pen,
                            glyph.Rect.X,
                            glyph.Rect.Y,
                            glyph.Rect.Width,
                            glyph.Rect.Height);
                    }
                }
            }
            _tablePreview = result;
            return result;
        }
        public Bitmap GetTablePreview()
        {
            if (_tablePreview != null)
            {
                return _tablePreview;
            }
            return ReloadTablePreview();
        }
        public Bitmap ReloadPalettePreview()
        {
            int width = Constant.PALETTE_PICTURE_WIDTH;
            int height = Constant.PALETTE_PICTURE_HEIGHT;
            Bitmap result = new Bitmap(width, height);
            var colorWidth = width / Palettes.Length;
            using (Graphics g = Graphics.FromImage(result))
            {
                for (int i = 0; i < Palettes.Length; i++)
                {
                    var rect = new Rectangle(colorWidth * i, 0, colorWidth, height);
                    using (Brush brush = new SolidBrush(Palettes[i]))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }
            _palettePreview = result;
            return result;
        }
        public Bitmap GetPalettePreview()
        {
            if (_palettePreview != null)
            {
                return _palettePreview;
            }
            return ReloadPalettePreview();
        }
        private bool MeasureBitmapSizeFromGlyphs(List<Glyph> glyphs, int padx, int pady, ref int width, ref int height)
        {
            var rects = new List<Rectangle>();
            int currX = padx, currY = pady, lowestRowHeight = pady;
            for (int i = 0; i < glyphs.Count(); i++)
            {
                if (currX + glyphs[i].Width > width)
                {
                    currY = lowestRowHeight;
                    lowestRowHeight = currY + glyphs[i].Height + pady;
                    if (lowestRowHeight > height)
                    {
                        width += Constant.MIN_WIDTH;
                        height += Constant.MIN_HEIGHT;
                        return MeasureBitmapSizeFromGlyphs(glyphs, padx, pady, ref width, ref height);
                    }
                    currX = padx;
                }
                var boxRect = new Rectangle(currX, currY, glyphs[i].Width + padx, glyphs[i].Height + pady);
                while (rects.Any(r => r.IntersectsWith(boxRect))) boxRect.Y++;
                if (boxRect.Y + boxRect.Height < lowestRowHeight) lowestRowHeight = boxRect.Y + boxRect.Height;
                rects.Add(boxRect);
                glyphs[i].Rect = new Rectangle(boxRect.X, boxRect.Y, glyphs[i].Width, glyphs[i].Height);
                currX += glyphs[i].Width + padx;
            }
            return true;
        }
        public void Build(System.Windows.Media.GlyphTypeface glyphTypeface, Font font, char[] chars = null)
        {
            if (chars != null) 
            {
                var dict = glyphTypeface.CharacterToGlyphMap;
                foreach (var ch in chars)
                {
                    if (Glyphs.FindIndex(g => g.Character == ch) != -1 || !dict.ContainsKey(ch)) continue;
                    var glyph = new Glyph(ch);
                    Glyphs.Add(glyph);
                }
            }
            foreach (var glyph in Glyphs)
            {
                glyph.Build(glyphTypeface, font);
            }
            Glyphs = Glyphs.OrderBy(g => g.Character).ToList();
        }
        public static class Constant
        {
            public static readonly int MIN_WIDTH = Global.DEFAULT_TEX_WIDTH;
            public static readonly int MIN_HEIGHT = Global.DEFAULT_TEX_HEIGHT;
            public static readonly int PALETTE_PICTURE_WIDTH = Global.DEFAULT_PALETTE_PICTURE_WIDTH;
            public static readonly int PALETTE_PICTURE_HEIGHT = Global.DEFAULT_PALETTE_PICTURE_HEIGHT;
        }
    }
}