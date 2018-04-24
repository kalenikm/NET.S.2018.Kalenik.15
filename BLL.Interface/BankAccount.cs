using System;
using BLL.Interface;

namespace BLL.ServiceImplementation
{
    public class BankAccount
    {
        private long _accountNumber;
        private string _firstname;
        private string _lastname;
        private decimal _money;
        private int _bonus;
        private AccountType _type;
        private readonly BonusCalculator _bonusCalculator;

        #region Properties

        public long AccountNumber => _accountNumber;

        public string FirstName
        {
            get
            {
                return _firstname;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            protected set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException();
                }

                _lastname = value;
            }
        }

        public decimal Balance => _money;
        public int Bonus => _bonus;

        public AccountType Type => _type;

        #endregion
        
        /// <summary>
        /// Creates new instance of BankAccount.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="firstname">First name of owner.</param>
        /// <param name="lastname">Last name of owner.</param>
        /// <param name="type">Type of account.</param>
        /// <param name="bonusCalculator">Bonus calculator of account.</param>
        /// <param name="money">Balance of account.</param>
        /// <param name="bonus">Count of bonus of account.</param>
        public BankAccount(long accountNumber, string firstname, string lastname, AccountType type, BonusCalculator bonusCalculator, decimal money = 0, int bonus = 0)
        {
            _accountNumber = accountNumber;
            FirstName = firstname;
            LastName = lastname;
            _type = type;
            _bonusCalculator = bonusCalculator;
            _money = money;
            _bonus = bonus;
        }

        /// <summary>
        /// Deposit money to balance.
        /// </summary>
        /// <param name="currency">Amount of money.</param>
        public void Deposit(decimal currency)
        {
            if (currency <= 0)
            {
                throw new ArgumentException();
            }

            _money += currency;
            _bonus += _bonusCalculator.CalculateBonusForDeposit(currency);
        }

        /// <summary>
        /// Withdraw money from balance.
        /// </summary>
        /// <param name="currency">Amount of money.</param>
        public void Withdraw(decimal currency)
        {
            if (currency <= 0)
            {
                throw new ArgumentException();
            }

            if (currency > _money)
            {
                throw new ArgumentException();
            }

            _money -= currency;
            _bonus -= _bonusCalculator.CalculateBonusForWithdraw(currency);
        }

        public override string ToString()
        {
            return String.Format($"{AccountNumber}. {FirstName} {LastName}, Balance: {Balance}, Bonus: {Bonus}, Type: {Type.ToString()}");
        }
    }
}