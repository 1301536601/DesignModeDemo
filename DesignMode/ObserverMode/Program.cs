using System;
using System.Threading.Tasks;

using static ObserverMode.Program;

namespace ObserverMode
{

    /// <summary>
    /// 观察者模式(发布订阅模式)
    /// 定义一种一对多的关系，多个观察者监视一个状态的改变，在当前状态改变的前提下，改变自己的状态
    /// 
    /// </summary>
    class Program
    {
        public delegate void EventDoHandler();


        static void Main(string[] args)
        {
            BossNotify eBossNotify = new BossNotify();

            Stock tongshi1 = new Stock("张三", eBossNotify);
            NBA tongshi2 = new NBA("李四", eBossNotify);

            eBossNotify.Update += tongshi1.DoSomeThing;
            eBossNotify.Update += tongshi2.DoSomeThing;

            eBossNotify.SubjectStatus = "你们在干嘛";
            eBossNotify.Notify();
            Console.Read();
        }

        public interface IDoSomeThing
        {
            void DoSomeThing();
        }

        public interface ISubject
        {
            void Notify();

            string SubjectStatus { get; set; }
        }

        public class Stock : IDoSomeThing
        {
            private string _name;
            private ISubject _subject;

            public Stock(string name, ISubject subject)
            {
                _name = name;
                _subject = subject;
            }
            public void DoSomeThing()
            {
                Console.WriteLine($@"{_subject.SubjectStatus}--{_name}停止做某件事");
            }
        }

        public class NBA : IDoSomeThing
        {
            private string _name;
            private ISubject _subject;

            public NBA(string name, ISubject subject)
            {
                _name = name;
                _subject = subject;
            }
            public void DoSomeThing()
            {
                Console.WriteLine($@"{_subject.SubjectStatus}--{_name}停止做某件事");
            }
        }

        public class BossNotify : ISubject
        {
            public event EventDoHandler Update;

            private string _action;

            public void Notify()
            {
                Update?.Invoke();
            }

            public string SubjectStatus
            {
                get => _action;
                set => _action = value;
            }
        }


        public class FrontDeskNotify : ISubject
        {

            public event EventDoHandler Update;

            private string _action;

            public void Notify()
            {
                Update?.Invoke();
            }

            public string SubjectStatus
            {
                get => _action;
                set => _action = value;
            }
        }

    }
}
