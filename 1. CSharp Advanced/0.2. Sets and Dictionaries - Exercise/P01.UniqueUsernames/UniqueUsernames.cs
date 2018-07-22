namespace P01.UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class UniqueUsernames
    {
        public static void Main()
        {
            var usernamesCount = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < usernamesCount; i++)
            {
                var currentUsername = Console.ReadLine();

                usernames.Add(currentUsername);
            }

            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}