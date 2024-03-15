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
        public static readonly string MESSAGEBOX_TITLE = "G1N Font Editor";
        public static FontFamily TTF_FONT_FAMILY;
        public static string TTF_FONT_FAMILY_NAME;
        public static Glyph CONTEXT_MENU_SELECTED_GLYPH;
        public static int SELECTED_G1N_FONT_ID = -1;
        public static int DEFAULT_TTF_FONT_SIZE = 36;
        public static int DEFAULT_TEX_WIDTH = 256;
        public static int DEFAULT_TEX_HEIGHT = 256;
        public static int DEFAULT_PALETTE_PICTURE_WIDTH = 320;
        public static int DEFAULT_PALETTE_PICTURE_HEIGHT = 50;
        public static readonly string LABEL_PAGE = "Page";
        public static readonly string LABEL_NOT_AVAILABLE = "N/A";
        public static readonly string APP_DIRECTORY = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string G1N_FILE_FILTER = "G1N Files (*.g1n)|*.g1n|All Files (*.*)|*.*";
        public static readonly string TXT_FILE_FILTER = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
        public static readonly string FONT_FILE_FILTER = "Font Files (*.ttf)|*.ttf|All Files (*.*)|*.*";
        public static readonly string PNG_FILE_FILTER = "PNG Files (*.png)|*.png|All Files (*.*)|*.*";
        public static readonly string IMAGE_FILE_FILTER = "Image Files|*.bmp;*.jpg;*.png|All Files|*.*";
        public static readonly byte[] G1N_DEFAULT_SIGNATURE_BYTES = new byte[]
        {
            0x5F, 0x4E, 0x31, 0x47, 0x30, 0x30, 0x30, 0x30
        };
        public static readonly int G1N_DEFAULT_HEADER_SIZE = 0x20;
        public static readonly int G1N_DEFAULT_COLOR_COUNT = 0x10;
        public static readonly byte[] G1N_DEFAULT_RGB_COLOR = new byte[]
        {
            0xFF, 0xFF, 0xFF
        };
        public static Dictionary<string, string> MESSAGEBOX_MESSAGES = new Dictionary<string, string>()
        {
            { "InProgress", "An error occurred: Another process in progress." }
        };
        public static Dictionary<string, string> PROGRESS_MESSAGES = new Dictionary<string, string>()
        {
            { "Done", "Done" },
            { "ReadingG1N", "Reading G1N file..." },
            { "PreaparingBMP", "Preparing bitmap image..." },
        };
    }
}