using System;

namespace TemplateMode
{
    /// <summary>
    /// 模板设计模式
    /// 场景：在A/B需要同时依赖同一实现类的时候
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var student = new StudentA();
            student.QuestionOne();
            student.QuestionTwo();

            Console.WriteLine("*****************");
            var studentB = new StudentB();
            studentB.QuestionOne();
            studentB.QuestionTwo();

            Console.Read();
        }
    }

    public class QuestionPaper
    {
        public void QuestionOne()
        {
            Console.WriteLine($@"1+1={AnswerOne()} A:1 B2 C3 D4");
        }

        public void QuestionTwo()
        {
            Console.WriteLine($@"1+1={AnswerTwo()} A:1 B2 C3 D4");
        }

        public virtual string AnswerOne()
        {
            return "";
        }

        public virtual string AnswerTwo()
        {
            return "";
        }
    }

    public class StudentA : QuestionPaper
    {
        public override string AnswerOne()
        {
            return "B";
        }

        public override string AnswerTwo()
        {
            return "C";
        }
    }

    public class StudentB : QuestionPaper
    {
        public override string AnswerOne()
        {
            return "B";
        }

        public override string AnswerTwo()
        {
            return "C";
        }
    }
}
