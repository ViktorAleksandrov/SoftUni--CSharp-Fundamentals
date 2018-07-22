namespace P2.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleCalculator
    {
        public static void Main()
        {
            var expressionTokens = Console.ReadLine().Split();

            var stack = new Stack<string>(expressionTokens.Reverse());

            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var @operator = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                stack.Push(@operator == "+"
                    ? (firstNum + secondNum).ToString()
                    : (firstNum - secondNum).ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}