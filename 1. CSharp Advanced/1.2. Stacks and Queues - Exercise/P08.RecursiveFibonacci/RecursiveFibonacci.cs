namespace P08.RecursiveFibonacci
{
    using System;

    public class RecursiveFibonacci
    {
        private static long[] fiboNums;

        public static void Main()
        {
            var fiboNumber = int.Parse(Console.ReadLine());

            fiboNums = new long[fiboNumber];

            var nthFiboNumber = GetFibonacci(fiboNumber);

            Console.WriteLine(nthFiboNumber);
        }

        private static long GetFibonacci(int fiboNumber)
        {
            if (fiboNumber <= 2)
            {
                return 1;
            }

            if (fiboNums[fiboNumber - 1] != 0)
            {
                return fiboNums[fiboNumber - 1];
            }

            return fiboNums[fiboNumber - 1] =
                GetFibonacci(fiboNumber - 1) + GetFibonacci(fiboNumber - 2);
        }
    }
}