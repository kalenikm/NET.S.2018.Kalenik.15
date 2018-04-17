namespace DAL.Interface
{
    public class Account
    {
        public long AccountNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Money { get; set; }
        public int Bonus { get; set; }
        public string Type { get; set; }

        public Account(long number, string firstname, string lastname, decimal money, int bonus, string type)
        {
            AccountNumber = number;
            Firstname = firstname;
            Lastname = lastname;
            Money = money;
            Bonus = bonus;
            Type = type;
        }
    }
}