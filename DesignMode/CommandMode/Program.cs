using System;
using System.Collections.Generic;

namespace CommandMode
{
    /// <summary>
    /// 命令模式
    /// 容易设计一个命令队列
    /// 在需要的情况下很容易将命令记入日志
    /// 允许接受请求的一方决定是否要拒绝请求
    /// 请求的撤销和重做
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new Read();
            var doSomeThing = new DoSomeThing();
            var commandRead = new ConcreteCommand(receiver);
            var commandDoSomeThing = new ConcreteCommand(doSomeThing);
            var invoker = new Invoker();
            invoker.SetCommand(commandRead);
            invoker.SetCommand(commandDoSomeThing);
            invoker.RemoveCommand(commandRead);
            invoker.Execute();
            Console.ReadKey();
        }

        /// <summary>
        /// 声明执行操作的接口
        /// </summary>
        public abstract class Command
        {
            protected ReceiverBase Receiver;

            public Command(ReceiverBase receiver)
            {
                Receiver = receiver;
            }

            public abstract void Notify();
        }

        public class ConcreteCommand : Command
        {
            public ConcreteCommand(ReceiverBase receiver) : base(receiver)
            {
            }

            public override void Notify()
            {
                Receiver.Action();
            }
        }

        /// <summary>
        /// 执行类
        /// </summary>
        public class Invoker
        {
            private List<Command> _commands = new List<Command>();

            public void SetCommand(Command command)
            {
                _commands.Add(command);
            }

            public void RemoveCommand(Command command)
            {
                _commands.Remove(command);
            }

            public void Execute()
            {
                if (_commands != null)
                {
                    foreach (var item in _commands)
                    {
                        item.Notify();
                    }
                }
            }
        }

        public abstract class ReceiverBase
        {
            public abstract void Action();

        }

        public class Read : ReceiverBase
        {
            public override void Action()
            {
                Console.WriteLine("阅读");
            }
        }

        public class DoSomeThing : ReceiverBase
        {
            public override void Action()
            {
                Console.WriteLine("做某件事请");
            }
        }
    }
}
