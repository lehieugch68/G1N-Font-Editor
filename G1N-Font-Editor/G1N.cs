using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using G1N_Font_Editor.Helpers;

namespace G1N_Font_Editor
{
    public class G1N
    {
        public byte[] Signature { get; set; }
        public int FileSize { get; set; }
        public int HeaderSize { get; set; }
        public int ColorCount { get; set; } // Not sure
        public int AtlasOffset { get; set; }
        public int PaletteCount { get; set; }
        public int TableCount { get; set; }
        public List<GlyphTable> GlyphTables { get; set; }
        public string RootFile { get; set; }
        public byte[] _rawData;
        public byte[] RawData { get { return _rawData; } }
        private struct CharID
        {
            public int CharCode { get; set; }
            public char Character { get; set; }
        }
        public G1N(string input)
        {
            RootFile = input;
            _rawData = File.ReadAllBytes(RootFile);
            LoadData();
        }
        public G1N(int totalPage)
        {
            Signature = Global.G1N_DEFAULT_SIGNATURE_BYTES;
            ColorCount = Global.G1N_DEFAULT_COLOR_COUNT;
            TableCount = totalPage;
            PaletteCount = totalPage;
            HeaderSize = Global.G1N_DEFAULT_HEADER_SIZE + (totalPage * (4 + (4 * 0x10)));
            GlyphTables = new List<GlyphTable>();
            var palettes = Utils.GeneratePalettes(Global.G1N_DEFAULT_RGB_COLOR);
            for (int i = 0; i < TableCount; i++)
            {
                var table = new GlyphTable(i, palettes);
                GlyphTables.Add(table);
            }
        }
        public void LoadData()
        {
            var ms = new MemoryStream(_rawData);
            var br = new BinaryReader(ms);
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            Signature = br.ReadBytes(8);
            if (!Signature.SequenceEqual(Global.G1N_DEFAULT_SIGNATURE_BYTES))
                throw new Exception(Global.MESSAGEBOX_MESSAGES["UnsupportedFormat"]);
            FileSize = br.ReadInt32();
            HeaderSize = br.ReadInt32();
            ColorCount = br.ReadInt32();
            AtlasOffset = br.ReadInt32();
            PaletteCount = br.ReadInt32();
            TableCount = br.ReadInt32();
            var tableOffsets = new int[TableCount];
            GlyphTables = new List<GlyphTable>();
            var palettes = new List<Color[]>();
            for (int i = 0; i < TableCount; i++)
            {
                tableOffsets[i] = br.ReadInt32();
            }
            for (int i = 0; i < PaletteCount; i++)
            {
                var colors = new List<Color>();
                for (int j = 0; j < 0x10; j++)
                {
                    colors.Add(Color.FromArgb(br.ReadInt32()));
                }
                palettes.Add(colors.ToArray());
            }
            for (int i = 0; i < TableCount; i++)
            {
                int offset = tableOffsets[i];
                var table = new GlyphTable(i, palettes[i]);
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
                    var xoff = br.ReadSByte();
                    var baseline = br.ReadSByte();
                    var xadv = br.ReadByte();
                    var unk = br.ReadSByte();
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
                            br.BaseStream.Position = tableOffsets[i + 1] + (0xFFFF * 2) + 0xA;
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
                    var glyph = new Glyph(charIDs[j].CharCode, charIDs[j].Character, width, height, baseline, xadv, xoff, unk, pixelData);
                    table.Glyphs.Add(glyph);
                }
                GlyphTables.Add(table);
            }
        }
        private void CalculateHeaderData()
        {
            TableCount = GlyphTables.Count;
            PaletteCount = GlyphTables.Count;
            HeaderSize = Global.G1N_DEFAULT_HEADER_SIZE + (GlyphTables.Count * (4 + (4 * 0x10)));
        }
        public void AddGlyphTables(int num = 1)
        {
            var palettes = Utils.GeneratePalettes(Global.G1N_DEFAULT_RGB_COLOR);
            for (int i = 0; i < num; i++)
            {
                var table = new GlyphTable(GlyphTables.Count, palettes);
                GlyphTables.Add(table);
            }
            CalculateHeaderData();
        }
        public void RemoveGlyphTable(int index)
        {
            if (GlyphTables.Count <= 1)
                throw new Exception(Global.MESSAGEBOX_MESSAGES["EmptyG1N"]);
            GlyphTables.RemoveAt(index);
            for (int i = 0; i < GlyphTables.Count; i++)
            {
                GlyphTables[i].Index = i;
            }
            CalculateHeaderData();
        }
        public byte[] Build(GlyphCustomValue glyphCustomValue)
        {
            MemoryStream ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(Signature);
                bw.Write((uint)0);
                bw.Write(HeaderSize);
                bw.Write(ColorCount);
                bw.Write((uint)0);
                bw.Write(PaletteCount);
                bw.Write(TableCount);
                long tablePointerOffset = bw.BaseStream.Position;
                int[] tablePointer = new int[TableCount];
                bw.BaseStream.Position += PaletteCount * 4;
                foreach (var table in GlyphTables)
                {
                    foreach (var color in table.Palettes) bw.Write(color.ToArgb());
                }
                int atlasOffset = 0;
                for (int i = 0; i < TableCount; i++)
                {
                    tablePointer[i] = (int)bw.BaseStream.Position;
                    ushort ordinal = 0;
                    for (int j = 0; j < 0xFFFF; j++)
                    {
                        var isExists = GlyphTables[i].Glyphs.Any(g => g.Character == (char)j);
                        if (isExists)
                            bw.Write(ordinal++);
                        else
                            bw.Write((ushort)0);
                    }
                    bw.Write((ushort)0);
                    for (int j = 0; j < GlyphTables[i].Glyphs.Count; j++)
                    {
                        var glyph = GlyphTables[i].Glyphs[j];
                        if (glyph == null) continue;
                        bw.Write(glyph.Width);
                        bw.Write(glyph.Height);
                        bw.Write((byte)(glyph.XOffset + glyphCustomValue.AddCustomXOffset));
                        bw.Write((byte)(glyph.Baseline + glyphCustomValue.AddCustomBaseLine));
                        bw.Write((byte)(glyph.XAdvance + glyphCustomValue.AddCustomAdvWidth));
                        bw.Write(glyph.Unk);
                        bw.Write((byte)(glyph.XOffset + glyphCustomValue.AddCustomXOffset));
                        bw.Write(glyph.Height);
                        bw.Write(atlasOffset);
                        atlasOffset += glyph.PixelData.Length;
                    }  
                }
                AtlasOffset = (int)bw.BaseStream.Position;
                for (int i = 0; i < TableCount; i++)
                {
                    for (int j = 0; j < GlyphTables[i].Glyphs.Count; j++)
                    {
                        var glyph = GlyphTables[i].Glyphs[j];
                        bw.Write(GlyphTables[i].Glyphs[j].PixelData);
                    }
                }
                bw.BaseStream.Position = 8;
                bw.Write((int)bw.BaseStream.Length);
                bw.BaseStream.Position = 0x14;
                bw.Write(AtlasOffset);
                bw.BaseStream.Position = 0x20;
                for (int i = 0; i < TableCount; i++) 
                {
                    bw.Write(tablePointer[i]);
                }
            }
            _rawData = ms.ToArray();
            return _rawData;
        }
    }
}