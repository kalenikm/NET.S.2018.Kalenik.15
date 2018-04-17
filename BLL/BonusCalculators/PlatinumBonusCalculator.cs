using BLL.Interface;

namespace BLL.BonusCalculators
{
    public class PlatinumBonusCalculator : BonusCalculator
    {
        private static PlatinumBonusCalculator _calculator;

        private PlatinumBonusCalculator()
        {
            base.coef = 10;
        }

        public static PlatinumBonusCalculator GetInstance => _calculator ?? (_calculator = new PlatinumBonusCalculator());

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