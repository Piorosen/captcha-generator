using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.Library
{
    public class Drawing
    {
        public bool Draw(string savePath, string value)
        {
            Bitmap image = new Bitmap(200, 40);
            
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);

            g.DrawString(value, SystemFonts.DefaultFont, Brushes.Black, 20, 10);

            image.Save(savePath);

            return true;
        }



    }
}
