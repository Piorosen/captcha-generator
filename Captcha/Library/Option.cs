﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;

namespace Captcha.Library
{
    public class Option : Singleton<Option>
    {
        public Option()
        {


        }

        public bool LoadOption(string filename)
        {
            var list = Directory.GetFiles(@"C:\Users\Admin\Desktop\git\captcha-generator\Captcha\Captcha\Font", "*.ttf");

            foreach (var i in list)
            {
                Fonts.AddFontFile(i);
            }

            return false;
        }

        public bool RandomFont = true;
        public bool NumberAndChar = true;
        public string SavePath = Environment.CurrentDirectory;
        public int Epoch = 4;
        public readonly Random Random = new Random();

        public Size RangeFontSize = new Size(10, 20);

        public float FontSize
        {
            get
            {
                return (float)(Random.NextDouble() * (RangeFontSize.Height - RangeFontSize.Width) + RangeFontSize.Width);
            }
        }

        public Size ImageSize = new Size(200, 40);

        public PrivateFontCollection Fonts = new PrivateFontCollection();

    }
}
