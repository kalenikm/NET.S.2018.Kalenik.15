using BLL.Interface;

namespace BLL.BonusCalculators
{
    public class BaseBonusCalculator : BonusCalculator
    {
        private static BaseBonusCalculator _calculator;

        private BaseBonusCalculator()
        {
            base.coef = 5;
        }

        public static BaseBonusCalculator GetInstance => _calculator ?? (_calculator = new BaseBonusCalculator());

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