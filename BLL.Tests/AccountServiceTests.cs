using System;
using System.Collections.Generic;
using BLL.Interface;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface;
using DAL.Interface.Interfaces;
using NUnit.Framework;
using Moq;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        [TestCase]
        public void AccountService_StorageSaveTest()
        {
            var repositoryMock = new Mock<IAccountStorage>(MockBehavior.Strict);
            repositoryMock.Setup(rep => rep.Load(new Account[0]));

            var accountService = new AccountService(repositoryMock.Object);
            accountService.Save();

            repositoryMock.Verify(rep => rep.Load(new Account[0]));
        }
        [TestCase]
        public void AccountService_StorageLoadTest()
        {
            var repositoryMock = new Mock<IAccountStorage>(MockBehavior.Strict);
            repositoryMock.Setup(rep => rep.Read()).Returns(() => new Account[0]);

            var accountService = new AccountService(repositoryMock.Object);
            accountService.Load();

            repositoryMock.Verify(rep => rep.Read());
        }

        [TestCase("1", "1", AccountType.Base)]
        [TestCase("2", "2", AccountType.Platinum)]
        public void AccountNumberCreatorTest(string firstname, string lastname, AccountType type)
        {
            var repositoryMock = new Mock<IAccountStorage>();

            var numberCreatorMock = new Mock<IAccountNumberCreator>(MockBehavior.Strict);
            numberCreatorMock.Setup(service => service.CreateNumber()).Returns(1);

            var accountService = new AccountService(repositoryMock.Object);

            accountService.CreateAccount(firstname, lastname, type, numberCreatorMock.Object);

            numberCreatorMock.Verify(service => service.CreateNumber());
        }
    }
}
