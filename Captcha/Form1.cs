﻿using Captcha.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Option.Instance.LoadOption("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ImageGenerator gen = new ImageGenerator();
            gen.Start(@"C:\Users\Admin\Desktop\fol\my-char-4-6\train", 4, 6);
            gen.Start(@"C:\Users\Admin\Desktop\fol\my-char-4-6\test", 4, 1);
            MessageBox.Show("Complete");
        }
    }
}
