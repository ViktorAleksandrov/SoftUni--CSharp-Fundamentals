using System;
using System.Linq;

namespace P03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] commandArgs = inputLine.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string command = commandArgs[0];

                switch (command)
                {
                    case "Push":
                        stack.Push(commandArgs.Skip(1).ToArray());
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }
            }

            if (stack.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, stack));
            }
        }
    }
}
