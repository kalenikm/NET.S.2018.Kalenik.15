namespace BLL.Interface
{
    public abstract class BonusCalculator
    {
        protected int coef;

        public abstract int CalculateBonusForDeposit(decimal currency);

        public abstract int CalculateBonusForWithdraw(decimal currency);
    }
}