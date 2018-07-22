namespace P05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            var inputNumber = long.Parse(Console.ReadLine());

            Console.Write(inputNumber + " ");

            var queue = new Queue<long>();

            queue.Enqueue(inputNumber);

            for (int i = 1; i < 50; i++)
            {
                if (i % 3 == 1)
                {
                    Console.Write(queue.Peek() + 1 + " ");

                    queue.Enqueue(queue.Peek() + 1);
                }
                else if (i % 3 == 2)
                {
                    Console.Write(queue.Peek() * 2 + 1 + " ");

                    queue.Enqueue(queue.Peek() * 2 + 1);
                }
                else
                {
                    Console.Write(queue.Peek() + 2 + " ");

                    queue.Enqueue(queue.Peek() + 2);

                    queue.Dequeue();
                }
            }

            Console.WriteLine();
        }
    }
}