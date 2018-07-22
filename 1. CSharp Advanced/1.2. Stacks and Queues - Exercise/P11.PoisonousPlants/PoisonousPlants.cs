namespace P11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            var plantsNumber = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var indices = new Stack<int>();

            indices.Push(0);

            var days = new int[plantsNumber];

            for (int i = 1; i < plantsNumber; i++)
            {
                var currentPlant = plants[i];

                var maxDays = 0;

                while (indices.Count > 0 && plants[indices.Peek()] >= currentPlant)
                {
                    maxDays = Math.Max(maxDays, days[indices.Pop()]);
                }

                if (indices.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                indices.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}