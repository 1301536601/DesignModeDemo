using System;
using System.Threading.Tasks;

using StrategyPattern.IService;

namespace StrategyPattern.Model
{
    public class MaleDuck : DuckBase, IFlyService
    {
        public override void Quack()
        {
            Console.WriteLine("公鸭子正在呱呱呱的叫");
        }

        public override void Swim()
        {
            Console.WriteLine("公鸭子正在欢快的游泳");
        }

        public Task Fly()
        {
            Console.WriteLine("公鸭子正在飞");
            return Task.CompletedTask;
        }
    }
}