namespace P02.KnightsOfHonor
{
    using System;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            var names = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Action<string> printWithTitle = n => Console.WriteLine($"Sir {n}");

            foreach (var name in names)
            {
                printWithTitle(name);
            }
        }
    }
}