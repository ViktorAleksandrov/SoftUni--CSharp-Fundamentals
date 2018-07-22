namespace P07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesis
    {
        public static void Main()
        {
            var parentheses = Console.ReadLine();

            if (parentheses.Length % 2 == 1)
            {
                Console.WriteLine("NO");
                return;
            }

            var stack = new Stack<char>();

            var areBalanced = true;

            foreach (var element in parentheses)
            {
                if (element == '(' || element == '[' || element == '{')
                {
                    stack.Push(element);
                }
                else if (stack.Count == 0)
                {
                    areBalanced = false;
                    break;
                }
                else
                {
                    var openedBrace = stack.Pop();

                    if (openedBrace == '(' && element != ')')
                    {
                        areBalanced = false;
                        break;
                    }
                    else if (openedBrace == '[' && element != ']')
                    {
                        areBalanced = false;
                        break;
                    }
                    else if (openedBrace == '{' && element != '}')
                    {
                        areBalanced = false;
                        break;
                    }
                }
            }

            Console.WriteLine(areBalanced ? "YES" : "NO");
        }
    }
}