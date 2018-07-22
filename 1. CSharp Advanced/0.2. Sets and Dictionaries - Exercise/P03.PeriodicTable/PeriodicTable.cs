namespace P03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main()
        {
            var linesCount = int.Parse(Console.ReadLine());

            var allChemicals = new SortedSet<string>();

            for (int i = 0; i < linesCount; i++)
            {
                var currentChemicals = Console.ReadLine().Split();

                foreach (var chemical in currentChemicals)
                {
                    allChemicals.Add(chemical);
                }
            }

            Console.WriteLine(string.Join(" ", allChemicals));
        }
    }
}