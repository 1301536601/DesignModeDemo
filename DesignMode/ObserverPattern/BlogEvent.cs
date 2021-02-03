namespace ObserverPattern
{
    public delegate void NotifyEventHandler(object sender);

    public class BlogEvent
    {
        public NotifyEventHandler NotifyEvent;

        /// <summary>
        /// 描写订阅号的相关信息
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// 描写此次update的信息
        /// </summary>
        public string Info { get; set; }

        public BlogEvent(string symbol, string info)
        {
            Symbol = symbol;
            Info = info;
        }

        // 对同一个订阅号，新增和删除订阅者的操作
        public void AddObserver(NotifyEventHandler ob)
        {
            NotifyEvent += ob;
        }

        public void RemoveObserver(NotifyEventHandler ob)
        {
            NotifyEvent -= ob;
        }

        public void Update()
        {
            NotifyEvent?.Invoke(this);
        }
    }
}