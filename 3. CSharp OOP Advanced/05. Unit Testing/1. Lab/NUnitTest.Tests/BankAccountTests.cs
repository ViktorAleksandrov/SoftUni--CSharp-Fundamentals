using NUnit.Framework;

namespace NUnitTest.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void AccountInitializeWithPositiveValue()
        {
            var account = new BankAccount(2000m);

            Assert.That(account.Amount, Is.EqualTo(2000m));
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            var account = new BankAccount();

            account.Deposit(50);

            Assert.That(account.Amount, Is.EqualTo(50));
        }
    }
}
