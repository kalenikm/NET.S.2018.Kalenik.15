using System;
using System.Data.Common;
using System.IO;
using DAL.Interface;

namespace DAL
{
    public class AccountReader : IDisposable
    {
        private readonly Stream _stream;

        /// <summary>
        /// Creates new instance of AccountReader.
        /// </summary>
        /// <param name="stream">Base stream to AccountReader.</param>
        public AccountReader(Stream stream)
        {
            if (ReferenceEquals(null, stream))
            {
                throw new ArgumentException($"{nameof(stream)} is null.");
            }

            _stream = stream;
        }

        /// <summary>
        /// Reads account from stream.
        /// </summary>
        /// <returns>Account that was read from stream. Or null if stream is empty.</returns>
        public Account Read()
        {
            Account account = null;
            var br = new BinaryReader(_stream);

            if (br.PeekChar() != -1)
                account = new Account(br.ReadInt64(), br.ReadString(), br.ReadString(), br.ReadDecimal(),
                    br.ReadInt32(), br.ReadString());

            return account;
        }

        /// <summary>
        /// Checks end of stream.
        /// </summary>
        /// <returns>True/false.</returns>
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