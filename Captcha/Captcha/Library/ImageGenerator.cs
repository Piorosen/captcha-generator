using System;
using System.Collections.Generic;
using System.Drawing;

namespace Captcha_Generator.Library
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

            pick(permutation, size);
        }

        private void ImageGenerator_events(object sender, List<int> e)
        {



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
