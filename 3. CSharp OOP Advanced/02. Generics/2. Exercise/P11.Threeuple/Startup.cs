using System;

namespace P11.Threeuple
{
    class Startup
    {
        static void Main()
        {
            string[] firstLine = ParseInput();
            string fullName = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];
            string town = firstLine[3];

            var firstThreeuple = new Threeuple<string, string, string>(fullName, address, town);

            Console.WriteLine(firstThreeuple);

            string[] secondLine = ParseInput();
            string name = secondLine[0];
            int beerLiters = int.Parse(secondLine[1]);
            bool isDrunk = secondLine[2] == "drunk";

            var secondThreeuple = new Threeuple<string, int, bool>(name, beerLiters, isDrunk);

            Console.WriteLine(secondThreeuple);

            string[] thirdLine = ParseInput();
            string firstName = thirdLine[0];
            double accountBalance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];

            var thirdThreeuple = new Threeuple<string, double, string>(firstName, accountBalance, bankName);

            Console.WriteLine(thirdThreeuple);
        }

        static string[] ParseInput()
        {
            string[] inputArgs = Console.ReadLine().Split();

            return inputArgs;
        }
    }
}