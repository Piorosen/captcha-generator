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

        private void ImageGenerator_events(object sender, List<int> e)
        {
            string filename = Option.Instance.SavePath;
            e.ForEach((value) =>
            {
                filename += value.ToString();
            });

            filename += "-" + GetHashCode().ToString();


            var p = ChangeNum(e);

            Drawing draw = new Drawing();

            draw.Draw(filename);

        }

        void pick(List<int> picked, int toPick)
        {
            int n = picked.Count;
            if (toPick == 0)
            {
                events?.Invoke(this, picked);   
            }

            // 고를 수 있는 가장 작은 번호를 계산한다.
            int smallest = picked.Count == 0 ? 1 : picked[picked.Count - 1] + 1;

            // 이 단계에서 원소 하나를 고른다.
            for (int next = smallest; next < n; ++next)
            {
                picked.Add(next);
                pick(picked, toPick - 1);
                picked.RemoveAt(picked.Count - 1);
            }
        }

    }
}
