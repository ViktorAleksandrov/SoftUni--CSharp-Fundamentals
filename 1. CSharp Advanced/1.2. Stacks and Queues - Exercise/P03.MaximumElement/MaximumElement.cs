namespace P03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main()
        {
            var lineCount = int.Parse(Console.ReadLine());

            var allNumbersStack = new Stack<int>();
            var maxNumbersStack = new Stack<int>();

            var maxNumber = int.MinValue;

            for (int i = 0; i < lineCount; i++)
            {
                var inputLine = Console.ReadLine();

                if (inputLine.StartsWith("1"))
                {
                    var number = int.Parse(inputLine.Split().Last());

                    if (number > maxNumber)
                    {
                        maxNumber = number;

                        maxNumbersStack.Push(maxNumber);
                    }

                    allNumbersStack.Push(number);
                }
                else if (inputLine == "2")
                {
                    if (allNumbersStack.Pop() == maxNumber)
                    {
                        maxNumbersStack.Pop();

                        if (maxNumbersStack.Any())
                        {
                            maxNumber = maxNumbersStack.Peek();
                        }
                        else
                        {
                            maxNumber = int.MinValue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(maxNumber);
                }
            }
        }
    }
}