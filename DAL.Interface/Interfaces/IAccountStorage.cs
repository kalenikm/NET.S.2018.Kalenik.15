using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IAccountStorage
    {
        /// <summary>
        /// Reads all accounts from repository.
        /// </summary>
        /// <returns>Enumerable of accounts.</returns>
        IEnumerable<Account> Read();

        /// <summary>
        /// Loads accounts to repository.
        /// </summary>
        /// <param name="items">Accounts to load.</param>
        void Load(IEnumerable<Account> items);
    }
}