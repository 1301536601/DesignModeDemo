namespace StrategyMode
{
    /// <summary>
    /// 现金收费
    /// </summary>
    public class MoneyCharge : Charge
    {
        public override decimal GetResult(decimal money)
        {
            return money;
        }
    }
}