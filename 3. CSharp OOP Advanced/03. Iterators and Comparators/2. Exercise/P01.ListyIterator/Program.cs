﻿using System;
using System.Linq;

namespace P01.ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split().Skip(1).ToArray();

            var listyIterator = new ListyIterator<string>(elements);

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
