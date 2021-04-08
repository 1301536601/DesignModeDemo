using System;

namespace FactoryMode
{
    /// <summary>
    /// 工厂模式
    /// 和简单工厂的区别：
    /// 简单工厂，在类的内部进行修改
    /// 工厂模式：在类的内部进行修改
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new StudentFactory();
            var leiFeng = factory.GetFactory();
            leiFeng.BuyRice();
            Console.ReadKey();
        }
    }

    public interface IFactory
    {
        LeiFeng GetFactory();
    }

    public class StudentFactory : IFactory
    {
        public LeiFeng GetFactory()
        {
            return new StudentLeiFeng();
        }
    }


    public class VolunteerFactory : IFactory
    {
        public LeiFeng GetFactory()
        {
            return new VolunteerLeiFeng();
        }
    }



    public interface LeiFeng
    {

        /// <summary>
        /// 买米
        /// </summary>
        void BuyRice();

        /// <summary>
        /// 洗衣服
        /// </summary>
        void WashCloths();

        /// <summary>
        /// 清理
        /// </summary>
        void CleanUp();
    }

    public class StudentLeiFeng : LeiFeng
    {
        public void BuyRice()
        {
            Console.WriteLine("学生正在买米");
        }

        public void WashCloths()
        {
            Console.WriteLine("学生正在买米");
        }

        public void CleanUp()
        {
            Console.WriteLine("学生正在清理");
        }
    }

    public class VolunteerLeiFeng : LeiFeng
    {
        public void BuyRice()
        {
            Console.WriteLine("学生正在买米");
        }

        public void WashCloths()
        {
            Console.WriteLine("学生正在买米");
        }

        public void CleanUp()
        {
            Console.WriteLine("学生正在清理");
        }
    }

}
