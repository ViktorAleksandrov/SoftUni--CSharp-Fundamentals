namespace P13.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SrabskoUnleashed
    {
        public static void Main()
        {
            var validInputPattern = new Regex(
                @"^(?<singer>[a-zA-Z]+(?:\s[a-zA-Z]+){0,2})\s@(?<venue>[a-zA-Z]+(?:\s[a-zA-Z]+){0,2})\s(?<price>\d+)\s(?<count>\d+)$");

            var concertData = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                var match = validInputPattern.Match(inputLine);

                if (match.Success == false)
                {
                    continue;
                }

                var venue = match.Groups["venue"].Value;

                if (concertData.ContainsKey(venue) == false)
                {
                    concertData[venue] = new Dictionary<string, int>();
                }

                var singer = match.Groups["singer"].Value;

                if (concertData[venue].ContainsKey(singer) == false)
                {
                    concertData[venue][singer] = 0;
                }

                var ticketPrice = int.Parse(match.Groups["price"].Value);
                var ticketCount = int.Parse(match.Groups["count"].Value);

                var income = ticketPrice * ticketCount;

                concertData[venue][singer] += income;
            }

            foreach (var pair in concertData)
            {
                var venue = pair.Key;

                Console.WriteLine(venue);

                foreach (var singerIncome in pair.Value.OrderByDescending(kvp => kvp.Value))
                {
                    var singer = singerIncome.Key;
                    var income = singerIncome.Value;

                    Console.WriteLine($"#  {singer} -> {income}");
                }
            }
        }
    }
}