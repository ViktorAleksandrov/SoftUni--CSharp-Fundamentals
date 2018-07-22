using System;
using System.Collections.Generic;

namespace P05.GenericCountMethodString
{
    class Startup
    {
        static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            var elements = new List<string>();

            for (int counter = 0; counter < elementsCount; counter++)
            {
                string element = Console.ReadLine();

                elements.Add(element);
            }

            string elementToCompare = Console.ReadLine();

            int greaterElementsCount = Count(elements, elementToCompare);

            Console.WriteLine(greaterElementsCount);
        }

        static int Count<T>(List<T> elements, T elementToCompare)
            where T : IComparable<T>
        {
            int counter = 0;

            foreach (T element in elements)
            {
                int comparisonResult = element.CompareTo(elementToCompare);

                if (comparisonResult > 0)
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}