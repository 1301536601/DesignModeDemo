namespace StrategyMode
{
    public class Context
    {
        Charge _charge = null;

        public Context(string type, decimal discount = 0, decimal rebateMoney = 0, decimal moneyCondition = 0)
        {
            switch (type)
            {
                case "现金收费":
                    _charge = new MoneyCharge();
                    break;
                case "打折":
                    _charge = new DiscountCharge(discount);
                    break;
                case "折扣":
                    _charge = new RebateCharge(rebateMoney, moneyCondition);
                    break;
            }
        }

        public decimal GetResult(decimal money)
        {
            return _charge.GetResult(money);
        }
    }
}