namespace P5.HotPotato
{
    using System;
    using System.Collections.Generic;

    public class HotPotato
    {
        public static void Main()
        {
            var names = Console.ReadLine().Split();

            var queue = new Queue<string>(names);

            var tossCount = int.Parse(Console.ReadLine());

            while (queue.Count > 1)
            {
                for (var i = 1; i < tossCount; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}