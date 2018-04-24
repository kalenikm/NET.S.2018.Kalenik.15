namespace BLL.Interface.Interfaces
{
    public interface IAccountNumberCreator
    {
        /// <summary>
        /// Creates new number of account.
        /// </summary>
        /// <returns>Number of account.</returns>
        long CreateNumber();
    }
}