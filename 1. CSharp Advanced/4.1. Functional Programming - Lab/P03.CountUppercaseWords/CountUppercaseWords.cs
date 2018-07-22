namespace P03.CountUppercaseWords
{
    using System;
    using System.Linq;

    public class CountUppercaseWords
    {
        public static void Main()
        {
            Func<string, bool> checkUppercase = s => char.IsUpper(s[0]);

            Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(checkUppercase)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}