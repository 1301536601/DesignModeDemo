using System;

namespace DecoratorMode
{
    public class WoMan : Body
    {
        public override void Print()
        {
            Console.WriteLine("女人");
        }
    }
}