using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace G1N_Font_Editor
{
    public static class Extension
    {
        public static Size ResizeKeepAspect(this Size src, int width, int height)
        {
            decimal rnd = Math.Min((decimal)width / src.Width, (decimal)height / src.Height);
            return new Size((int)Math.Round(src.Width * rnd), (int)Math.Round(src.Height * rnd));
        }
    }
}