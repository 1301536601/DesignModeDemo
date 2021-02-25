namespace StrategyMode
{
    public class RebateCharge : Charge
    {
        /// <summary>
        /// 返利金额
        /// </summary>
        public decimal RebateMoney { get; set; }

        /// <summary>
        /// 返利条件
        /// </summary>
        public decimal MoneyCondition { get; set; }

        public RebateCharge(decimal rebateMoney, decimal moneyCondition)
        {
            RebateMoney = rebateMoney;
            MoneyCondition = moneyCondition;
        }

        public override decimal GetResult(decimal money)
        {
            if (money >= MoneyCondition)
            {
                return money - RebateMoney;
            }
            return money;
        }
    }
}