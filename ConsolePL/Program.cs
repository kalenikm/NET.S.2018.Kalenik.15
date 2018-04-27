using System;
using BLL.Interface;
using BLL.Interface.Interfaces;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IAccountService service = resolver.Get<IAccountService>();
            IAccountNumberCreator creator = resolver.Get<IAccountNumberCreator>();
            service.CreateAccount("1", "1", AccountType.Base, creator);
            service.CreateAccount("2", "2", AccountType.Gold, creator);
            service.CreateAccount("3", "3", AccountType.Base, creator);
            service.CreateAccount("4", "4", AccountType.Platinum, creator);
            service.Save();

            IAccountService service2 = resolver.Get<IAccountService>();
            service2.Load();
            BankAccount account = service2.GetAccountByAccountNumber(2);
            account.Deposit(100);
            Console.WriteLine(account.ToString());
        }
    }
}
