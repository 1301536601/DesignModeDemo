using System;

namespace DecoratorMode
{
    /// <summary>
    /// 装饰器模式
    /// 定义：动态的将责任附加到对象上，若要扩展功能，装饰者提供了比继承更有弹性的替换方案 避免违反开放-关闭原则
    /// 
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
            var price = man.Price();
            Console.WriteLine(price);
            Console.ReadKey();
        }
    }
}
