using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.GenericSwapMethodString
{
    class Startup
    {
        static void Main()
        {
            int boxesCount = int.Parse(Console.ReadLine());

            var boxes = new List<Box<string>>();

            for (int counter = 0; counter < boxesCount; counter++)
            {
                string currentString = Console.ReadLine();

                var box = new Box<string>(currentString);

                boxes.Add(box);
            }

            int[] indices = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstIndex = indices[0];
            int secondIndex = indices[1];

            Swap(boxes, firstIndex, secondIndex);

            boxes.ForEach(Console.WriteLine);
        }

        static void Swap<T>(List<T> boxes, int firstIndex, int secondIndex)
        {
            T temp = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}