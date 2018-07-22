namespace P07.PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            var maxLength = int.Parse(Console.ReadLine());

            Func<string, bool> filter = s => s.Length <= maxLength;

            Console.ReadLine()
                .Split()
                .Where(filter)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}