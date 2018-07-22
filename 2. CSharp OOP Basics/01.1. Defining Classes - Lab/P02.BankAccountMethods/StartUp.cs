using System;

public class StartUp
{
    public static void Main()
    {
        var account = new BankAccount();

        account.Id = 15;
        account.Deposit(15);
        account.Withdraw(10);

        Console.WriteLine(account);
    }
}