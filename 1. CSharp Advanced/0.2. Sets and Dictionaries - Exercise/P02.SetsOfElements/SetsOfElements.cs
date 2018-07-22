namespace P02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main()
        {
            var setsLengths = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var totalSetsLength = setsLengths.Sum();

            var firstSetLength = setsLengths[0];

            var firstSet = new HashSet<string>();
            var secondSet = new HashSet<string>();

            for (int i = 0; i < totalSetsLength; i++)
            {
                var element = Console.ReadLine();

                if (i < firstSetLength)
                {
                    firstSet.Add(element);
                }
                else if (firstSet.Contains(element))
                {
                    secondSet.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", secondSet));
        }
    }
}