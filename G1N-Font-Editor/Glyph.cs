using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;
using G1N_Font_Editor.Helpers;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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
        private bool _is8Bpp;
        private byte[] _pixelData;
        public byte[] PixelData { get { return _pixelData; } }
        private Bitmap _bmp;
        public Rectangle Rect { get; set; }
        public Glyph(int charCode, char character, byte width, byte height, sbyte baseline, byte xAdvance, sbyte xOffset, sbyte unk, byte[] pixelData, bool is8Bpp = false)
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
            _is8Bpp = is8Bpp;
            GetBitmap();
        }
        public Glyph(char character, bool is8Bpp = false) 
        {
            CharCode = (int)character;
            Character = character;
            _is8Bpp = is8Bpp;
        }
        public Glyph(char character, Bitmap bitmap, sbyte baseline, byte xAdvance, sbyte xOffset, bool is8Bpp)
        {
            Character = character;
            CharCode = (int)character;
            _bmp = bitmap;
            Width = (byte)bitmap.Width;
            Height = (byte)bitmap.Height;
            XOffset = xOffset;
            Baseline = baseline;
            XAdvance = xAdvance;
            _is8Bpp = is8Bpp;
            _pixelData = is8Bpp ? ConvertBitmapToRaw8Bpp(bitmap) : Convert8BppTo4Bpp(bitmap);
        }
        public Bitmap GetBitmap()
        {
            if (_bmp != null)
            {
                return _bmp;
            }
            int index = 0;
            var convertedData = _is8Bpp ? _pixelData : Convert4BppTo8Bpp(_pixelData);
            int imgWidth = Width;
            int imgHeight = Height;
            while ((imgWidth % 2 != 0 && !_is8Bpp) || imgWidth <= 0) imgWidth++;
            while (imgHeight <= 0) imgHeight++;
            _bmp = new Bitmap(imgWidth, imgHeight);
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
            _pixelData = _is8Bpp ? ConvertBitmapToRaw8Bpp(_bmp) : Convert8BppTo4Bpp(_bmp);
            return _bmp;
        }
        public byte[] Build(System.Windows.Media.GlyphTypeface glyphTypeface, Font font)
        {
            IDictionary<int, ushort> characterMap = glyphTypeface.CharacterToGlyphMap;
            ushort index;
            if (!characterMap.TryGetValue(Character, out index)) 
            {
                if (_pixelData == null) 
                    throw new Exception(Global.MESSAGEBOX_MESSAGES["MissingChar"].Replace("{Character}", Character.ToString()));
                return _pixelData;
            };
            var measureSize = FontHelper.MeasureSize(Character, font);
            int width = 
                (int)Math.Ceiling(
                    (
                        glyphTypeface.AdvanceWidths[index]
                        + Math.Abs(glyphTypeface.LeftSideBearings[index])
                        + Math.Abs(glyphTypeface.RightSideBearings[index])
                    ) * font.Size
                );
            while ((width % 2 != 0 && !_is8Bpp) || width <= 0)
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
            int startX = (int)Math.Ceiling((width - measureSize.Width - (Math.Abs(glyphTypeface.RightSideBearings[index]) * font.Size)) / 2);
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
                (byte)Math.Round((glyphTypeface.AdvanceWidths[index] + (glyphTypeface.LeftSideBearings[index] >= 0 ? 0 : Math.Abs(glyphTypeface.LeftSideBearings[index]))) * font.Size) : (byte)0;
            XOffset = glyphTypeface.AdvanceWidths[index] > 0 ? (sbyte)Math.Round(glyphTypeface.LeftSideBearings[index] < 0 ? 0 : glyphTypeface.LeftSideBearings[index] * font.Size * -1) : (sbyte)Math.Round(glyphTypeface.LeftSideBearings[index] * font.Size);

            // XAdvance = glyphTypeface.AdvanceWidths[index] > 0 ? (byte)Math.Round(width - (Math.Abs(glyphTypeface.RightSideBearings[index]) * font.Size)) : (byte)0;
            // XOffset = glyphTypeface.AdvanceWidths[index] > 0 ? (sbyte)0 : (sbyte)Math.Round(glyphTypeface.LeftSideBearings[index] * font.Size);

            Baseline = (sbyte)Math.Round(glyphTypeface.Baseline * font.Size);
            _pixelData = _is8Bpp ? ConvertBitmapToRaw8Bpp(_bmp) : Convert8BppTo4Bpp(_bmp);
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

        private byte[] ConvertBitmapToRaw8Bpp(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            byte[] rawBytes = new byte[width * height];
            BitmapData bmpData = bmp.LockBits(
                new Rectangle(0, 0, width, height),
                    ImageLockMode.ReadOnly,
                    PixelFormat.Format24bppRgb
            );
            int stride = bmpData.Stride;
            IntPtr ptr = bmpData.Scan0;
            int bytesPerPixel = 3;
            byte[] pixelData = new byte[stride * height];
            Marshal.Copy(ptr, pixelData, 0, pixelData.Length);
            bmp.UnlockBits(bmpData);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = y * stride + x * bytesPerPixel;
                    byte B = pixelData[index];
                    byte G = pixelData[index + 1];
                    byte R = pixelData[index + 2];

                    // Convert to grayscale
                    rawBytes[y * width + x] = ConvertToGrayscale(R, G, B);
                }
            }
            return rawBytes;
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
        private byte ConvertToGrayscale(byte r, byte g, byte b)
        {
            return (byte)(0.299 * r + 0.587 * g + 0.114 * b);
        }
        private string JoinBit(byte input)
        {
            return "0123456789ABCDEF"[input / 0x10].ToString();
        }
    }
}