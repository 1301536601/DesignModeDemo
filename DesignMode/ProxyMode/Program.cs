using System;

namespace ProxyMode
{
    /// <summary>
    /// 代理模式：为其它对象提供一种代理以控制对这个对象的访问
    ///
    /// 通过代理类去访问真实类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Pursuing pursuing = new Pursuing() { Name = "橙橙" };
            ProxySendFlowers proxy = new ProxySendFlowers(pursuing);
            proxy.BuyFlowers();
            proxy.SendFlowers();
            Console.ReadKey();
        }
    }
}
