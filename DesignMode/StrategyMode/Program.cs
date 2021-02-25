using System;

namespace StrategyMode
{
    class Program
    {
        /// <summary>
        /// 策略设计模式： 采用类似简单工厂方法
        ///  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var c = new Context("现金收费");
            var result = c.GetResult(100);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
