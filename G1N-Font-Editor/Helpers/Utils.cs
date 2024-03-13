using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace G1N_Font_Editor.Helpers
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
    public class GlyphCustomValue
    {
        public int AddCustomBaseLine { get; set; }
        public int AddCustomLeftSide { get; set; }
        public int AddCustomAdvWidth { get; set; }
        public GlyphCustomValue(int addCustomBaseLine, int addCustomLeftSide, int addCustomAdvWidth)
        {
            AddCustomBaseLine = addCustomBaseLine;
            AddCustomLeftSide = addCustomLeftSide;
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
        public static void AcceptNumberOnly(KeyPressEventArgs e, string input, int min = short.MinValue, int max = short.MaxValue)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '-' && input.Length <= 0) return;
                e.Handled = true;
            }
            int num;
            var result = $"{input}{e.KeyChar}";
            if (int.TryParse(result, out num))
            {
                if (num < min || num > max) e.Handled = true;
            }
            else e.Handled = true;
        }
    }
}