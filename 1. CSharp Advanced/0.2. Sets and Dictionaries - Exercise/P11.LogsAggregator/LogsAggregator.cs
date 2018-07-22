namespace P11.LogsAggregator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LogsAggregator
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var usersLogs = new SortedDictionary<string, SortedDictionary<string, int>>();

            for (var i = 0; i < linesCount; i++)
            {
                var inputTokens = Console.ReadLine().Split();

                var user = inputTokens[1];

                if (usersLogs.ContainsKey(user) == false)
                {
                    usersLogs[user] = new SortedDictionary<string, int>();
                }

                var ip = inputTokens[0];

                if (usersLogs[user].ContainsKey(ip) == false)
                {
                    usersLogs[user][ip] = 0;
                }

                var sessionDuration = int.Parse(inputTokens[2]);

                usersLogs[user][ip] += sessionDuration;
            }

            foreach (var pair in usersLogs)
            {
                var user = pair.Key;
                var totalDuration = pair.Value.Values.Sum();
                var ips = pair.Value.Keys;

                Console.WriteLine($"{user}: {totalDuration} [{string.Join(", ", ips)}]");
            }
        }
    }
}