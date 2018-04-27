using System;
using BLL.Interface;
using BLL.ServiceImplementation;
using DAL.Interface;

namespace BLL.Mappers
{
    public static class AccountMapper
    {
        public static BankAccount ToBllModel(Account account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException($"{nameof(account)} is null.");
            }

            AccountType type = AccountTypeMapper.ToBllModel(account.Type);

            return AccountFactory.Create(account.Firstname, account.Lastname, type, account.Id);
        }

        public static Account FromBllModel(BankAccount account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException($"{nameof(account)} is null.");
            }

            return new Account(account.AccountNumber, account.FirstName, account.LastName, account.Balance, account.Bonus, account.Type.ToString());
        }
    }
}