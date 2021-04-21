using System;
using System.Collections.Generic;

namespace MemorandumMode
{

    /// <summary>
    /// 备忘录模式
    /// 相当于有一个中间状态类存储信息
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<ContactPerson>
            {
                new ContactPerson { Name= "Learning Hard", MobileNum = "123445"},
                new ContactPerson { Name = "Tony", MobileNum = "234565"},
                new ContactPerson { Name = "Jock", MobileNum = "231455"}
            };
            var mobileOwner = new MobileOwner(persons);
            mobileOwner.Show();

            // 创建备忘录并保存备忘录对象
            var caretaker = new Caretaker { ContactM = mobileOwner.CreateMemento() };

            // 更改发起人联系人列表
            Console.WriteLine("----移除最后一个联系人--------");
            mobileOwner.ContactPersons.RemoveAt(2);
            mobileOwner.Show();

            // 恢复到原始状态
            Console.WriteLine("-------恢复联系人列表------");
            mobileOwner.RestoreMemento(caretaker.ContactM);
            mobileOwner.Show();

            Console.Read();
        }

        public class ContactPerson
        {
            public string Name { get; set; }
            public string MobileNum { get; set; }
        }

        public class MobileOwner
        {
            // 发起人需要保存的内部状态
            public List<ContactPerson> ContactPersons { get; set; }

            public MobileOwner(List<ContactPerson> persons)
            {
                ContactPersons = persons;
            }

            // 创建备忘录，将当期要保存的联系人列表导入到备忘录中 
            public ContactMemento CreateMemento()
            {

                return new ContactMemento(new List<ContactPerson>(this.ContactPersons));
            }

            // 将备忘录中的数据备份导入到联系人列表中
            public void RestoreMemento(ContactMemento memento)
            {

                this.ContactPersons = memento.ContactPersonBack;
            }

            public void Show()
            {
                Console.WriteLine("联系人列表中有{0}个人，他们是:", ContactPersons.Count);
                foreach (ContactPerson p in ContactPersons)
                {
                    Console.WriteLine("姓名: {0} 号码为: {1}", p.Name, p.MobileNum);
                }
            }
        }

        public class ContactMemento
        {
            // 保存发起人的内部状态
            public List<ContactPerson> ContactPersonBack;

            public ContactMemento(List<ContactPerson> persons)
            {
                ContactPersonBack = persons;
            }
        }

        public class Caretaker
        {
            public ContactMemento ContactM { get; set; }
        }
    }
}
