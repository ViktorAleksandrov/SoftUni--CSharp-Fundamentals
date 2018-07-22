using System;

namespace P10.Tuple
{
    class Startup
    {
        static void Main()
        {
            string[] firstLine = ParseInput();
            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];

            var firstTuple = new Tuple<string, string>(fullName, address);

            Console.WriteLine(firstTuple);

            string[] secondLine = ParseInput();
            string name = secondLine[0];
            int beerLiters = int.Parse(secondLine[1]);

            var secondTuple = new Tuple<string, int>(name, beerLiters);

            Console.WriteLine(secondTuple);

            string[] thirdLine = ParseInput();
            int integer = int.Parse(thirdLine[0]);
            double doubleNumber = double.Parse(thirdLine[1]);

            var thirdTuple = new Tuple<int, double>(integer, doubleNumber);

            Console.WriteLine(thirdTuple);
        }

        static string[] ParseInput()
        {
            string[] inputArgs = Console.ReadLine().Split();

            return inputArgs;
        }
    }
}