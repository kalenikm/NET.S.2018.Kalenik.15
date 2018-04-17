﻿using System;
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
                throw new ArgumentNullException();
            }

            AccountType type = AccountTypeMapper.ToBllModel(account.Type);

            return AccountFactory.Create(account.Firstname, account.Lastname, type, account.AccountNumber);
        }

        public static Account FromBllModel(BankAccount account)
        {
            if (ReferenceEquals(null, account))
            {
                throw new ArgumentNullException();
            }

            return new Account(account.AccountNumber, account.FirstName, account.LastName, account.Balance, account.Bonus, account.Type.ToString());
        }
    }
}