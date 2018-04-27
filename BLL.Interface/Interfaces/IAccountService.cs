using System.Collections.Generic;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Creates new Account.
        /// </summary>
        /// <param name="fname">First name of owner of new account.</param>
        /// <param name="lname">Last name of owner of new account.</param>
        /// <param name="type">Type of new account.</param>
        /// <param name="creator">Creator to create number of new account.</param>
        void CreateAccount(string fname, string lname, AccountType type, IAccountNumberCreator creator);

        /// <summary>
        /// Removes account with number that equals <paramref name="accountNumber"/>.
        /// </summary>
        /// <param name="accountNumber">Number of account to remove.</param>
        void RemoveAccount(long accountNumber);

        /// <summary>
        /// Returns enumerable of accounts.
        /// </summary>
        /// <returns>Enumerable of all accounts.</returns>
        IEnumerable<BankAccount> GetAllAccounts();

        /// <summary>
        /// Saves all accounts to repository.
        /// </summary>
        void Save();

        /// <summary>
        /// Loads all accounts from repository.
        /// </summary>
        void Load();

        /// <summary>
        /// Finds and returns account with number that equals <paramref name="number"/>
        /// </summary>
        /// <param name="number">Number of account to find.</param>
        /// <returns>Founded account.</returns>
        BankAccount GetAccountByAccountNumber(long number);
    }
}