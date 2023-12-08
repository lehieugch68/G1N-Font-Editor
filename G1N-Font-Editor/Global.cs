using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace G1N_Font_Editor
{
    public static class Global
    {
        public static bool IS_BUSY = false;
        public static G1N G1N_FILE;
        public static Color DEFAULT_PICTURE_COLOR = SystemColors.ScrollBar;
        public static readonly string MESSAGEBOX_TITLE = "G1N Font Editor";
        public static Font TTF_FONT;
        public static int DEFAULT_TTF_FONT_SIZE = 18;
        public static int DEFAULT_TEX_WIDTH = 512;
        public static int DEFAULT_TEX_HEIGHT = 512;
        public static readonly string APP_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string G1N_FILE_FILTER = "G1N files (*.g1n)|*.g1n|All files (*.*)|*.*";
        public static readonly string TXT_FILE_FILTER = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        public static Dictionary<string, string> JSON_CONFIG;
        public static Dictionary<string, string> MESSAGEBOX_MESSAGES = new Dictionary<string, string>()
        {
            { "InProgress", "An error occurred: Another process in progress." }
        };
    }
}