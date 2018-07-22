using System;

namespace P01.GenericBoxOfString
{
    class Startup
    {
        static void Main()
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfStrings; counter++)
            {
                string currentString = Console.ReadLine();

                var box = new Box<string>(currentString);

                Console.WriteLine(box);
            }
        }
    }
}