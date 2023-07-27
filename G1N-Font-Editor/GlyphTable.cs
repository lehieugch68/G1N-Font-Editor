using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace G1N_Font_Editor
{
    public class GlyphTable
    {
        public int Index { get; set; }
        public int Offset { get; set; }
        public List<Glyph> Glyphs { get; set; }
        private Bitmap _bmpPreview;
        public Bitmap BmpPreview { get { return _bmpPreview; } }
        public GlyphTable(int index, int offset)
        {
            Index = index;
            Offset = offset;
            Glyphs = new List<Glyph>();
        }
        public Bitmap ReloadBitmap(int padx = 4, int pady = 4)
        {
            int width = Constant.MIN_WIDTH;
            int height = Constant.MIN_HEIGHT;
            MeasureBitmapSizeFromGlyphs(Glyphs, padx, pady, ref width, ref height);
            Bitmap result = new Bitmap(width, height);
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
                            bmp.Width,
                            bmp.Height);
                    }
                }
            }
            _bmpPreview = result;
            return result;
        }
        public Bitmap GetBitmap()
        {
            if (_bmpPreview != null)
            {
                return _bmpPreview;
            }
            return ReloadBitmap();
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
                var rect = new Rectangle(currX, currY, glyphs[i].Width + padx, glyphs[i].Height + pady);
                while (rects.Any(r => r.IntersectsWith(rect))) rect.Y++;
                if (rect.Y + rect.Height < lowestRowHeight) lowestRowHeight = rect.Y + rect.Height;
                rects.Add(rect);
                glyphs[i].Rect = rect;
                currX += glyphs[i].Width + padx;
            }
            return true;
        }
        public static class Constant
        {
            public static readonly int MIN_WIDTH = 256;
            public static readonly int MIN_HEIGHT = 256;
        }
    }
}