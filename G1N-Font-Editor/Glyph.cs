using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace G1N_Font_Editor
{
    public class Glyph
    {
        public int CharCode { get; set; }
        public char Character { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public byte LeftSide { get; set; }
        public byte Baseline { get; set; }
        public byte XAdv { get; set; }
        public sbyte Unk { get; set; }
        public int DataOffset { get; set; }
        public int PixelDataSize { get; set; }
        public long PixelDataPointer { get; set; }
        private byte[] _pixelData;
        public byte[] PixelData { get { return _pixelData; } }
        private Bitmap Bmp;
        public Rectangle Rect;
        public Rectangle BoxRect;
        public Glyph(int charCode, char character, byte width, byte height, byte leftSide, byte baseline, byte xadv, sbyte unk, int dataOffset, int pixelDataSize, byte[] pixelData)
        {
            CharCode = charCode;
            Character = character;
            Width = width;
            Height = height;
            LeftSide = leftSide;
            Baseline = baseline;
            XAdv = xadv;
            Unk = unk;
            DataOffset = dataOffset;
            PixelDataSize = pixelDataSize;
            _pixelData = pixelData;
            GetBitmap();
        }
        public Glyph(char character) 
        {
            CharCode = (int)character;
            Character = character;
            PixelDataSize = 0;
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
            //MessageBox.Show($"{glyphTypeface.AdvanceWidths[index]} / {glyphTypeface.LeftSideBearings[index]} / {glyphTypeface.RightSideBearings[index]}");
            int width = (int)
                Math.Ceiling(
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
            var measureSize = FontHelper.MeasureSize(Character, font);
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
            Bmp = bmp;
            Width = (byte)Bmp.Width;
            Height = (byte)Bmp.Height;
            XAdv = (byte)Math.Ceiling((glyphTypeface.AdvanceWidths[index] + (glyphTypeface.LeftSideBearings[index] > 0 ? glyphTypeface.LeftSideBearings[index] : 0)) * font.Size);
            LeftSide = (byte)Math.Floor(glyphTypeface.LeftSideBearings[index] * font.Size);
            Baseline = (byte)Math.Ceiling((glyphTypeface.Baseline * font.Size));
            _pixelData = Convert8BppTo4Bpp(Bmp);
            Unk = (sbyte)((_pixelData.Length / Height) * -1);
            PixelDataSize = _pixelData.Length;
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