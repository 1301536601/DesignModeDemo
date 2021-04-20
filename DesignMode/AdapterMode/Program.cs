using System;

namespace AdapterMode
{
    /// <summary>
    /// 适配器模式
    /// 系统的数据和行为都正确，但接口不符合的时候，可以考虑使用适配器，
    /// 就是将不匹配的信息进行封装一层 然后直接掉封装的接口
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var vanguard = new Vanguard("前锋");
            vanguard.Attack();

            var center = new Center("中锋");
            center.Attack();
            center.Defend();

            Guards guards = new Guards("后卫");
            guards.Defend();

            ChineseCenter chineseCenter = new ChineseCenter("适配器");
            chineseCenter.Attack();

        }

        public abstract class Player
        {
            private readonly string _name;

            public Player(string name)
            {
                _name = name;
            }


            public abstract void Attack();

            public abstract void Defend();
        }

        public class Vanguard : Player
        {

            private readonly string _name;
            public Vanguard(string name) : base(name)
            {
                _name = name;
            }

            public override void Attack()
            {
                Console.WriteLine($@"{_name}发起进攻");
            }

            public override void Defend()
            {
                Console.WriteLine($@"{_name}开始进攻");
            }
        }

        public class Center : Player
        {

            private readonly string _name;
            public Center(string name) : base(name)
            {
                _name = name;
            }

            public override void Attack()
            {
                Console.WriteLine($@"{_name}发起进攻");
            }

            public override void Defend()
            {
                Console.WriteLine($@"{_name}开始进攻");
            }
        }

        public class Guards : Player
        {

            private readonly string _name;
            public Guards(string name) : base(name)
            {
                _name = name;
            }

            public override void Attack()
            {
                Console.WriteLine($@"{_name}发起进攻");
            }

            public override void Defend()
            {
                Console.WriteLine($@"{_name}开始进攻");
            }
        }

        public class ForeignCenter
        {
            public string Name { get; set; }

            public void Attack()
            {
                Console.WriteLine($@"{Name}发起进攻");
            }
            public void Defend()
            {
                Console.WriteLine($@"{Name}开始进攻");
            }
        }

        public class ChineseCenter : Player
        {
            private readonly ForeignCenter _foreignCenter = new ForeignCenter();

            public ChineseCenter(string name) : base(name)
            {
                _foreignCenter.Name = name;
            }

            public override void Attack()
            {
                _foreignCenter.Attack();
            }

            public override void Defend()
            {
                _foreignCenter.Defend();
            }
        }
    }
}
