using System;

namespace P00.GenericBox
{
    class Startup
    {
        static void Main()
        {
            string input = Console.ReadLine();

            bool isInt = int.TryParse(input, out int number);

            string output;

            if (isInt)
            {
                output = new Box<int>(number).ToString();
            }
            else
            {
                output = new Box<string>(input).ToString();
            }

            Console.WriteLine(output);
        }
    }
}