using System;
using System.Collections.Generic;
using System.IO;
using DAL.Interface;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    public class BinaryAccountStorage : IAccountStorage
    {
        private readonly string _filename;

        /// <summary>
        /// Creates new repository based on binary file.
        /// </summary>
        /// <param name="filename">Name of file.</param>
        public BinaryAccountStorage(string filename)
        {
            _filename = filename;
        }

        public IEnumerable<Account> Read()
        {
            using (var ar = new AccountReader(new FileStream(_filename, FileMode.OpenOrCreate)))
            {
                while (!ar.IsEnd())
                {
                    Account account = ar.Read();
                    yield return account;
                }
            }
        }

        public void Load(IEnumerable<Account> items)
        {
            if (ReferenceEquals(null, items))
            {
                throw new ArgumentNullException();
            }

            using (var aw = new AccountWriter(new FileStream(_filename, FileMode.Create)))
            {
                foreach (var account in items)
                {
                    aw.Write(account);
                }
            }
        }
    }
}