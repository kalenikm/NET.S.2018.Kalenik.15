using System.Collections.Generic;
using DAL.Interface;
using DAL.Interface.Interfaces;

namespace DAL.EF
{
    public class Repository : IAccountStorage
    {
        private Context _db;

        public Repository()
        {
            _db = new Context();
        }

        public IEnumerable<Account> Read()
        {
            foreach (var dbAccount in _db.Accounts)
            {
                yield return dbAccount;
            }
        }

        public void Load(IEnumerable<Account> items)
        {
            _db.Accounts.AddRange(items);
            _db.SaveChanges();
        }
    }
}