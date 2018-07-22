namespace P05.Phonebook
{
    using System;
    using System.Collections.Generic;

    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                var phonebookTokens = Console.ReadLine().Split('-');

                var name = phonebookTokens[0];

                if (name == "search")
                {
                    break;
                }

                var phoneNumber = phonebookTokens[1];

                phonebook[name] = phoneNumber;
            }

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                if (phonebook.ContainsKey(name))
                {
                    var phoneNumber = phonebook[name];

                    Console.WriteLine($"{name} -> {phoneNumber}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
        }
    }
}