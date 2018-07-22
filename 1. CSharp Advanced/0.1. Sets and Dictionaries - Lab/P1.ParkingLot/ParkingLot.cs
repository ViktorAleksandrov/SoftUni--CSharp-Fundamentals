namespace P1.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ParkingLot
    {
        public static void Main()
        {
            var carNumbers = new SortedSet<string>();

            while (true)
            {
                var inputTokens = Regex.Split(Console.ReadLine(), ", ");

                var direction = inputTokens[0];

                if (direction == "END")
                {
                    break;
                }

                var carNumber = inputTokens[1];

                if (direction == "IN")
                {
                    carNumbers.Add(carNumber);
                }
                else
                {
                    carNumbers.Remove(carNumber);
                }
            }

            if (carNumbers.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, carNumbers));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}