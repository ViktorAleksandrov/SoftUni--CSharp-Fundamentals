namespace P04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FindEvensOrOdds
    {
        public static void Main()
        {
            var rangeParams = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rangeStart = rangeParams[0];
            var rangeEnd = rangeParams[1];

            var command = Console.ReadLine();

            Predicate<int> isEven = n => n % 2 == 0;

            var numbers = new List<int>();

            for (int number = rangeStart; number <= rangeEnd; number++)
            {
                if (isEven(number) && command == "even"
                    || isEven(number) == false && command == "odd")
                {
                    numbers.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}