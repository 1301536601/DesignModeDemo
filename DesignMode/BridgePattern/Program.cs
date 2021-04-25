using System;
using System.Collections.Generic;

namespace BridgePattern
{
    /// <summary>
    ///桥接模式
    /// 将抽象方法和实现部分分开，实现可以自由的变化
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            MobileType mobileA = new AMobile();
            mobileA.Set(new MobileGame());
            mobileA.Set(new MobileMessage());
            mobileA.Run();
          



            MobileType mobileB = new BMobile();
            mobileB.Set(new MobileGame());
            mobileB.Run();
            Console.ReadKey();
        }

        public abstract class Mobile
        {
            public abstract void Run();
        }

        public class MobileGame : Mobile
        {
            public override void Run()
            {
                Console.WriteLine("运行游戏");
            }
        }


        public class MobileMessage : Mobile
        {
            public override void Run()
            {
                Console.WriteLine("通讯轮");
            }
        }


        public abstract class MobileType
        {
            protected List<Mobile> Mobile = new List<Mobile>();

            public void Set(Mobile mobile)
            {
                Mobile.Add(mobile);
            }


            public abstract void Run();
        }

        public class AMobile : MobileType
        {
            public override void Run()
            {
                Console.WriteLine(GetType());
                foreach (var mobile in Mobile)
                {
                    mobile.Run();
                }
            }
        }

        public class BMobile : MobileType
        {
            public override void Run()
            {
                Console.WriteLine(GetType());
                foreach (var mobile in Mobile)
                {
                    mobile.Run();
                }
            }
        }
    }
}
