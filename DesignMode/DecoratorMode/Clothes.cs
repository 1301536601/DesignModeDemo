using System;

namespace DecoratorMode
{
    public class Clothes : Body
    {
        private readonly Body _body;

        public Clothes(Body body)
        {
            _body = body;
        }

        public override void Print()
        {
            _body.Print();
            Console.WriteLine("穿上衣服");
        }

        public override double Price()
        {
            return _body.Price() + 1D;
        }
    }

    public class Trousers : Body
    {
        private readonly Body _body;

        public Trousers(Body body)
        {
            _body = body;
        }
        public override void Print()
        {
            _body.Print();
            Console.WriteLine("穿上裤子");
        }

        public override double Price()
        {
            return _body.Price() + 1D;
        }
    }

    public class Shoe : Body
    {
        private readonly Body _body;

        public Shoe(Body body)
        {
            _body = body;
        }
        public override void Print()
        {
            _body.Print();
            Console.WriteLine("穿上鞋子");
        }

        public override double Price()
        {
            return _body.Price() + 1D;
        }
    }

    public class Cap : Body
    {
        private readonly Body _body;

        public Cap(Body body)
        {
            _body = body;
        }
        public override void Print()
        {
            _body.Print();
            Console.WriteLine("戴上帽子");
        }

        public override double Price()
        {
            return _body.Price() + 1D;
        }
    }
}