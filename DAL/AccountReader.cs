using System;
using System.Data.Common;
using System.IO;
using DAL.Interface;

namespace DAL
{
    public class AccountReader : IDisposable
    {
        private readonly Stream _stream;

        public AccountReader(Stream stream)
        {
            if (ReferenceEquals(null, stream))
            {
                throw new ArgumentException();
            }

            _stream = stream;
        }

        public Account Read()
        {
            Account account = null;
            var br = new BinaryReader(_stream);

            if (br.PeekChar() != -1)
                account = new Account(br.ReadInt64(), br.ReadString(), br.ReadString(), br.ReadDecimal(),
                    br.ReadInt32(), br.ReadString());

            return account;
        }

        public bool IsEnd()
        {
            return !(_stream.Length > _stream.Position);
        }

        public void Dispose()
        {
            _stream.Close();
        }
    }
}