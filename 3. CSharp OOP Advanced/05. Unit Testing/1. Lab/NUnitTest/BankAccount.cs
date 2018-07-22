namespace NUnitTest
{
    public class BankAccount
    {
        public BankAccount()
        {
            this.Amount = 0;
        }

        public BankAccount(decimal amount)
        {
            this.Amount = amount;
        }

        public decimal Amount { get; private set; }

        public void Deposit(decimal amount)
        {
            this.Amount += amount;
        }
    }
}
