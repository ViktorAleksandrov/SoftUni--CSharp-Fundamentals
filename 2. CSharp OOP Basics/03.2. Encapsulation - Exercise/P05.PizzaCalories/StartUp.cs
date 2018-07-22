namespace P05.PizzaCalories
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            try
            {
                var pizzaName = Console.ReadLine().Split().Last();

                var pizza = new Pizza(pizzaName);

                AddDough(pizza);

                AddTopping(pizza);

                PrintOutput(pizza);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        private static void AddDough(Pizza pizza)
        {
            var doughInfo = Console.ReadLine().Split();

            var flourType = doughInfo[1];
            var bakingTechnique = doughInfo[2];
            var doughWeight = int.Parse(doughInfo[3]);

            pizza.Dough = new Dough(flourType, bakingTechnique, doughWeight);
        }

        private static void AddTopping(Pizza pizza)
        {
            while (true)
            {
                var toppingInfo = Console.ReadLine().Split();

                if (toppingInfo[0] == "END")
                {
                    break;
                }

                var toppingType = toppingInfo[1];
                var toppingWeight = int.Parse(toppingInfo[2]);

                var topping = new Topping(toppingType, toppingWeight);

                pizza.AddTopping(topping);
            }
        }

        private static void PrintOutput(Pizza pizza)
        {
            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}