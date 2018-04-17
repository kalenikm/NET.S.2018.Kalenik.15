using System;
using System.IO;
using DAL.Interface;

namespace DAL
{
    public class AccountWriter : IDisposable
    {
        private Stream _stream;

        public AccountWriter(Stream stream)
        {
            if (ReferenceEquals(null, stream))
            {
                throw new ArgumentNullException();
            }

            _stream = stream;
        }

        public void Write(Account account)
        {
            if (account == null)
                throw new ArgumentNullException();

            var bw = new BinaryWriter(_stream);
            bw.Write(account.AccountNumber);
            bw.Write(account.Firstname);
            bw.Write(account.Lastname);
            bw.Write(account.Money);
            bw.Write(account.Bonus);
            bw.Write(account.Type);
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}