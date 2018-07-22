namespace P10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            var operationCount = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();

            var text = new StringBuilder();

            for (int i = 0; i < operationCount; i++)
            {
                var inputTokens = Console.ReadLine().Split();

                var command = inputTokens[0];

                if (command == "1")
                {
                    stack.Push(text.ToString());

                    var someString = inputTokens[1];

                    text.Append(someString);
                }
                else if (command == "2")
                {
                    stack.Push(text.ToString());

                    var eraseLength = int.Parse(inputTokens[1]);

                    var index = text.Length - eraseLength;

                    text.Remove(index, eraseLength);
                }
                else if (command == "3")
                {
                    var index = int.Parse(inputTokens[1]) - 1;

                    var element = text[index];

                    Console.WriteLine(element);
                }
                else
                {
                    text.Clear();
                    text.Append(stack.Pop());
                }
            }
        }
    }
}