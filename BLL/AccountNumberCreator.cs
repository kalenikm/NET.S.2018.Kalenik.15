using BLL.Interface.Interfaces;

namespace BLL
{
    public class AccountNumberCreator : IAccountNumberCreator
    {
        private static long _number;
        public long CreateNumber()
        {
            return ++_number;
        }
    }
}