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
        


    }
}
