using System;

namespace DecoratorMode
{
    public class Man : Body
    {
        public override void Print()
        {
            Console.WriteLine("男人");
        }
    }
}