using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Captcha.Library
{
    public class ImageGenerator
    {
        event EventHandler<List<int>> events;
       
        public void Start(string savePath, int size, int epoch)
        {
            events += ImageGenerator_events;

            List<int> permutation = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                permutation.Add(i);
            }

            Option.Instance.Epoch = epoch;
            Option.Instance.SavePath = savePath;

            pick(permutation, size);
        }

        private char SelectNumber(int i)
        {
            char result = '\0';
            var value = new List<char>
            {
                '영', '일', '이',
                '삼', '사', '오',
                '육', '칠', '팔',
                '구'
            };

            if (Option.Instance.NumberAndChar)
            {
                if (Option.Instance.Random.Next(0, 2) == 1)
                {
                    result = (char)(i + '0');
                }else
                {
                    result = value[i];
                }
            }else
            {
                result = (char)(i + '0');
            }

            return result;
        }

        string ChangeNum(List<int> e)
        {
            string result = string.Empty;

            foreach (var i in e)
            {
                result += SelectNumber(i);
            }
            return result;
        }

        private string HashName(int epoch)
        {
            string result = string.Empty;
            for (int i = 0; i < epoch - 1; i++)
            {
                result += new Object().GetHashCode().ToString() + "-";
            }
            result += new Object().GetHashCode().ToString();

            return result;
        }

        private void ImageGenerator_events(object sender, List<int> e)
        {
            string filename = string.Empty;
            e.ForEach((value) =>
            {
                filename += value.ToString();
            });
            
            filename += "-" + HashName(4) + ".bmp";

            filename = Path.Combine(Option.Instance.SavePath, filename);

            var p = ChangeNum(e);

            Drawing draw = new Drawing();

            draw.Draw(filename, p);

        }

        void pick(List<int> data, int size)
        {
            for (int i = 0; i < 100; i++)
            {
                List<int> a = new List<int>
            {
                3,6,1,2

            };
                events?.Invoke(this, a);
            }
            
        }

    }
}
