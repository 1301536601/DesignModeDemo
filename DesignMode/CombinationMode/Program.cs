using System;
using System.Collections.Generic;

namespace CombinationMode
{
    class Program
    {
        static void Main(string[] args)
        {
            var concreteCompany = new ConcreteCompany("总公司");
            concreteCompany.Add(new HrCompany("总公司Hr"));
            concreteCompany.Add(new FinanceCompany("总公司财务"));

            var bjConcreteCompany = new ConcreteCompany("分公司1");
            bjConcreteCompany.Add(new HrCompany("分公司1Hr"));
            bjConcreteCompany.Add(new FinanceCompany("分公司1财务"));
            concreteCompany.Add(bjConcreteCompany);
            var shConcreteCompany = new ConcreteCompany("分公司2");
            shConcreteCompany.Add(new HrCompany("分公司2Hr"));
            shConcreteCompany.Add(new FinanceCompany("分公司2财务"));
            concreteCompany.Add(shConcreteCompany);

            concreteCompany.Display(1);
            concreteCompany.LineOfDuty();
        }

        public abstract class Company
        {
            protected readonly string _name;
            public Company(string name)
            {
                _name = name;
            }

            public abstract void Add(Company c);
            public abstract void Remove(Company c);
            public abstract void Display(int depth);
            public abstract void LineOfDuty();
        }

        public class ConcreteCompany : Company
        {
            private List<Company> _companies = new List<Company>();

            public ConcreteCompany(string name) : base(name)
            {
            }

            public override void Add(Company c)
            {
                _companies.Add(c);
            }

            public override void Remove(Company c)
            {
                _companies.Remove(c);
            }

            public override void Display(int depth)
            {
                foreach (var company in _companies)
                {
                    company.Display(depth + 2);
                }
            }

            public override void LineOfDuty()
            {
                foreach (var company in _companies)
                {
                    company.LineOfDuty();
                }
            }
        }

        public class HrCompany : Company
        {
            public HrCompany(string name) : base(name)
            {
            }

            public override void Add(Company c)
            {

            }

            public override void Remove(Company c)
            {

            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth));
            }

            public override void LineOfDuty()
            {
                Console.WriteLine($@"{_name}招聘员工");
            }
        }

        public class FinanceCompany : Company
        {
            public FinanceCompany(string name) : base(name)
            {
            }

            public override void Add(Company c)
            {

            }

            public override void Remove(Company c)
            {

            }

            public override void Display(int depth)
            {
                Console.WriteLine(new String('-', depth));
            }

            public override void LineOfDuty()
            {
                Console.WriteLine($@"{_name}统计财务");
            }
        }
    }
}
