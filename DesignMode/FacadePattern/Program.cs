using System;

namespace FacadePattern
{

    /// <summary>
    /// 外观模式
    /// 使用了依赖倒置原则和迪米特原则  将下层的方法和上层隔开
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            new CollectA().Get();
            new CollectB().Get();
        }

        public class CollectA
        {
            public void Get()
            {
                new MethodA().Get();
                new MethodB().Get();
            }
        }

        public class CollectB
        {
            public void Get()
            {
                new MethodA().Get();
                new MethodC().Get();
            }
        }

        public class MethodA
        {
            public void Get()
            {
                Console.WriteLine($@"{GetType()}");
            }
        }

        public class MethodB
        {
            public void Get()
            {
                Console.WriteLine($@"{GetType()}");
            }
        }

        public class MethodC
        {
            public void Get()
            {
                Console.WriteLine($@"{GetType()}");
            }
        }
    }
}
