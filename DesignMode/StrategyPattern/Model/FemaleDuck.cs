using System;
using System.Threading.Tasks;

namespace StrategyPattern.Model
{
    public class FemaleDuck : DuckBase, ILayEggsService
    {
        public override void Quack()
        {
            Console.WriteLine("母鸭子正在呀呀呀的叫");
        }

        public override void Swim()
        {
            Console.WriteLine("母鸭子正在欢快的游泳");
        }

        public Task LayEggs()
        {
            Console.WriteLine("母鸭子正在下蛋");
            return Task.CompletedTask;
        }
    }
}