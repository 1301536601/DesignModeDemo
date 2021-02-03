using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class Blog
    {
        private List<IObserver> observers = new List<IObserver>();

        /// <summary>
        /// 描写订阅号的相关信息
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 描写此次update的信息
        /// </summary>
        public string Info { get; set; }

        public Blog(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }


        // 对同一个订阅号，新增和删除订阅者的操作
        public void AddObserver(IObserver ob)
        {
            observers.Add(ob);
        }

        public void RemoveObserver(IObserver ob)
        {
            observers.Remove(ob);
        }

        public void Update()
        {
            // 遍历订阅者列表进行通知
            foreach (var ob in observers)
            {
                ob?.Receive(this);
            }
        }
    }
}