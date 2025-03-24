using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace G1N_Font_Editor.Helpers
{
    public class GlyphCustomValue
    {
        public int AddCustomBaseLine { get; set; }
        public int AddCustomXOffset { get; set; }
        public int AddCustomAdvWidth { get; set; }
        public GlyphCustomValue(int addCustomBaseLine, int addCustomXOffset, int addCustomAdvWidth)
        {
            AddCustomBaseLine = addCustomBaseLine;
            AddCustomXOffset = addCustomXOffset;
            AddCustomAdvWidth = addCustomAdvWidth;
        }
    }
    public class Utils
    {
        public static string FolderBrowser(string filename)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = filename;
            string result = null;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                result = Path.GetDirectoryName(folderBrowser.FileName);
            }
            return result;
        }
        public static string SaveFile(string name, string filter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = name;
            saveFile.Filter = filter;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                return saveFile.FileName;
            }
            else
            {
                return null;
            }
        }
        public static string FileBrowser(string filename, string filter)
        {
            OpenFileDialog fileBrowser = new OpenFileDialog();
            fileBrowser.Filter = filter;
            fileBrowser.FileName = filename;
            string result = null;

            if (fileBrowser.ShowDialog() == DialogResult.OK)
            {
                result = fileBrowser.FileName;
            }
            return result;
        }
        public static string RemoveDuplicates(string input)
        {
            return new string(input.ToCharArray().Distinct().ToArray());
        }
        public static Color[] GeneratePalettes(byte[] rgb = null)
        {
            if (rgb == null)
            {
                rgb = Global.G1N_DEFAULT_RGB_COLOR;
            }
            var colors = new Color[0x10];
            for (int i = 0; i < colors.Length; i++)
            {
                var rgba = rgb.Concat(new byte[] { (byte)(i + (i * 0x10)) }).ToArray();
                colors[i] = Color.FromArgb(BitConverter.ToInt32(rgba, 0));
            }
            return colors;
        }
        public static char[] GetNonControlASCIICharacters()
        {
            char[] result = Enumerable.Range(0, 0xFF)
                .Select(c => (char)c)
                .Where(c => !char.IsControl(c))
                .ToArray();
            return result;
        }
        public static void OpenUrl(string url)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }
    }
}