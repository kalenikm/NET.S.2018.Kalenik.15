using System;
using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Interfaces;

namespace DAL.EF
{
    public class Repository : IAccountStorage
    {
        private readonly Context _db;

        public Repository()
        {
            _db = new Context();
        }

        public IEnumerable<Account> Read()
        {
            if (ReferenceEquals(null, _db))
            {
                throw new ArgumentNullException($"DBcontext is null.");
            }

            foreach (var dbAccount in _db.Accounts)
            {
                yield return dbAccount;
            }
        }

        public void Load(IEnumerable<Account> items)
        {
            if (ReferenceEquals(null, items))
            {
                throw new ArgumentNullException($"{nameof(items)} is null.");
            }

            _db.Accounts.AddRange(items);
            _db.SaveChanges();
        }
    }
}