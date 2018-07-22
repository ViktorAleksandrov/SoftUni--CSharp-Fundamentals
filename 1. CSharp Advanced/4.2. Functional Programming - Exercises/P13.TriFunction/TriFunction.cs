namespace P13.TriFunction
{
    using System;
    using System.Linq;

    public class TriFunction
    {
        public static void Main()
        {
            var charsMinSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string, int, bool> isSumEnough = (s, i) => s.ToCharArray().Sum(c => c) >= i;

            Func<string[], int, Func<string, int, bool>, string> findName = (n, i, f) => n.FirstOrDefault(s => f(s, i));

            Console.WriteLine(findName(names, charsMinSum, isSumEnough));
        }
    }
}