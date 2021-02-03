using System;

namespace ObserverPattern
{
    public class SubscriberEvent
    {
        public string Name { get; set; }
        public SubscriberEvent(string name)
        {
            this.Name = name;
        }

        public void Receive(object obj)
        {
            if (obj is BlogEvent xmfdsh)
            {
                Console.WriteLine("订阅者 {0} 观察到了{1}{2}", Name, xmfdsh.Symbol, xmfdsh.Info);
            }
        }
    }
}