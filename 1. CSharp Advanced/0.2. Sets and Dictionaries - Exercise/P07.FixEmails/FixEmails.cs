namespace P07.FixEmails
{
    using System;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main()
        {
            var namesEmails = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if (email.ToLower().EndsWith("uk") || email.ToLower().EndsWith("us"))
                {
                    continue;
                }

                namesEmails[name] = email;
            }

            foreach (var pair in namesEmails)
            {
                var name = pair.Key;
                var email = pair.Value;

                Console.WriteLine($"{name} -> {email}");
            }
        }
    }
}