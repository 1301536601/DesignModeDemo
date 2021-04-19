using System;
using System.Reflection;

namespace AbstractFactoryModel
{
    /// <summary>
    /// 抽象工厂模式：简单工厂也可以实现，但是如果使用的地方太多，使用反射能够减少修改的次数
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var c = DBFactory.GetDBConnect("MySql");
            c.GetDBContent();
            Console.WriteLine("Hello World!");
        }

        public static class DBFactory
        {

            public static IDBContent GetDBConnect(string dbName)
            {
                //抽象工厂：
                //IDBContent result;
                // result=  Assembly.Load(需要反射的字段信息(从配置中读取))
                // return result=  Assembly.Load(需要反射的字段信息);
                IDBContent result;
                switch (dbName)
                {
                    case "Mysql":
                        result = new MySqlContent();
                        break;
                    case "SqlServer":
                        result = new SqlServerContent();
                        break;
                    default:
                        throw new Exception("请求参数错误");
                }
                return result;
            }
        }

        public interface IDBContent
        {
            void GetDBContent();
        }

        public class MySqlContent : IDBContent
        {
            public void GetDBContent()
            {
                Console.WriteLine("当前是Mysql连接");
            }
        }

        public class SqlServerContent : IDBContent
        {
            public void GetDBContent()
            {
                Console.WriteLine("当前是SqlServerContent");
            }
        }
    }
}