namespace P04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main()
        {
            var inputTokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var enqueueCount = inputTokens[0];

            var numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < enqueueCount; i++)
            {
                var currentNumber = numbers[i];

                queue.Enqueue(currentNumber);
            }

            var dequeueCount = inputTokens[1];

            for (int i = 0; i < dequeueCount; i++)
            {
                queue.Dequeue();
            }

            var containedNumber = inputTokens[2];

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(containedNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}