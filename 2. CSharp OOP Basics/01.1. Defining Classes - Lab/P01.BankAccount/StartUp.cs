﻿using System;

public class StartUp
{
    public static void Main()
    {
        var account = new BankAccount();

        account.Id = 1;
        account.Balance = 15;

        Console.WriteLine($"Account {account.Id}, balance {account.Balance}");
    }
}