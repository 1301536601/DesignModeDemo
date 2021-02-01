using System;
using System.Threading.Tasks;

using StrategyPattern.IService;

namespace StrategyPattern.Model
{
    public class LittleDuck : DuckBase, IFacerigService
    {
        public override void Quack()
        {
            Console.WriteLine("小鸭子正在呀呀呀的叫");
        }

        public override void Swim()
        {
            Console.WriteLine("小鸭子正在欢快的游泳");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task Facerig()
        {
            Console.WriteLine("小鸭子正在卖萌");
            return Task.CompletedTask;
        }
    }
}