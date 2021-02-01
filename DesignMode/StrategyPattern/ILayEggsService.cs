using System.Threading.Tasks;

namespace StrategyPattern
{

    /// <summary>
    /// 下蛋接口
    /// </summary>
    public interface ILayEggsService
    {
        /// <summary>
        /// 下蛋接口
        /// </summary>
        /// <returns></returns>
        Task LayEggs();
    }
}