using System;

namespace P09.LinkedListTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            int commandsCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < commandsCount; counter++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string command = commandArgs[0];
                int number = int.Parse(commandArgs[1]);

                if (command == "Add")
                {
                    linkedList.Add(number);
                }
                else if (command == "Remove")
                {
                    linkedList.Remove(number);
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(' ', linkedList));
        }
    }
}
