namespace P02.SumNumbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            Func<string, int> intParser = s => int.Parse(s);

            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(intParser)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());
        }
    }
}