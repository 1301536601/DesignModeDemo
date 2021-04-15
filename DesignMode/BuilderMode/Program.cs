using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace BuilderMode
{

    /// <summary>
    /// 建造者模式
    /// 优点 同一种产品 可以有不同的实现
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Director builder = new Director();
            CurrentMethod methodA = new CurrentMethodA();
            CurrentMethod methodB = new CurrentMethodB();
            builder.Construct(methodA);
            var p1 = methodA.GetResult();
            p1.Show();

            builder.Construct(methodB);
            var p2 = methodB.GetResult();
            p2.Show();
            Console.ReadKey();
        }

        public class Director
        {
            public void Construct(CurrentMethod builder)
            {
                builder.MethodA();
                builder.MethodB();
                builder.MethodC();
            }

        }


        public class Product
        {
            private List<string> _list = new List<string>();

            public void Add(string add)
            {
                _list.Add(add);
            }

            public void Show()
            {
                Console.WriteLine(GetType());
                foreach (var item in _list)
                {
                    Console.WriteLine(item);
                }
            }
        }



        public abstract class CurrentMethod
        {
            public abstract void MethodA();

            public abstract void MethodB();

            public abstract void MethodC();

            public abstract Product GetResult();
        }

        public class CurrentMethodA : CurrentMethod
        {
            private Product _product = new Product();
            public override void MethodA()
            {
                _product.Add(GetType().ToString());
            }

            public override void MethodB()
            {
                _product.Add(GetType().ToString());
            }

            public override void MethodC()
            {
                _product.Add(GetType().ToString());
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

        public class CurrentMethodB : CurrentMethod
        {
            private Product _product = new Product();

            public override void MethodA()
            {
                _product.Add(GetType().ToString());
            }

            public override void MethodB()
            {
                _product.Add(GetType().ToString());
            }

            public override void MethodC()
            {
                _product.Add(GetType().ToString());
            }

            public override Product GetResult()
            {
                return _product;
            }
        }

    }
}
