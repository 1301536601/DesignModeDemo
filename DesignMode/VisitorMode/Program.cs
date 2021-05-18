using System;
using System.Collections.Generic;

namespace VisitorMode
{
    /// <summary>
    /// 访问者模式
    /// 表示一个作用于某对象杰克狗中的各元素的操作，在不改变个元素的前提下作用于这些元素的新操作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var o = new ObjectStructure();
            o.Add(new ConcreteElementA());
            o.Add(new ConcreteElementB());
            o.Add(new ConcreteElementB());
            o.Delete(new ConcreteElementB());
            var v1 = new ConcreteVisitor1();
            var v2 = new ConcreteVisitor2();
            o.Accept(v1);
            o.Accept(v2);
            Console.ReadKey();
        }

        public class ObjectStructure
        {
            private List<Element> _elements = new List<Element>();

            public void Add(Element element)
            {
                _elements.Add(element);
            }

            public void Delete(Element element)
            {
                _elements.Remove(element);
            }

            public void Accept(Visitor visitor)
            {
                foreach (var item in _elements)
                {
                    item.Accept(visitor);
                }
            }
        }

        public abstract class Visitor
        {
            public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);

            public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
        }

        public class ConcreteVisitor1 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine($@"{concreteElementA.GetType().Name}被{this.GetType().Name}访问");
            }

            public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine($@"{concreteElementB.GetType().Name}被{this.GetType().Name}访问");
            }
        }

        public class ConcreteVisitor2 : Visitor
        {
            public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
            {
                Console.WriteLine($@"{concreteElementA.GetType().Name}被{this.GetType().Name}访问");
            }

            public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
            {
                Console.WriteLine($@"{concreteElementB.GetType().Name}被{this.GetType().Name}访问");
            }
        }

        public abstract class Element
        {
            public abstract void Accept(Visitor visitor);
        }

        public class ConcreteElementA : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementA(this);
            }
        }


        public class ConcreteElementB : Element
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitConcreteElementB(this);
            }
        }
    }
}
