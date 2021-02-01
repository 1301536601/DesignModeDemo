using System.Threading.Tasks;

namespace StrategyPattern.IService
{
    public interface IFlyService
    {
        /// <summary>
        /// 飞接口
        /// </summary>
        /// <returns></returns>
        Task Fly();
    }
}