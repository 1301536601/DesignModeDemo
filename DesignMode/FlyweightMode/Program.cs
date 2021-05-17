using System;
using System.Collections;

namespace FlyweightMode
{
    /// <summary>
    /// 享元模式
    /// 使用场景：如果一个应用程序使用了大量的对象，对象造成了大量的内存开销就应该考虑使用享元模式
    ///           对象的大多数可以外部状态，如果删除对象的外部状态，可以用较少的共享对象取代多组对象
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var webSiteFactory = new WebSiteFactory();
            var c = webSiteFactory.GetWebSite("c");
            c.Use(new User("你好c"));

            var d = webSiteFactory.GetWebSite("d");
            d.Use(new User("你好d"));

            var e = webSiteFactory.GetWebSite("e");
            e.Use(new User("你好e"));

            var f = webSiteFactory.GetWebSite("f");
            f.Use(new User("你好f"));

            var g = webSiteFactory.GetWebSite("g");
            g.Use(new User("你好g"));

            var a = webSiteFactory.GetWebSite("c");
            a.Use(new User("你好c"));

            var count = webSiteFactory.GetCount();
            Console.WriteLine($@"总条数为:{count}");
            Console.ReadKey();
        }

        public class User
        {
            private string _name;

            public User(string name)
            {
                _name = name;
            }
            public string Name => _name;
        }

        public abstract class WebSite
        {
            public abstract void Use(User user);
        }


        public class ConcreteWebSite : WebSite
        {
            private string _name = "";

            public ConcreteWebSite(string name)
            {
                _name = name;
            }

            public override void Use(User user)
            {
                Console.WriteLine($@"网站分类:{_name},当前用户为:{user.Name}");
            }
        }

        public class WebSiteFactory
        {
            private Hashtable _table = new Hashtable();

            public WebSite GetWebSite(string key)
            {
                if (!_table.ContainsKey(key))
                {
                    _table.Add(key, new ConcreteWebSite(key));
                }
                return (WebSite)_table[key];
            }

            public int GetCount()
            {
                return _table.Count;
            }
        }

    }
}
