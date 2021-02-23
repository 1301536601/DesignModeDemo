using System;

namespace DecoratorMode
{
    public class WoMan : Body
    {
        public override void Print()
        {
            Console.WriteLine("女人");
        }

        public override double Price()
        {
            return 0.5D;
        }
    }
}