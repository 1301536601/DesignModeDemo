using System;

namespace PrototypeMode
{

    /// <summary>
    /// 原型模式
    /// 深复制：复制引用/值类型
    /// 浅复制：复制值类型
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student { Name = "张三", Age = 20 };

            var studentB = student.Clone() as Student;
            studentB.Name = "李四";
            var studentC = student.Clone() as Student;
            studentC.Name = "王五";

            Console.WriteLine($@"{student.Name}*****{student.Age}");
            Console.WriteLine($@"{studentB?.Name}*****{studentB?.Age}");
            Console.WriteLine($@"{studentC?.Name}*****{studentC?.Age}");

            Console.WriteLine("***********************************");

            var newStudent = new NewStudent("张三");
            newStudent.SetStudent("张三", 15);
            newStudent.SetInterest("打篮球");
            var newStudentB = (NewStudent)newStudent.Clone();
            newStudentB.SetInterest("打乒乓球");
            newStudent.DisPlay();
            newStudentB.DisPlay();
            Console.ReadKey();
        }
    }

    public class Student : ICloneable
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    public class NewStudent : ICloneable
    {
        private string name { get; set; }
        private int age { get; set; }
        private Interest interest;
        public NewStudent(string name)
        {
            name = name;
            interest = new Interest();
        }

        public NewStudent(Interest interest)
        {
            //需要带上this 
            this.interest = (Interest)interest.Clone();
        }

        public void SetStudent(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void DisPlay()
        {
            Console.WriteLine($@"{name}*****{age}");
            Console.WriteLine($@"兴趣爱好是：{interest.InterestName }");
        }

        public void SetInterest(string name)
        {
            interest.InterestName = name;
        }


        public object Clone()
        {
            var student = new NewStudent(this.interest);
            student.name = this.name;
            student.age = this.age;
            return student;
        }
    }

    public class Interest : ICloneable
    {
        public string WorkDate { get; set; }

        public string InterestName { get; set; }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
