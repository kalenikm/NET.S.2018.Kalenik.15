using BLL.Interface;

namespace BLL.BonusCalculators
{
    public class GoldBonusCalculator : BonusCalculator
    {
        private static GoldBonusCalculator _calculator;

        private GoldBonusCalculator()
        {
            base.coef = 7;
        }

        public static GoldBonusCalculator GetInstance => _calculator ?? (_calculator = new GoldBonusCalculator());

        public override int CalculateBonusForDeposit(decimal currency)
        {
            return (int)(currency / 100) * coef;
        }

        public override int CalculateBonusForWithdraw(decimal currency)
        {
            return (int)(currency / 150) * coef;
        }
    }
}