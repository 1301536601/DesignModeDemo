using System;

namespace Ioc
{
    /// <summary>
    /// Ioc 依赖倒置原则
    /// 理念：高层模块不应该依赖底层模块，两个都应该依赖抽象
    ///       抽象不应该依赖细节，细节应该依赖抽象
    ///
    /// 里式替换原则
    /// 子类型必须可以替换它们的父类
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
