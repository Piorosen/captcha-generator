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
            fontSize += fontSize / 5;
            int rW = Option.Instance.ImageSize.Width / size;

            return new PointF
            {
                X = Option.Instance.Random.Next((int)Math.Floor(fontSize / 2), (int)Math.Ceiling(rW - fontSize)) + (rW * num),
                Y = Option.Instance.Random.Next((int)Math.Floor(fontSize / 2), (int)Math.Ceiling(Option.Instance.ImageSize.Height - fontSize))
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
                var font = new Font(SystemFonts.DefaultFont.FontFamily, size);

                g.DrawString(value[i].ToString(), font, Brushes.Black, pos);
            }

            image.Save(savePath);

            return true;
        }
    }
}
