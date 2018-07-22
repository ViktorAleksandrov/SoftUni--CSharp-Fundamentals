namespace P04.TreasureMap
{
    using System;
    using System.Text.RegularExpressions;

    public class TreasureMap
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var regex = new Regex(@"(!|#)[^!#]*?\b(?<streetName>[A-Za-z]{4})\b[^!#]*(?<!\d)(?<streetNumber>\d{3})-(?<password>\d{6}|\d{4})(?!\d)[^!#]*?(?!\1)(#|!)");

            for (int line = 0; line < linesCount; line++)
            {
                var inputLine = Console.ReadLine();

                var matches = regex.Matches(inputLine);

                var mostInnerMatch = matches[matches.Count / 2];

                var streetName = mostInnerMatch.Groups["streetName"].Value;
                var streetNumber = mostInnerMatch.Groups["streetNumber"].Value;
                var password = mostInnerMatch.Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}