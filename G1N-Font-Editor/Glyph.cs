using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;
using G1N_Font_Editor.Helpers;

namespace G1N_Font_Editor
{
    public class Glyph
    {
        public int CharCode { get; set; }
        public char Character { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public sbyte XOffset { get; set; }
        public sbyte Baseline { get; set; }
        public byte XAdvance { get; set; }
        public sbyte Unk { get; set; }
        private byte[] _pixelData;
        public byte[] PixelData { get { return _pixelData; } }
        private Bitmap _bmp;
        public Rectangle Rect { get; set; }
        public Glyph(int charCode, char character, byte width, byte height, sbyte baseline, byte xAdvance, sbyte xOffset, sbyte unk, byte[] pixelData)
        {
            CharCode = charCode;
            Character = character;
            Width = width;
            Height = height;
            XOffset = xOffset;
            Baseline = baseline;
            XAdvance = xAdvance;
            Unk = unk;
            _pixelData = pixelData;
            GetBitmap();
        }
        public Glyph(char character) 
        {
            CharCode = (int)character;
            Character = character;
        }
        public Glyph(char character, Bitmap bitmap, sbyte baseline, byte xAdvance, sbyte xOffset)
        {
            Character = character;
            CharCode = (int)character;
            _bmp = bitmap;
            Width = (byte)bitmap.Width;
            Height = (byte)bitmap.Height;
            XOffset = xOffset;
            Baseline = baseline;
            XAdvance = xAdvance;
        }
        public Bitmap GetBitmap()
        {
            if (_bmp != null)
            {
                return _bmp;
            }
            int index = 0;
            var convertedData = Convert4BppTo8Bpp(_pixelData);
            int imgWidth = Width % 2 == 0 ? Width : Width + 1;
            _bmp = new Bitmap(imgWidth, Height);
            for (int y = 0; y < _bmp.Height; y++)
            {
                for (int x = 0; x < _bmp.Width; x++)
                {
                    var pixel = convertedData[index++];
                    var color = Color.FromArgb(pixel << 0x18 | pixel << 0x10 | pixel << 8 | pixel);
                    _bmp.SetPixel(x, y, color);
                }
            }
            return _bmp;
        }
        public Bitmap SetBimap(string filePath)
        {
            var bitmap = new Bitmap(filePath);
            if (bitmap.Width > sbyte.MaxValue || bitmap.Height > sbyte.MaxValue) 
                throw new Exception(Global.MESSAGEBOX_MESSAGES["ImageTooLarge"]);
            _bmp = bitmap;
            Width = Convert.ToByte(bitmap.Width);
            Height = Convert.ToByte(bitmap.Height);
            _pixelData = Convert8BppTo4Bpp(_bmp);
            return _bmp;
        }
        public byte[] Build(System.Windows.Media.GlyphTypeface glyphTypeface, Font font)
        {
            IDictionary<int, ushort> characterMap = glyphTypeface.CharacterToGlyphMap;
            ushort index;
            if (!characterMap.TryGetValue(Character, out index)) return _pixelData;
            var measureSize = FontHelper.MeasureSize(Character, font);
            int width = 
                (int)Math.Ceiling(
                    (
                        glyphTypeface.AdvanceWidths[index]
                        + Math.Abs(glyphTypeface.LeftSideBearings[index])
                        + Math.Abs(glyphTypeface.RightSideBearings[index])
                    ) * font.Size
                );
            while (width % 2 != 0 || width <= 0)
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
            while (height % 2 != 0 || height <= 0)
                height++;
            Bitmap bmp = new Bitmap(width, height);
            bmp.SetResolution(72, 72);
            int startX = (int)Math.Ceiling((width - measureSize.Width) / 2);
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
            _bmp = bmp;
            Width = (byte)_bmp.Width;
            Height = (byte)_bmp.Height;
            XAdvance = glyphTypeface.AdvanceWidths[index] > 0 ? 
                (byte)Math.Round((glyphTypeface.AdvanceWidths[index] + Math.Abs(glyphTypeface.LeftSideBearings[index])) * font.Size) : (byte)0;
            XOffset = (sbyte)Math.Round(glyphTypeface.LeftSideBearings[index] * font.Size * (glyphTypeface.LeftSideBearings[index] < 0 ? 1 : -1));
            Baseline = (sbyte)Math.Round((glyphTypeface.Baseline * font.Size));
            _pixelData = Convert8BppTo4Bpp(_bmp);
            Unk = (sbyte)((_pixelData.Length / Height) * -1);
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
                        string color = string.Empty;
                        color += JoinBit(bmp.GetPixel(x, y).R);
                        color += JoinBit(bmp.GetPixel(++x, y).R);
                        bw.Write(byte.Parse(color, NumberStyles.HexNumber));
                    }
                }
            }
            return ms.ToArray();
        }

        private string JoinBit(byte input)
        {
            string res = string.Empty;
            if (input <= 0x0F)
                res = "0";
            if (0x0F < input && input <= 0x20)
                res = "1";
            if (0x20 < input && input <= 0x30)
                res = "2";
            if (0x30 < input && input <= 0x40)
                res = "3";
            if (0x40 < input && input <= 0x50)
                res = "4";
            if (0x50 < input && input <= 0x60)
                res = "5";
            if (0x60 < input && input <= 0x70)
                res = "6";
            if (0x70 < input && input <= 0x80)
                res = "7";
            if (0x80 < input && input <= 0x90)
                res = "8";
            if (0x90 < input && input <= 0xA0)
                res = "9";
            if (0xA0 < input && input <= 0xB0)
                res = "A";
            if (0xB0 < input && input <= 0xC0)
                res = "B";
            if (0xC0 < input && input <= 0xD0)
                res = "C";
            if (0xD0 < input && input <= 0xE0)
                res = "D";
            if (0xE0 < input && input <= 0xF0)
                res = "E";
            if (0xF0 < input && input <= 0xFF)
                res = "F";
            return res;
        }
    }
}