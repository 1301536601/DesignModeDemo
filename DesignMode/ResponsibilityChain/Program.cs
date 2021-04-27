using System;

namespace ResponsibilityChain
{

    /// <summary>
    /// 责任链模式
    /// 可以随时指定将某个职责更改给某个人 请求会找到当前那个人处理方法去执行它
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var request = new int[] { 12, 2, 51, 5214, 1, 41 };
            var one = new CurrentHandlerOne();
            var two = new CurrentHandlerTwo();
            var three = new CurrentHandlerThree();
            one.SetHandler(two);
            two.SetHandler(three);
            foreach (var item in request)
            {
                one.HandlerRequest(item);
            }

            Console.ReadKey();
        }

        public abstract class Handler
        {
            protected Handler _handler;

            public void SetHandler(Handler handler)
            {
                _handler = handler;
            }

            public abstract void HandlerRequest(int request);
        }

        public class CurrentHandlerOne : Handler
        {

            public override void HandlerRequest(int request)
            {
                if (request <= 10)
                {
                    Console.WriteLine($@"如果职责小于10由我处理{this.GetType().Name}");
                }
                else
                {
                    _handler.HandlerRequest(request);
                }
            }
        }

        public class CurrentHandlerTwo : Handler
        {
            public override void HandlerRequest(int request)
            {
                if (request > 0 && request <= 20)
                {
                    Console.WriteLine($@"如果职责大于10小于20由我处理{this.GetType().Name}");
                }
                else
                {
                    _handler.HandlerRequest(request);
                }
            }
        }

        public class CurrentHandlerThree : Handler
        {
            public override void HandlerRequest(int request)
            {
                if (request > 20)
                {
                    Console.WriteLine($@"如果职责大于20我处理{this.GetType().Name}");
                }
                else
                {
                    _handler.HandlerRequest(request);
                }
            }
        }
    }
}
