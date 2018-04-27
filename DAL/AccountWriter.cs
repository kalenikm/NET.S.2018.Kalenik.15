using System;
using System.IO;
using DAL.Interface;

namespace DAL
{
    public class AccountWriter : IDisposable
    {
        private Stream _stream;

        /// <summary>
        /// Creates new instance of AccountWriter.
        /// </summary>
        /// <param name="stream">Base stream to AccountWriter.</param>
        public AccountWriter(Stream stream)
        {
            if (ReferenceEquals(null, stream))
            {
                throw new ArgumentNullException($"{nameof(stream)} is null.");
            }

            _stream = stream;
        }

        /// <summary>
        /// Writes account to stream.
        /// </summary>
        /// <param name="account">Account to write in stream.</param>
        public void Write(Account account)
        {
            if (account == null)
                throw new ArgumentNullException($"{nameof(account)} is null.");

            var bw = new BinaryWriter(_stream);
            bw.Write(account.Id);
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