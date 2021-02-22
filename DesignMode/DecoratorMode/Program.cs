using System;

namespace DecoratorMode
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Body man = new Man();
            man = new Clothes(man);
            man = new Trousers(man);
            man = new Shoe(man);
            man = new Cap(man);
            man.Print();
            Console.ReadKey();
        }
    }
}
