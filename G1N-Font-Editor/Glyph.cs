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
        public byte XOffset { get; set; }
        public byte YOffset { get; set; }
        public byte XAdv { get; set; }
        public byte Shadow { get; set; }
        public int DataOffset { get; set; }
        public int PixelDataSize { get; set; }
        private byte[] _pixelData;
        public byte[] PixelData { get { return _pixelData; } }
        private Bitmap Bmp;
        public Glyph(int charCode, char character, byte width, byte height, byte xoff, byte yoff, byte xadv, byte shadow, int dataOffset, int pixelDataSize, byte[] pixelData)
        {
            CharCode = charCode;
            Character = character;
            Width = width;
            Height = height;
            XOffset = xoff;
            YOffset = yoff;
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
        public byte[] SetBitmap(Bitmap bmp)
        {
            Bmp = bmp;
            Width = (byte)Bmp.Width;
            Height = (byte)Bmp.Height;
            XAdv = (byte)Bmp.Width;
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