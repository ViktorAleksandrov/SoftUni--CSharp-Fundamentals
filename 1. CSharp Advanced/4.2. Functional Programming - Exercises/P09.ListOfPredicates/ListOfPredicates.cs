namespace P09.ListOfPredicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ListOfPredicates
    {
        public static void Main()
        {
            var rangeEnd = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Distinct()
                .ToArray();

            Func<int, int, bool> isDivisible = (n, d) => n % d == 0;

            var numbers = new List<int>();

            for (int number = 1; number <= rangeEnd; number++)
            {
                var canBeDivided = true;

                foreach (var divider in dividers)
                {
                    if (isDivisible(number, divider) == false)
                    {
                        canBeDivided = false;
                        break;
                    }
                }

                if (canBeDivided)
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}