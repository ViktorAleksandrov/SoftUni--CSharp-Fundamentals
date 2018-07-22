namespace P06.TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            var pumpsCount = int.Parse(Console.ReadLine());

            var queue = new Queue<long>();

            for (int i = 0; i < pumpsCount; i++)
            {
                var pumpTokens = Console.ReadLine()
                    .Split()
                    .Select(long.Parse)
                    .ToArray();

                queue.Enqueue(pumpTokens[0]);
                queue.Enqueue(pumpTokens[1]);
            }

            var excess = 0L;
            var moves = 0;
            var index = 1;

            while (true)
            {
                var petrolAmount = queue.Dequeue();
                var distance = queue.Dequeue();

                if (petrolAmount + excess >= distance)
                {
                    moves++;

                    if (moves == pumpsCount)
                    {
                        Console.WriteLine(index % pumpsCount);
                        break;
                    }

                    excess += petrolAmount - distance;
                }
                else
                {
                    excess = 0;
                    moves = 0;
                }

                queue.Enqueue(petrolAmount);
                queue.Enqueue(distance);

                index++;
            }
        }
    }
}