namespace P04.AddVAT
{
    using System;
    using System.Linq;

    public class AddVAT
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(s => double.Parse(s) * 1.2)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n:F2}"));
        }
    }
}