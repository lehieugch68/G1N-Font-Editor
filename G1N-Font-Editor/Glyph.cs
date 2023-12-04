using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace G1N_Font_Editor
{
    public class Glyph
    {
        public int CharCode { get; set; }
        public char Character { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte LeftSide { get; set; }
        public byte BottomSide { get; set; }
        public byte XAdv { get; set; }
        public byte Shadow { get; set; }
        public int DataOffset { get; set; }
        public int PixelDataSize { get; set; }
        private byte[] _pixelData;
        public byte[] PixelData { get { return _pixelData; } }
        private Bitmap Bmp;
        public Rectangle Rect;
        public Rectangle BoxRect;
        public Glyph(int charCode, char character, byte width, byte height, byte leftSide, byte bottomSide, byte xadv, byte shadow, int dataOffset, int pixelDataSize, byte[] pixelData)
        {
            CharCode = charCode;
            Character = character;
            Width = width;
            Height = height;
            LeftSide = leftSide;
            BottomSide = bottomSide;
            XAdv = xadv;
            Shadow = shadow;
            DataOffset = dataOffset;
            PixelDataSize = pixelDataSize;
            _pixelData = pixelData;
            GetBitmap();
        }
        public Bitmap GetBitmap()
        {
            if (Bmp != null)
            {
                return Bmp;
            }
            int index = 0;
            var convertedData = Convert4BppTo8Bpp(_pixelData);
            int imgWidth = Width % 2 == 0 ? Width : Width + 1;
            Bmp = new Bitmap(imgWidth, Height);
            for (int y = 0; y < Bmp.Height; y++)
            {
                for (int x = 0; x < Bmp.Width; x++)
                {
                    var pixel = convertedData[index++];
                    var color = Color.FromArgb(pixel << 0x18 | pixel << 0x10 | pixel << 8 | pixel);
                    Bmp.SetPixel(x, y, color);
                }
            }
            return Bmp;
        }
        public byte[] Build(System.Windows.Media.GlyphTypeface glyphTypeface, Font font)
        {
            IDictionary<int, ushort> characterMap = glyphTypeface.CharacterToGlyphMap;
            ushort index;
            if (!characterMap.TryGetValue(Character, out index)) return _pixelData;
            int width = (int)
                Math.Ceiling(
                    (
                        glyphTypeface.AdvanceWidths[index]
                        + Math.Abs(glyphTypeface.LeftSideBearings[index])
                        + Math.Abs(glyphTypeface.RightSideBearings[index])
                    ) * font.Size
                );
            if (width % 2 != 0)
                width++;
            int height = (int)
                Math.Ceiling(
                    (
                        glyphTypeface.Height
                        - (
                            glyphTypeface.TopSideBearings[index] < 0
                                ? glyphTypeface.TopSideBearings[index]
                                : 0
                        )
                        - (
                            glyphTypeface.BottomSideBearings[index] < 0
                                ? glyphTypeface.BottomSideBearings[index]
                                : 0
                        )
                    ) * font.Size
                );
            var measureSize = FontHelper.MeasureSize(Character, font);
            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(72, 72);
            int startX = (int)Math.Round((width - measureSize.Width) / 2);
            int startY =
                glyphTypeface.TopSideBearings[index] < 0
                    ? Math.Abs((int)(glyphTypeface.TopSideBearings[index] * font.Size))
                    : 0;
            using (var g = Graphics.FromImage(bmp))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                var rect = new Rectangle(
                    startX,
                    startY,
                    (int)measureSize.Width,
                    (int)measureSize.Height
                );
                g.DrawString(Character.ToString(), font, Brushes.White, rect);
            }
            Bmp = bmp;
            Width = (byte)Bmp.Width;
            Height = (byte)Bmp.Height;
            XAdv = (byte)Bmp.Width;
            LeftSide = (byte)(glyphTypeface.LeftSideBearings[index] * font.Size);
            BottomSide = (byte)(Height + (glyphTypeface.BottomSideBearings[index] * font.Size));
            _pixelData = Convert8BppTo4Bpp(Bmp);
            return _pixelData;
        }
        private byte[] Convert4BppTo8Bpp(byte[] input)
        {
            var result = new MemoryStream();
            using (var br = new BinaryReader(new MemoryStream(input)))
            {
                using (var bw = new BinaryWriter(result))
                {
                    while (br.BaseStream.Length > br.BaseStream.Position)
                    {
                        var pixel = br.ReadByte();
                        var low = pixel & 0xF;
                        var high = pixel >> 4;
                        bw.Write((byte)(high << 4));
                        bw.Write((byte)(low << 4));
                    }
                }
            }
            return result.ToArray();
        }
        private byte[] Convert8BppTo4Bpp(Bitmap bmp)
        {
            var ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms))
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        var high = bmp.GetPixel(x++, y).R;
                        var low = bmp.GetPixel(x, y).R;
                        bw.Write((byte)(high | (low >> 4)));
                    }
                }
            }
            if (ms.Length > PixelDataSize)
            {
                throw new Exception("Pixel size limit exceeded");
            }
            var result = new byte[PixelDataSize];
            ms.ToArray().CopyTo(result, 0);
            return result;
        }
    }
}