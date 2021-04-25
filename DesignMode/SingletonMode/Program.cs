using System;

namespace SingletonMode
{
    /// <summary>
    /// 单例模式
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Singleton
        {
            private static Singleton _singleton;
            public static readonly object LockCurrent = new object();

            public static Singleton GetSingleton()
            {
                if (_singleton != null)
                {
                    return _singleton;
                }
                lock (LockCurrent)
                {
                    if (_singleton == null)
                    {
                        return new Singleton();
                    }
                }
                return _singleton;
            }


        }
    }
}
