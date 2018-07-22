namespace P01.ReverseNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split();

            var stack = new Stack<string>(elements);

            while (stack.Any())
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}