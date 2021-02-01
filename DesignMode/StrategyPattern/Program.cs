using System;

using StrategyPattern.Model;

namespace StrategyPattern
{
    /// <summary>
    /// 策略设计模式
    /// 原则：少用继承,多用组合
    /// 定义：定义实现族,分别进行封装，让他们之间可以互相替换，
    /// 场景定义：
    ///     有公鸭子和母鸭子 都会游泳和呱呱呱的叫 但是公鸭子会飞，母鸭子会下蛋
    ///     要求假如一个小鸭子 会游泳和呱呱呱的叫还会卖萌
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var maleDuck = new MaleDuck();
            maleDuck.Fly();
            maleDuck.Quack();
            maleDuck.Swim();

            Console.WriteLine("********************************");

            var femaleDuck = new FemaleDuck();
            femaleDuck.LayEggs();
            femaleDuck.Quack();
            femaleDuck.Swim();

            Console.WriteLine("********************************");

            var littleDuck = new LittleDuck();
            littleDuck.Facerig();
            littleDuck.Quack();
            littleDuck.Swim();
            Console.ReadKey();
        }
    }
}
