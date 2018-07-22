namespace P04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            var targetInfoIndex = int.Parse(Console.ReadLine());

            var peopleInfo = new Dictionary<string, SortedDictionary<string, string>>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "end transmissions")
                {
                    break;
                }

                FillPeopleData(peopleInfo, inputLine);
            }

            PrintOutput(targetInfoIndex, peopleInfo);
        }

        private static void FillPeopleData(Dictionary<string, SortedDictionary<string, string>> peopleData, string inputLine)
        {
            var tokens = inputLine
                .Split(new[] { '=', ':', ';' }, StringSplitOptions.None);

            var name = tokens[0];

            if (peopleData.ContainsKey(name) == false)
            {
                peopleData[name] = new SortedDictionary<string, string>();
            }

            for (int index = 1; index < tokens.Length; index += 2)
            {
                var key = tokens[index];
                var value = tokens[index + 1];

                peopleData[name][key] = value;
            }
        }

        private static void PrintOutput(int targetInfoIndex, Dictionary<string, SortedDictionary<string, string>> peopleData)
        {
            var targetName = Console.ReadLine().Split().Last();

            Console.WriteLine($"Info on {targetName}:");

            foreach (var pair in peopleData[targetName])
            {
                Console.WriteLine($"---{pair.Key}: {pair.Value}");
            }

            var infoIndex = peopleData[targetName]
                .Sum(kvp => kvp.Key.Length + kvp.Value.Length);

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                var infoNeeded = targetInfoIndex - infoIndex;

                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }
    }
}