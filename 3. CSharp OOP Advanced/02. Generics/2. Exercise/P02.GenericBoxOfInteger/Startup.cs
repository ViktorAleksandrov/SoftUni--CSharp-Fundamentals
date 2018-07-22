using System;

namespace P02.GenericBoxOfInteger
{
    class Startup
    {
        static void Main()
        {
            int numberOfInts = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfInts; counter++)
            {
                int currentInt = int.Parse(Console.ReadLine());

                var box = new Box<int>(currentInt);

                Console.WriteLine(box);
            }
        }
    }
}