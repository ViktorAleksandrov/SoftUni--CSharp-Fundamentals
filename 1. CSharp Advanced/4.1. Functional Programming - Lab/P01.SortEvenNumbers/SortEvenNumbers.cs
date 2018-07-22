namespace P01.SortEvenNumbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            var evenNumbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n % 2 == 0)
                .OrderBy(n => n);

            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}