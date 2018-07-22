namespace P1.RhombusOfStars
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var rhombusSize = int.Parse(Console.ReadLine());

            for (int starCount = 1; starCount <= rhombusSize; starCount++)
            {
                PrintRow(rhombusSize, starCount);
            }

            for (int starCount = rhombusSize - 1; starCount >= 1; starCount--)
            {
                PrintRow(rhombusSize, starCount);
            }
        }

        static void PrintRow(int rhombusSize, int starCount)
        {
            Console.Write(new string(' ', rhombusSize - starCount));

            for (int counter = 1; counter < starCount; counter++)
            {
                Console.Write("* ");
            }

            Console.WriteLine('*');
        }
    }
}