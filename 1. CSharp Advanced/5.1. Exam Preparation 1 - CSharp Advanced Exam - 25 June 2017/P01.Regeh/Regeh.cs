namespace P01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main()
        {
            var inputLine = Console.ReadLine();

            var numbers = CollectNumbers(inputLine);

            var result = BuildOutput(inputLine, numbers);

            Console.WriteLine(result);
        }

        private static List<int> CollectNumbers(string inputLine)
        {
            var regex = new Regex(@"\[\w+<(\d+)REGEH(\d+)>\w+]");

            var matches = regex.Matches(inputLine);

            var numbers = new List<int>();

            foreach (Match match in matches)
            {
                var leftNumber = int.Parse(match.Groups[1].Value);
                var rightNumber = int.Parse(match.Groups[2].Value);

                numbers.Add(leftNumber);
                numbers.Add(rightNumber);
            }

            return numbers;
        }

        private static StringBuilder BuildOutput(string inputLine, List<int> numbers)
        {
            var index = 0;

            var result = new StringBuilder(numbers.Count);

            foreach (var num in numbers)
            {
                index += num;

                index %= (inputLine.Length - 1);

                var currentChar = inputLine[index];

                result.Append(currentChar);
            }

            return result;
        }
    }
}