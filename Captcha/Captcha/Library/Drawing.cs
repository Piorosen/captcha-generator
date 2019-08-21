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
        PointF GetPosition(int num, int size)
        {
            return new PointF
            {
                X = Option.Instance.Random.Next(0, Option.Instance.ImageSize.Width / size) + (Option.Instance.ImageSize.Width / size * num),
                Y = Option.Instance.Random.Next(0, Option.Instance.ImageSize.Height)
            };
        }

        public bool Draw(string savePath, string value)
        {
            Bitmap image = new Bitmap(Option.Instance.ImageSize.Width
                                        , Option.Instance.ImageSize.Height);
            
            Graphics g = Graphics.FromImage(image);
            g.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);

            for (int i = 0; i < value.Length; i++)
            {
                var pos = GetPosition(i, value.Length);
                var font = new Font(SystemFonts.DefaultFont.FontFamily, 20.0F);

                g.DrawString(value[i].ToString(), font, Brushes.Black, pos);
            }

            image.Save(savePath);

            return true;
        }
    }
}
