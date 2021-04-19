using System;

namespace StatusMode
{
    /// <summary>
    /// 状态模式
    /// 将指定的状态行为局部化，将不同的状态进行分割
    /// 将特定的状态相关的行为都放入一个对象中，所有状态和状态相关的代码都存在一个State中，通过这个State来选择不同的事件来进行区分
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var work = new Work();
            work.Hour = 9;
            work.WriteProgram();
            work.Hour = 10;
            work.WriteProgram();
            work.Hour = 11;
            work.WriteProgram();
            work.Hour = 12;
            work.WriteProgram();
            work.Hour = 13;
            work.WriteProgram();
            work.Hour = 14;
            work.WriteProgram();
            work.Hour = 15;
            work.WriteProgram();
            work.Hour = 17;
            work.WriteProgram();
            work.TaskFinished = true;
            work.Hour = 21;
            work.WriteProgram();
            Console.ReadKey();
        }

        public class Work
        {
            private State _current;
            public Work()
            {
                _current = new ForenoonState();

            }

            public double Hour { get; set; }

            public bool TaskFinished { get; set; }

            public void SetState(State s)
            {
                _current = s;
            }

            public void WriteProgram()
            {
                _current.WriteProgram(this);
            }
        }

        public abstract class State
        {
            public abstract void WriteProgram(Work w);
        }

        public class ForenoonState : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.Hour <= 12)
                {
                    Console.WriteLine($@"当前时间为{w.Hour},开始工作");
                }
                else
                {
                    w.SetState(new AfternoonState());
                    w.WriteProgram();
                }
            }
        }

        public class AfternoonState : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.Hour <= 17)
                {
                    Console.WriteLine($@"当前时间为{w.Hour},怎么还不下班");
                }
                else
                {
                    w.SetState(new EveningState());
                    w.WriteProgram();
                }
            }
        }

        public class EveningState : State
        {
            public override void WriteProgram(Work w)
            {
                if (w.TaskFinished)
                {
                    w.SetState(new SleepState());
                    w.WriteProgram();
                }
                else
                {
                    if (w.Hour <= 21)
                    {
                        Console.WriteLine($@"当前时间:{w.Hour},又是加班的一天");
                    }
                    else
                    {
                        w.SetState(new SleepState());
                        w.WriteProgram();
                    }
                }
            }
        }

        public class SleepState : State
        {
            public override void WriteProgram(Work w)
            {
                Console.WriteLine($@"当前时间为{w.Hour},开始睡觉");
            }
        }
    }
}
