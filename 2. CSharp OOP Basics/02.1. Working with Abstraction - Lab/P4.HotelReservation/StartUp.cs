using System;

namespace P4.HotelReservation
{
    class StartUp
    {
        static void Main()
        {
            var reservationInfo = Console.ReadLine().Split();

            var priceCalculator = new PriceCalculator(reservationInfo);

            var totalPrice = priceCalculator.CalculatePrice();

            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}