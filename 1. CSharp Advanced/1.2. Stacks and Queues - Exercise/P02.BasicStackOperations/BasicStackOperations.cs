namespace P02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicStackOperations
    {
        public static void Main()
        {
            var inputTokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var pushCount = inputTokens[0];

            var numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < pushCount; i++)
            {
                var currentNumber = numbers[i];

                stack.Push(currentNumber);
            }

            var popCount = inputTokens[1];

            for (int i = 0; i < popCount; i++)
            {
                stack.Pop();
            }

            var containedNumber = inputTokens[2];

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(containedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}