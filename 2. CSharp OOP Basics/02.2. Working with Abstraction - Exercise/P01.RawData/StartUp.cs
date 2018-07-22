namespace P01.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var cars = new List<Car>();

            CreateCars(cars);

            PrintOutput(cars);
        }

        private static void CreateCars(List<Car> cars)
        {
            var carsAmount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsAmount; i++)
            {
                var carArgs = Console.ReadLine().Split();

                cars.Add(new Car(carArgs));
            }
        }

        private static void PrintOutput(List<Car> cars)
        {
            var command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}