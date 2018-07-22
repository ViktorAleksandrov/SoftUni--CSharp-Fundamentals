namespace P03.AnimalFarm
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());

            try
            {
                var chicken = new Chicken(name, age);

                Console.WriteLine(
                    $"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.ProductPerDay} eggs per day.");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}