namespace P09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    public class StackFibonacci
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            while (number > 1)
            {
                var firstFibo = stack.Pop();
                var secondFibo = stack.Peek();

                stack.Push(firstFibo);
                stack.Push(firstFibo + secondFibo);

                number--;
            }

            Console.WriteLine(stack.Pop());
        }
    }
}