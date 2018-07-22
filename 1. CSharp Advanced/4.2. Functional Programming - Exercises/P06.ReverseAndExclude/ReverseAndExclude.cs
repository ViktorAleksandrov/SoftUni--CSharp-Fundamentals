namespace P06.ReverseAndExclude
{
    using System;
    using System.Linq;

    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> filter = n => n % divisor != 0;

            Console.WriteLine(string.Join(" ", numbers.Where(filter).Reverse()));
        }
    }
}