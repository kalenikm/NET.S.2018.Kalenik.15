namespace BLL.Interface
{
    public abstract class BonusCalculator
    {
        protected int coef;

        /// <summary>
        /// Calculate bonus for deposit.
        /// </summary>
        /// <param name="currency">Amount of money to deposit.</param>
        /// <returns>Count of bonus.</returns>
        public abstract int CalculateBonusForDeposit(decimal currency);

        /// <summary>
        /// Calculate bonus for withdraw.
        /// </summary>
        /// <param name="currency">Amount of money to withdraw.</param>
        /// <returns>Count of bonus.</returns>
        public abstract int CalculateBonusForWithdraw(decimal currency);
    }
}