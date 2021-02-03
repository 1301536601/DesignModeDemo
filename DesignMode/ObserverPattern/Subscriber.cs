using System;

namespace ObserverPattern
{
    public class Subscriber : IObserver
    {
        public string Name { get; set; }
        public Subscriber(string name)
        {
            this.Name = name;
        }

        public void Receive(Blog blog)
        {
            Console.WriteLine("订阅者 {0} 观察到了{1}{2}", Name, blog.Symbol, blog.Info);
        }
    }
}