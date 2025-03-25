using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using G1N_Font_Editor.Helpers;

namespace G1N_Font_Editor
{
    public class GlyphTable
    {
        public int Index { get; set; }
        public List<Glyph> Glyphs { get; set; }
        public Color[] Palettes { get; set; }
        private Bitmap _paletteImage;
        public Bitmap PaletteImage { get { return _paletteImage; } }
        public Color[] AlphaPalettes { get; set; }
        private List<TablePage> _tablePages;
        public List<TablePage> TablePages { get { return _tablePages; } }
        private bool _is8Bpp;
        public GlyphTable(int index, bool is8Bpp = false, Color[] palettes = null, Color[] alphaPalettes = null)
        {
            Index = index;
            Glyphs = new List<Glyph>();
            _tablePages = new List<TablePage>();
            _is8Bpp = is8Bpp;
            if (palettes != null)
            {
                Palettes = new Color[0x10];
                Array.Copy(palettes, Palettes, 0x10);
            }
            if (alphaPalettes != null)
            {
                AlphaPalettes = new Color[0x10];
                Array.Copy(alphaPalettes, AlphaPalettes, 0x10);
            }
        }
        public void AddGlyph(Glyph glyph)
        {
            if (Glyphs.Any(g => g.Character == glyph.Character))
                throw new Exception(Global.MESSAGEBOX_MESSAGES["CharExists"]);
            Glyphs.Add(glyph);
            CalculatePageCount(TablePages.LastOrDefault().GlyphStartIndex);
        }
        public void RemoveGlyph(int charCode)
        {
            var index = Glyphs.FindIndex(g => g.CharCode == charCode);
            if (index == -1) return;
            Glyphs.RemoveAt(index);
            var page = _tablePages.Find(p => p.GlyphStartIndex <= index && p.GlyphEndIndex > index);
            CalculatePageCount(page == null ? 0 : page.GlyphStartIndex);
        }
        public Bitmap ReloadPaletteImage()
        {
            int width = Global.DEFAULT_PALETTE_PICTURE_WIDTH;
            int height = Global.DEFAULT_PALETTE_PICTURE_HEIGHT;
            Bitmap result = new Bitmap(width, height);
            var palettes = Palettes == null ? Utils.GeneratePalettes() : Palettes;
            var colorWidth = width / palettes.Length;
            using (Graphics g = Graphics.FromImage(result))
            {
                for (int i = 0; i < palettes.Length; i++)
                {
                    var rect = new Rectangle(colorWidth * i, 0, colorWidth, height);
                    using (Brush brush = new SolidBrush(palettes[i]))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
            }
            _paletteImage = result;
            return result;
        }
        public Bitmap GetPaletteImage()
        {
            if (_paletteImage != null)
            {
                return _paletteImage;
            }
            return ReloadPaletteImage();
        }
        public int CalculatePageCount(int startIndex = 0, int padx = 4, int pady = 4)
        {
            int index = startIndex;
            _tablePages.RemoveAll(t => t.GlyphStartIndex >= index);
            int width = Global.DEFAULT_TEX_WIDTH, height = Global.DEFAULT_TEX_HEIGHT;
            while (index < Glyphs.Count())
            {
                var isFull = false;
                var tablePage = new TablePage(Glyphs, index);
                var rects = new List<Rectangle>();
                int currX = padx, currY = pady, lowestRowHeight = pady;
                while (!isFull && index < Glyphs.Count())
                {
                    if (currX + Glyphs[index].Width + padx > width)
                    {
                        currY = lowestRowHeight;
                        lowestRowHeight = currY + Glyphs[index].Height + pady;
                        if (lowestRowHeight + (index > 1 ? Glyphs[index - 1].Height : 0) > height)
                        {
                            isFull = true;
                            break;
                        }
                        currX = padx;
                    }
                    var boxRect = new Rectangle(currX, currY, Glyphs[index].Width + padx, Glyphs[index].Height + pady);
                    while (rects.Any(r => r.IntersectsWith(boxRect))) boxRect.Y++;
                    if (boxRect.Y + boxRect.Height < lowestRowHeight) lowestRowHeight = boxRect.Y + boxRect.Height;
                    rects.Add(boxRect);
                    Glyphs[index].Rect = new Rectangle(boxRect.X, boxRect.Y, Glyphs[index].Width, Glyphs[index].Height);
                    currX += Glyphs[index].Width + padx;
                    index++;
                }
                tablePage.GlyphEndIndex = index - 1;
                _tablePages.Add(tablePage);
            }
            if (_tablePages.Count == 0)
            {
                _tablePages.Add(new TablePage(Glyphs));
            }
            return _tablePages.Count();
        }
        public void Build(System.Windows.Media.GlyphTypeface glyphTypeface, Font font, char[] chars = null)
        {
            if (chars != null)
            {
                var dict = glyphTypeface.CharacterToGlyphMap;
                foreach (var ch in chars)
                {
                    if (Glyphs.FindIndex(g => g.Character == ch) != -1 || !dict.ContainsKey(ch)) continue;
                    var glyph = new Glyph(ch, _is8Bpp);
                    Glyphs.Add(glyph);
                }
            }
            foreach (var glyph in Glyphs)
            {
                glyph.Build(glyphTypeface, font);
            }
            Glyphs = Glyphs.OrderBy(g => g.Character).ToList();
        }
        public void ResetReloadStatus(bool status = true)
        {
            foreach (var page in _tablePages)
            {
                page.IsReloadNeeded = status;
            }
        }
        public class TablePage
        {
            public bool IsReloadNeeded { get; set; }
            public int GlyphStartIndex { get; set; }
            public int GlyphEndIndex { get; set; }
            private List<Glyph> _glyphs;
            private Bitmap _textureImage;
            public Bitmap TextureImage { get { return _textureImage; } }

            public TablePage(List<Glyph> glyphs, int glyphStartIndex = 0, int glyphEndIndex = 0) 
            {
                _glyphs = glyphs;
                GlyphStartIndex = glyphStartIndex;
                GlyphEndIndex = glyphEndIndex;
                IsReloadNeeded = true;
            }
            public Bitmap GetTextureImage()
            {
                if (_textureImage != null && !IsReloadNeeded)
                {
                    return _textureImage;
                }
                return ReloadTextureImage();
            }
            public Bitmap GetTextureImage(bool isReload)
            {
                if (!isReload)
                {
                    return _textureImage;
                }
                return ReloadTextureImage();
            }
            public Bitmap ReloadTextureImage()
            {
                int width = Global.DEFAULT_TEX_WIDTH,
                    height = Global.DEFAULT_TEX_HEIGHT;
                var result = new Bitmap(width, height);
                var glyphs = GetGlyphs();
                if (glyphs.Count > 0)
                {
                    using (Graphics g = Graphics.FromImage(result))
                    {
                        foreach (var glyph in glyphs)
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
                }
                _textureImage = result;
                IsReloadNeeded = false;
                return result;
            }
            private List<Glyph> GetGlyphs()
            {
                return _glyphs.Skip(GlyphStartIndex).Take(GlyphEndIndex - GlyphStartIndex + 1).ToList();
            }
        }
    }
}