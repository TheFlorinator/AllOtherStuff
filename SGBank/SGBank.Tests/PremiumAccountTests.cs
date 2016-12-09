using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithDrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    class PremiumAccountTests
    {
        [TestCase("44444", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType type, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = type;

            AccountDepositResponse response = deposit.Deposit(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("44444", "Premium Account", 100, AccountType.Free, -100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 100, false)]
        [TestCase("44444", "Premium Account", 150, AccountType.Premium, -50, true)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -600, true)]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType type, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRules();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = type;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
