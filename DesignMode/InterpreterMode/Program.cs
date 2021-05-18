using System;
using System.Collections.Generic;

namespace InterpreterMode
{

    /// <summary>
    /// 解释器模式
    /// 如果一种特定类型问题发生的频率足够高，那么就可以将这些事例表述为一个简单语言的橘子，这样就可以构建一个解释器
    /// 问题：不理解
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();
            var expressions = new List<Expression>
            {
                new TerminalExpression(),
                new TerminalExpression(),
                new TerminalExpression(),
                new NotTerminalExpression()
            };
            foreach (var item in expressions)
            {
                item.Interpreter(context);
            }

            Console.ReadKey();
        }

        public abstract class Expression
        {
            public abstract void Interpreter(Context context);
        }

        public class TerminalExpression : Expression
        {
            public override void Interpreter(Context context)
            {
                Console.WriteLine("终端解释器");
            }
        }

        public class NotTerminalExpression : Expression
        {
            public override void Interpreter(Context context)
            {
                Console.WriteLine("非终端解释器");
            }
        }

        public class Context
        {
            /// <summary>
            /// 输入
            /// </summary>
            public string Input { get; set; }

            /// <summary>
            /// 输出
            /// </summary>
            public string OutPut { get; set; }
        }


    }
}
