using System.Collections.Generic;
using BLL.ServiceImplementation;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        void CreateAccount(string fname, string lname, AccountType type, IAccountNumberCreator creator);
        void RemoveAccount(long accountNumber);
        IEnumerable<BankAccount> GetAllAccounts();
        void Save();
        void Load();
        BankAccount GetAccountByAccountNumber(long number);
    }
}