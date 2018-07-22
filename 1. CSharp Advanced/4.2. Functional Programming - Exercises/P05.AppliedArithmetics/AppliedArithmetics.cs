namespace P05.AppliedArithmetics
{
    using System;
    using System.Linq;

    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int[]> add = n => n.Select(i => i + 1).ToArray();
            Func<int[], int[]> subtract = n => n.Select(i => i - 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(i => i * 2).ToArray();

            Action<int[]> print = n => Console.WriteLine(string.Join(" ", n));

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}