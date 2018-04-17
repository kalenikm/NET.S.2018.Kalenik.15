using System;
using BLL.Interface;

namespace BLL.Mappers
{
    public static class AccountTypeMapper
    {
        public static AccountType ToBllModel(string type)
        {
            AccountType res;

            if(Enum.TryParse(type, out res))
            {
                return res;
            }

            throw new ArgumentException();
        }

        public static string FromBllModel(AccountType type)
        {
            return type.ToString();
        }
    }
}