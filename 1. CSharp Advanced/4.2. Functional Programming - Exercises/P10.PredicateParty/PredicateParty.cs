namespace P10.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PredicateParty
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var inputTokens = input.Split();

                UpdateNames(names, inputTokens);

                input = Console.ReadLine();
            }

            PrintOutput(names);
        }

        private static void UpdateNames(List<string> names, string[] commandTokens)
        {
            var argument = commandTokens[2];

            Predicate<string> startsWith = s => s.StartsWith(argument);
            Predicate<string> endsWith = s => s.EndsWith(argument);
            Predicate<string> isLengthEqual = s => s.Length == int.Parse(argument);

            var action = commandTokens[0];
            var criteria = commandTokens[1];

            if (action == "Remove")
            {
                switch (criteria)
                {
                    case "StartsWith":
                        names.RemoveAll(startsWith);
                        break;
                    case "EndsWith":
                        names.RemoveAll(endsWith);
                        break;
                    case "Length":
                        names.RemoveAll(isLengthEqual);
                        break;
                }
            }
            else
            {
                switch (criteria)
                {
                    case "StartsWith":
                        DoubleString(names, startsWith);
                        break;
                    case "EndsWith":
                        DoubleString(names, endsWith);
                        break;
                    case "Length":
                        DoubleString(names, isLengthEqual);
                        break;
                }
            }
        }

        private static void DoubleString(List<string> names, Predicate<string> checkArgument)
        {
            for (int index = 0; index < names.Count; index++)
            {
                var currentName = names[index];

                if (checkArgument(currentName))
                {
                    names.Insert(index, currentName);
                    index++;
                }
            }
        }

        private static void PrintOutput(List<string> names)
        {
            if (names.Any())
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}