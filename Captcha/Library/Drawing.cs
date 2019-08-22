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
        PointF GetPosition(int num, int size, float fontSize)
        {
            int rW = Option.Instance.ImageSize.Width / size;

            return new PointF
            {
                // X = Option.Instance.Random.Next((int)Math.Floor(fontSize), (int)Math.Ceiling(rW - fontSize)) + (rW * num),
                // Y = Option.Instance.Random.Next((int)Math.Floor(fontSize), (int)Math.Ceiling(Option.Instance.ImageSize.Height - fontSize))
                X = (rW * num) + rW / 2 - (fontSize),
                Y = Option.Instance.ImageSize.Height / 2 - (fontSize)

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
                var size = Option.Instance.FontSize;
                var pos = GetPosition(i, value.Length, size);
                int range = Option.Instance.Random.Next(0, Option.Instance.Fonts.Families.Length);

                var font = new Font(Option.Instance.Fonts.Families[range], size);
                g.DrawString(value[i].ToString(), font, Brushes.Black, pos);
            }

            image.Save(savePath);

            return true;
        }
    }
}
