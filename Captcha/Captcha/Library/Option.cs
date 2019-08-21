using System;
namespace Captcha.Library
{
    public class Option : Singleton<Option>
    {
        public Option()
        {


        }

        public bool LoadOption(string filename)
        {



            return false;
        }

        public bool RandomFont = true;
        public bool NumberAndChar = true;
        public string SavePath = Environment.CurrentDirectory;
        public int Epoch = 4;
        public readonly Random Random = new Random();


    }
}
