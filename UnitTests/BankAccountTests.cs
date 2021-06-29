using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System.Linq;
using System;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestClass]
        public class DebitTests
        {
            [TestMethod]
            public void Debit_WithValidAmount_UpdatesBalance()
            {
                double beginningBalance = 11.99;
                double debitAmount = 4.55;
                double expected = 7.44;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                account.Debit(debitAmount);

                double actual = account.Balance;
                Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            }

            [TestMethod]
            public void Debit_WhenAmountIsLessthanZero_ShouldThrowArgumentOutOfRange()
            {
                double beginningBalance = 11.99;
                double debitAmount = -100.00;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                try
                {
                    account.Debit(debitAmount);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                    return;
                }

                Assert.Fail("The expected exception was not thrown.");
            }

            [TestMethod]
            public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
            {
                double beginningBalance = 11.99;
                double debitAmount = 12.00;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                try
                {
                    account.Debit(debitAmount);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                    return;
                }

                Assert.Fail("The expected exception was not thrown.");
            }
        }

        [TestClass]
        public class CreditTests
        {

            [TestMethod]
            public void Credit_WithValidAmount_UpdatesBalance()
            {
                double beginningBalance = 11.99;
                double creditAmount = 4.55;
                double expected = 16.54;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                account.Credit(creditAmount);

                double actual = account.Balance;
                Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
            }

            [TestMethod]
            public void Credit_WhenAmountIsLessThanZero_ShouldthrowArgumentOutOfRange()
            {
                double beginningBalance = 11.99;
                double creditAmount = -5.00;
                BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

                try
                {
                    account.Credit(creditAmount);
                }
                catch (System.ArgumentOutOfRangeException e)
                {
                    StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                    return;
                }

                Assert.Fail("The expected exception was not thrown.");
            }
        }
    }
}
