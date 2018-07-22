namespace P07.FoodShortage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var buyers = new List<IBuyer>();

            AddBuyers(buyers);

            TryBuyFood(buyers);

            PrintPurchasedFood(buyers);
        }

        private static void AddBuyers(List<IBuyer> buyers)
        {
            var numberOfBuyers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBuyers; i++)
            {
                var buyerInfo = Console.ReadLine().Split();

                var name = buyerInfo[0];
                var age = int.Parse(buyerInfo[1]);

                if (buyerInfo.Length == 4)
                {
                    var id = buyerInfo[2];
                    var birthdate = buyerInfo[3];

                    buyers.Add(new Citizen(name, age, id, birthdate));
                }
                else
                {
                    var group = buyerInfo[2];

                    buyers.Add(new Rebel(name, age, group));
                }
            }
        }

        private static void TryBuyFood(List<IBuyer> buyers)
        {
            while (true)
            {
                var name = Console.ReadLine();

                if (name == "End")
                {
                    break;
                }

                var buyer = buyers.FirstOrDefault(b => b.Name == name);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
        }

        private static void PrintPurchasedFood(List<IBuyer> buyers)
        {
            Console.WriteLine(buyers.Sum(p => p.Food));
        }
    }
}