using System;
namespace Captcha_Generator.Library
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

        public bool RandomFont = false;
        public bool NumberAndChar = false;
        public string SavePath = Environment.CurrentDirectory;
        public int Epoch = 4;
        public readonly Random Random = new Random();


    }
}
