namespace P3.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse);

            var dict = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                if (dict.ContainsKey(num) == false)
                {
                    dict[num] = 0;
                }

                dict[num]++;
            }

            foreach (var pair in dict)
            {
                var number = pair.Key;
                var occurence = pair.Value;

                Console.WriteLine($"{number} - {occurence} times");
            }
        }
    }
}