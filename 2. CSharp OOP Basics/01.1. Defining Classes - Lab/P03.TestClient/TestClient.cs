using System;
using System.Collections.Generic;

namespace P03.TestClient
{
    public class TestClient
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            while (true)
            {
                var commandArgs = Console.ReadLine().Split();

                var command = commandArgs[0];

                if (command == "End")
                {
                    break;
                }

                var id = int.Parse(commandArgs[1]);

                switch (command)
                {
                    case "Create":
                        Create(id, accounts);
                        break;
                    case "Deposit":
                        Deposit(commandArgs, accounts, id);
                        break;
                    case "Withdraw":
                        Withdraw(commandArgs, accounts, id);
                        break;
                    case "Print":
                        Print(id, accounts);
                        break;
                }
            }
        }

        private static void Create(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                accounts[id] = new BankAccount { Id = id };
            }
        }

        private static void Deposit(string[] commandArgs, Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                var amount = decimal.Parse(commandArgs[2]);

                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdraw(string[] commandArgs, Dictionary<int, BankAccount> accounts, int id)
        {
            if (accounts.ContainsKey(id))
            {
                var amount = decimal.Parse(commandArgs[2]);

                accounts[id].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Print(int id, Dictionary<int, BankAccount> accounts)
        {
            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id]);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
    }
}