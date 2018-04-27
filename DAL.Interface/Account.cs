namespace DAL.Interface
{
    public class Account
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public decimal Money { get; set; }
        public int Bonus { get; set; }
        public string Type { get; set; }

        /// <summary>
        /// Creates new instance of account.
        /// </summary>
        /// <param name="number">Number of account.</param>
        /// <param name="firstname">First name of owner.</param>
        /// <param name="lastname">Last name of owner.</param>
        /// <param name="money">Balance of account.</param>
        /// <param name="bonus">Count of bonus of account.</param>
        /// <param name="type">Type of account.</param>
        public Account(long number, string firstname, string lastname, decimal money, int bonus, string type)
        {
            Id = number;
            Firstname = firstname;
            Lastname = lastname;
            Money = money;
            Bonus = bonus;
            Type = type;
        }

        public Account() { }
    }
}