namespace StrategyMode
{
    /// <summary>
    /// 打折收费
    /// </summary>
    public class DiscountCharge : Charge
    {
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal Discount { get; set; }

        public DiscountCharge(decimal discount)
        {
            Discount = discount;
        }

        public override decimal GetResult(decimal money)
        {
            return money * Discount;
        }
    }
}