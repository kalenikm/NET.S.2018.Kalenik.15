using System;
using BLL.BonusCalculators;
using BLL.Interface;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;

namespace BLL
{
    public static class AccountFactory
    {
        public static BankAccount Create(string firstname, string lastname, AccountType type, long number, decimal money = 0, int bonus = 0)
        {
            BonusCalculator bonusCalculator;
            switch (type)
            {
                case AccountType.Base:
                    bonusCalculator = BaseBonusCalculator.GetInstance;
                    break;
                case AccountType.Gold:
                    bonusCalculator = GoldBonusCalculator.GetInstance;
                    break;
                case AccountType.Platinum:
                    bonusCalculator = PlatinumBonusCalculator.GetInstance;
                    break;
                default:
                    throw new ArgumentException("Wrong type.");
            }
            return new BankAccount(number, firstname, lastname, type, bonusCalculator, money, bonus);
        }
    }
}