using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{
    public interface IAccountStorage
    {
        IEnumerable<Account> Read();
        void Load(IEnumerable<Account> items);
    }
}