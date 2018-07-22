namespace P7.MathPotato
{
    using System;
    using System.Collections.Generic;

    public class MathPotato
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();

            var queue = new Queue<string>(names);

            var tossCount = int.Parse(Console.ReadLine());

            var cycles = 1;

            while (queue.Count > 1)
            {
                for (var i = 1; i < tossCount; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                var isPrime = IsNumberPrime(cycles);

                Console.WriteLine(isPrime
                    ? $"Prime {queue.Peek()}"
                    : $"Removed {queue.Dequeue()}");

                cycles++;
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }

        private static bool IsNumberPrime(int cycles)
        {
            if (cycles == 1)
            {
                return false;
            }

            var length = Math.Sqrt(cycles);

            for (var index = 2; index <= length; index++)
            {
                if (cycles % index == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}