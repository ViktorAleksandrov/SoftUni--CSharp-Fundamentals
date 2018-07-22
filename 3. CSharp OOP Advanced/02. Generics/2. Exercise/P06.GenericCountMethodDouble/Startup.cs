using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.GenericCountMethodDouble
{
    class Startup
    {
        static void Main()
        {
            int elementsCount = int.Parse(Console.ReadLine());

            var elements = new List<double>();

            for (int counter = 0; counter < elementsCount; counter++)
            {
                double element = double.Parse(Console.ReadLine());

                elements.Add(element);
            }

            double elementToCompare = double.Parse(Console.ReadLine());

            int greaterElementsCount = Count(elements, elementToCompare);

            Console.WriteLine(greaterElementsCount);
        }

        static int Count<T>(List<T> elements, T elementToCompare)
            where T : IComparable<T>
        {
            int count = elements.Count(e => e.CompareTo(elementToCompare) > 0);

            return count;
        }
    }
}