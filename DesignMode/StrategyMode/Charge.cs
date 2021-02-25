namespace StrategyMode
{
    /// <summary>
    /// 收费父类
    /// </summary>
    public abstract class Charge
    {
        public abstract decimal GetResult(decimal money);
    }
}