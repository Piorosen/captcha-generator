using System;
namespace Captcha_Generator.Library
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance = null;
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    instance = instance ?? new T();
                }
                return instance;
            }
        }
    }
}
