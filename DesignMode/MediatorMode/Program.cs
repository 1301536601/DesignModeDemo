using System;
using static MediatorMode.Program;

namespace MediatorMode
{
    /// <summary>
    /// 中介者模式
    /// 一组定义良好但是复杂的方式进行通信/定制一个分布在多个类中的行为。又不想生成太多子类的场合
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var concreteMediator = new ConcreteMediator();
            var concreteMediatorOne = new ConcreteMediatorOne(concreteMediator);
            var concreteMediatorTwo = new ConcreteMediatorTwo(concreteMediator);
            concreteMediator.ConcreteOne = concreteMediatorOne;
            concreteMediator.ConcreteTwo = concreteMediatorTwo;
            concreteMediatorOne.Send("你好呀");
            Console.WriteLine("*************");
            concreteMediatorTwo.Send("我挺好的");
            Console.Read();
        }

        /// <summary>
        /// 抽象中介者
        /// </summary>
        public abstract class Mediator
        {
            public abstract void Send(string message, Colleague colleague);
        }


        /// <summary>
        /// 具体中介者
        /// </summary>
        public abstract class Colleague
        {
            protected Mediator Mediator;

            public Colleague(Mediator mediator)
            {
                Mediator = mediator;
            }
        }

        /// <summary>
        /// 抽象工作类
        /// </summary>
        public class ConcreteMediator : Mediator
        {

            private ConcreteMediatorOne _concreteMediatorOne;
            private ConcreteMediatorTwo _concreteMediatorTwo;

            public ConcreteMediatorOne ConcreteOne
            {
                set => _concreteMediatorOne = value;
            }

            public ConcreteMediatorTwo ConcreteTwo
            {
                set => _concreteMediatorTwo = value;
            }

            public override void Send(string message, Colleague colleague)
            {
                if (colleague == _concreteMediatorOne)
                {
                    _concreteMediatorOne.Notify(message);
                }
                else
                {
                    _concreteMediatorTwo.Notify(message);
                }
            }
        }

        /// <summary>
        /// 具体工作类
        /// </summary>
        public class ConcreteMediatorOne : Colleague
        {
            public ConcreteMediatorOne(Mediator mediator) : base(mediator)
            {
            }

            public void Send(string message)
            {
                Mediator.Send(message, this);
            }
            public void Notify(string message)
            {
                Console.WriteLine($@"1{typeof(ConcreteMediatorOne)}消息为{message}");
            }


        }

        /// <summary>
        /// 具体工作类
        /// </summary>
        public class ConcreteMediatorTwo : Colleague
        {
            public ConcreteMediatorTwo(Mediator mediator) : base(mediator)
            {
            }

            public void Send(string message)
            {
                Mediator.Send(message, this);
            }

            public void Notify(string message)
            {
                Console.WriteLine($@"2{typeof(ConcreteMediatorTwo)}消息为{message}");
            }


        }
    }
}
