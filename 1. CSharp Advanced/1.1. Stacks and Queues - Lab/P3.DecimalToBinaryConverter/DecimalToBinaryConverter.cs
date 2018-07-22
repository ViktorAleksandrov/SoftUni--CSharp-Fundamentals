namespace P3.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var decimalNum = int.Parse(Console.ReadLine());

            if (decimalNum == 0)
            {
                Console.WriteLine(0);

                return;
            }

            var stack = new Stack<int>();

            while (decimalNum > 0)
            {
                var remainder = decimalNum % 2;

                stack.Push(remainder);

                decimalNum /= 2;
            }

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}