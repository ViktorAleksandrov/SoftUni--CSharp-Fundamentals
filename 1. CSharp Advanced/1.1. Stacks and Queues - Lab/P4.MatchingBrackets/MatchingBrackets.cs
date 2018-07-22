namespace P4.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class MatchingBrackets
    {
        public static void Main()
        {
            var expression = Console.ReadLine();

            var stack = new Stack<int>();

            for (var i = 0; i < expression.Length; i++)
            {
                var element = expression[i];

                if (element == '(')
                {
                    stack.Push(i);
                }
                else if (element == ')')
                {
                    var startIndex = stack.Pop();
                    var length = i - startIndex + 1;

                    var subexpression = expression.Substring(startIndex, length);

                    Console.WriteLine(subexpression);
                }
            }
        }
    }
}