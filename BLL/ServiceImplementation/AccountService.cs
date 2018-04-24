using System;
using System.Collections.Generic;
using BLL.Interface;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface;
using DAL.Interface.Interfaces;
using DAL.Repositories;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private readonly List<BankAccount> _accounts = new List<BankAccount>();
        private readonly IAccountStorage _storage;

        /// <summary>
        /// Creates new instance of AccountService.
        /// </summary>
        /// <param name="storage">Repository to use with service.</param>
        public AccountService(IAccountStorage storage)
        {
            _storage = storage;
        }

        public void Save()
        {
            List<Account> resList = new List<Account>(_accounts.Count);
            foreach (var account in _accounts)
            {
                resList.Add(AccountMapper.FromBllModel(account));
            }
            _storage.Load(resList);
        }

        public void Load()
        {
            var accounts = _storage.Read();
            _accounts.Clear();
            foreach (var account in accounts)
            {
                _accounts.Add(AccountMapper.ToBllModel(account));
            }
        }

        public void CreateAccount(string fname, string lname, AccountType type, IAccountNumberCreator creator)
        {
            var account = AccountFactory.Create(fname, lname, type, creator.CreateNumber());
            _accounts.Add(account);
        }

        public void RemoveAccount(long accountNumber)
        {
            foreach (var account in _accounts)
            {
                if (account.AccountNumber.Equals(accountNumber))
                {
                    _accounts.Remove(account);
                    break;
                }
            }
            throw new ArgumentException("Account with this account number is not existing.");
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            foreach (var account in _accounts)
            {
                yield return account;
            }
        }

        public BankAccount GetAccountByAccountNumber(long number)
        {
            foreach (var account in _accounts)
            {
                if (account.AccountNumber.Equals(number))
                {
                    return account;
                }
            }
            throw new ArgumentException("Account with this account number is not existing.");
        }
    }
}