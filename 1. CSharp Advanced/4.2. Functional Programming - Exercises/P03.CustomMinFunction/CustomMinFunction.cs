namespace P03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> findMin = n => n.Min();

            Console.WriteLine(findMin(numbers));
        }
    }
}