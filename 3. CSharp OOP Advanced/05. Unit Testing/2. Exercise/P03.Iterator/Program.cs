using System;
using System.Linq;

namespace P03.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ListIterator listIterator = null;

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] commandArgs = inputLine.Split();

                string command = commandArgs[0];

                try
                {
                    switch (command)
                    {
                        case "Create":
                            listIterator = new ListIterator(commandArgs.Skip(1));
                            break;
                        case "Move":
                            Console.WriteLine(listIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listIterator.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(listIterator.Print());
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch
                {
                }
            }
        }
    }
}
