namespace P08.CustomComparator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var comparer = Comparer<int>.Create((x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            });

            Array.Sort(numbers, comparer);

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}