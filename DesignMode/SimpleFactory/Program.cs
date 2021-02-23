using System;

namespace SimpleFactory
{
    /// <summary>
    /// 简单工厂设计模式
    /// 优点：
    ///  （1）工厂类包含必要的逻辑判断，可以决定在什么时候创建哪一个产品的实例。客户端可以免除直接创建产品对象的职责
    ///  （2）客户端无需知道所创建具体产品的类名，只需知道参数即可
    ///  （3）也可以引入配置文件，在不修改客户端代码的情况下更换和添加新的具体产品类
    /// 缺点：
    /// （1）工厂类集中了所有产品的创建逻辑，职责过重，一旦异常，整个系统将受影响
    /// （2）使用简单工厂模式会增加系统中类的个数(引入新的工厂类)，增加系统的复杂度和理解难度
    /// （3）系统扩展困难，一旦增加新产品不得不修改工厂逻辑，在产品类型较多时，可能造成逻辑过于复杂
    /// （4）简单工厂模式使用了static工厂方法，造成工厂角色无法形成基于继承的等级结构。 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var add = SimpleArithmeticFactory.CreateFactory("+");
            var result = 0D;
            if (add != null)
            {
                add.NumberA = 12D;
                add.NumberB = 15D;
                result = add.GetResult();
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }


    public static class SimpleArithmeticFactory
    {
        public static BaseModel CreateFactory(string type)
        {
            BaseModel baseModel = null;
            switch (type)
            {
                case "+":
                    baseModel = new Addition();
                    return baseModel;
                case "-":
                    baseModel = new Subtraction();
                    return baseModel;
                case "*":
                    baseModel = new Multiplication();
                    return baseModel;
                case "/":
                    baseModel = new Division();
                    return baseModel;
            }
            return baseModel;
            ;
        }
    }

    /// <summary>
    /// 简单工厂模式
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// 数字A
        /// </summary>
        public double NumberA { get; set; }

        /// <summary>
        /// 数字B
        /// </summary>
        public double NumberB { get; set; }

        public abstract double GetResult();
    }

    public class Addition : BaseModel
    {
        public override double GetResult()
        {
            return base.NumberA + base.NumberB;
        }
    }

    public class Subtraction : BaseModel
    {
        public override double GetResult()
        {
            return base.NumberA - base.NumberB;
        }
    }

    public class Multiplication : BaseModel
    {
        public override double GetResult()
        {
            return base.NumberA * base.NumberB;
        }
    }

    public class Division : BaseModel
    {
        public override double GetResult()
        {
            if (base.NumberB <= 0)
            {
                return 0;
            }
            return base.NumberA / base.NumberB;
        }
    }
}
