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
        public bool Draw(string savePath)
        {
            Bitmap image = new Bitmap(200, 40);




            image.Save(savePath);
        }



    }
}
