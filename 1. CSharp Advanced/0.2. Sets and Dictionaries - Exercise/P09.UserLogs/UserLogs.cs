namespace P09.UserLogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserLogs
    {
        public static void Main()
        {
            var usersLogs = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var inputTokens = Console.ReadLine().Split(' ', '=');

                if (inputTokens[0] == "end")
                {
                    break;
                }

                var username = inputTokens[5];

                if (usersLogs.ContainsKey(username) == false)
                {
                    usersLogs[username] = new Dictionary<string, int>();
                }

                var ip = inputTokens[1];

                if (usersLogs[username].ContainsKey(ip) == false)
                {
                    usersLogs[username][ip] = 0;
                }

                usersLogs[username][ip]++;
            }

            foreach (var pair in usersLogs)
            {
                var username = pair.Key;

                var ipsMessagesCount = pair.Value
                    .Select(kvp => $"{kvp.Key} => {kvp.Value}");

                Console.WriteLine(username + ":");

                Console.WriteLine(string.Join(", ", ipsMessagesCount) + ".");
            }
        }
    }
}