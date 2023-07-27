using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace G1N_Font_Editor
{
    public class G1N
    {
        public long Magic { get; set; }
        public int FileSize { get; set; }
        public int HeaderSize { get; set; }
        public int Unk { get; set; }
        public int AtlasOffset { get; set; }
        public int PaletteCount { get; set; }
        public List<Color[]> Palettes { get; set; }
        public int TableCount { get; set; }
        public int[] TableOffsets { get; set; }
        public List<GlyphTable> GlyphTables { get; set; }
        public string RootFile { get; set; }
        public byte[] RawData { get; set; }
        public Dictionary<int, byte> GlyphConstants { get; set; }
        private struct CharID
        {
            public int CharCode { get; set; }
            public char Character { get; set; }
        }
        public class GlyphTable
        {
            public int Offset { get; set; }
            public List<Glyph> Glyphs { get; set; }
            public GlyphTable(int offset)
            {
                Offset = offset;
                Glyphs = new List<Glyph>();
            }

        }
        public G1N(string input)
        {
            RootFile = input;
            RawData = File.ReadAllBytes(RootFile);
            LoadData();
        }
        public void LoadData()
        {
            var ms = new MemoryStream(RawData);
            var br = new BinaryReader(ms);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            Magic = br.ReadInt64();
            FileSize = br.ReadInt32();
            HeaderSize = br.ReadInt32();
            Unk = br.ReadInt32();
            AtlasOffset = br.ReadInt32();
            PaletteCount = br.ReadInt32();
            TableCount = br.ReadInt32();
            TableOffsets = new int[TableCount];
            GlyphTables = new List<GlyphTable>();
            GlyphConstants = new Dictionary<int, byte>();
            Palettes = new List<Color[]>();
            for (int i = 0; i < PaletteCount; i++)
            {
                var colors = new List<Color>();
                for (int j = 0; j < 0x10; j++)
                {
                    colors.Add(Color.FromArgb(br.ReadInt32()));
                }
                Palettes.Add(colors.ToArray());
            }
            for (int i = 0; i < TableCount; i++)
            {
                TableOffsets[i] = br.ReadInt32();
            }
            for (int i = 0; i < TableCount; i++)
            {
                int offset = TableOffsets[i];
                var table = new GlyphTable(offset);
                br.BaseStream.Position = offset;
                int charCount = 0;
                CharID[] charIDs = new CharID[0xFFFF];
                for (int j = 0; j < 0xFFFF; j++)
                {
                    ushort ordinal = br.ReadUInt16();
                    if ((ordinal == 0 && charCount <= ordinal + 1) || ordinal > 0)
                    {
                        charCount = ordinal + 1;
                        charIDs[ordinal].CharCode = j;
                        charIDs[ordinal].Character = (char)j;
                    }
                }
                br.BaseStream.Position += 2;
                for (int j = 0; j < charCount; j++)
                {
                    var width = br.ReadByte();
                    var height = br.ReadByte();
                    var xoff = br.ReadByte();
                    var yoff = br.ReadByte();
                    var xadv = br.ReadByte();
                    var shadow = br.ReadByte();
                    br.BaseStream.Position += 2;
                    int pixelDataOffset = br.ReadInt32();
                    int pixelDataSize = 0;
                    long temp = br.BaseStream.Position;
                    if (j >= charCount - 1)
                    {
                        int nextOffset = 0;
                        if (i >= TableCount - 1) nextOffset = (int)br.BaseStream.Length;
                        else
                        {
                            br.BaseStream.Position = TableOffsets[i + 1] + (0xFFFF * 2) + 0xA;
                            nextOffset = br.ReadInt32() + AtlasOffset;
                        }
                        pixelDataSize = nextOffset - (pixelDataOffset + AtlasOffset);
                    }
                    else
                    {
                        br.BaseStream.Position += 8;
                        pixelDataSize = br.ReadInt32() - pixelDataOffset;
                    }
                    br.BaseStream.Position = AtlasOffset + pixelDataOffset;
                    var pixelData = br.ReadBytes(pixelDataSize);
                    br.BaseStream.Position = temp;
                    var glyph = new Glyph(charIDs[j].CharCode, charIDs[j].Character, width, height, xoff, yoff, xadv, shadow, pixelDataOffset, pixelDataSize, pixelData);
                    table.Glyphs.Add(glyph);
                }
                GlyphTables.Add(table);
            }
        }
    }
}