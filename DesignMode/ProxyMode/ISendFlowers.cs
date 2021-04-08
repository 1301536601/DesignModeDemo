using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyMode
{
    public interface ISendFlowers
    {
        void BuyFlowers();

        void SendFlowers();
    }

    public class Pursuing
    {
        public string Name { get; set; }

    }

    public class ProxySendFlowers : ISendFlowers
    {
        private readonly RealSendFlowers _realSendFlowers;

        public ProxySendFlowers(Pursuing ps)
        {
            _realSendFlowers = new RealSendFlowers(ps);
        }

        public void BuyFlowers()
        {
            _realSendFlowers.BuyFlowers();
        }

        public void SendFlowers()
        {
            _realSendFlowers.SendFlowers();
        }
    }

    public class RealSendFlowers : ISendFlowers
    {
        private Pursuing ps;

        public RealSendFlowers(Pursuing ps)
        {
            this.ps = ps;
        }
        public void BuyFlowers()
        {
            Console.WriteLine($@"{ps.Name} 我帮你买花了");
        }

        public void SendFlowers()
        {
            Console.WriteLine($@"{ps.Name} 买花特意送你了");
        }
    }
}
