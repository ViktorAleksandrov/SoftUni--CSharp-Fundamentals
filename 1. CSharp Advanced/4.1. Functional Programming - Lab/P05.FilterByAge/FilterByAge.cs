namespace P05.FilterByAge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FilterByAge
    {
        public static void Main()
        {
            var linesNumber = int.Parse(Console.ReadLine());

            var personsData = new Dictionary<string, int>(linesNumber);

            FillPersonsData(linesNumber, personsData);

            var condition = Console.ReadLine();
            var ageLimit = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var ageFilter = FilterAge(condition, ageLimit);

            var printer = CheckWhatToPrint(format);

            personsData
                .Where(kvp => ageFilter(kvp.Value))
                .ToList()
                .ForEach(printer);
        }

        private static void FillPersonsData(int linesNumber, Dictionary<string, int> personsData)
        {
            for (int i = 0; i < linesNumber; i++)
            {
                var lineTokens = Console.ReadLine()
                    .Split(new[] { ", " }, StringSplitOptions.None)
                    .ToArray();

                var name = lineTokens[0];
                var age = int.Parse(lineTokens[1]);

                personsData[name] = age;
            }
        }

        private static Func<int, bool> FilterAge(string condition, int ageLimit)
        {
            if (condition == "younger")
            {
                return a => a < ageLimit;
            }

            return a => a >= ageLimit;
        }

        private static Action<KeyValuePair<string, int>> CheckWhatToPrint(string format)
        {
            switch (format)
            {
                case "name":
                    return pair => Console.WriteLine(pair.Key);
                case "age":
                    return pair => Console.WriteLine(pair.Value);
                default:
                    return pair => Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
        }
    }
}