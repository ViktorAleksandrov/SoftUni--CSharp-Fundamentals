namespace P1.ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseStrings
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>();

            foreach (var symbol in input)
            {
                stack.Push(symbol);
            }

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}