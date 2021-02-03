using System;

namespace ObserverPattern
{
    /// <summary>
    /// 观察者设计模式
    /// 优点：
    ///     观察者模式支持广播通信。被观察者会向所有的注册过的观察者发出通知。
    ///     观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，
    /// 每个具体观察者都符合一个抽象观察者的接口。
    /// 缺点：
    ///     如果一个被观察者对象有很多的直接和间接的观察者的话，将所有的观察者都通知到会花费很多时间。
    ///     虽然观察者模式可以随时使观察者知道所观察的对象发送了变化，但是观察者模式没有相应的机制使观察者知道所观察的对象是怎样发生变化的。
    ///     如果在被观察者之间有循环依赖的话，被观察者会触发它们之间进行循环调用，导致系统崩溃，在使用观察者模式应特别注意这点。
    /// 场景使用：
    ///   类似MQ或者Redis实现的发布订阅模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            #region 正常实现
            {
                var blog = new Blog("橙橙", "发布了一篇新博客");
                var aSubscriber = new Subscriber("甜甜");
                var bSubscriber = new Subscriber("笑笑");
                var cSubscriber = new Subscriber("兮兮");
                var dSubscriber = new Subscriber("暖暖");

                // 添加订阅者
                blog.AddObserver(aSubscriber);
                blog.AddObserver(bSubscriber);
                blog.AddObserver(cSubscriber);
                blog.AddObserver(dSubscriber);

                blog.RemoveObserver(dSubscriber);

                //更新信息
                blog.Update();
            }
            #endregion

            #region 委托实现
            {


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                var blogEvent = new BlogEvent("橙橙", "发布了一篇新博客");
                var aSubscriber = new SubscriberEvent("甜甜");
                var bSubscriber = new SubscriberEvent("笑笑");
                var cSubscriber = new SubscriberEvent("兮兮");
                var dSubscriber = new SubscriberEvent("暖暖");

                // 添加订阅者
                blogEvent.AddObserver(aSubscriber.Receive);
                blogEvent.AddObserver(bSubscriber.Receive);
                blogEvent.AddObserver(cSubscriber.Receive);
                blogEvent.AddObserver(dSubscriber.Receive);

                blogEvent.Update();


                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("移除甜甜");
                blogEvent.RemoveObserver(new NotifyEventHandler(aSubscriber.Receive));
                blogEvent.Update();

                Console.ReadLine();
            }

            #endregion
            Console.ReadLine();


        }
    }
}
