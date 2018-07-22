namespace P04.CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var charsOccurrences = new SortedDictionary<char, int>();

            foreach (var element in text)
            {
                if (charsOccurrences.ContainsKey(element) == false)
                {
                    charsOccurrences[element] = 0;
                }

                charsOccurrences[element]++;
            }

            foreach (var pair in charsOccurrences)
            {
                var element = pair.Key;
                var occurrenceCount = pair.Value;

                Console.WriteLine($"{element}: {occurrenceCount} time/s");
            }
        }
    }
}