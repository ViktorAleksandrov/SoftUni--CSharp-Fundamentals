namespace P07.SpeedRacing
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

            TryToMoveCar(cars);

            cars.ForEach(Console.WriteLine);
        }

        private static void CreateCars(List<Car> cars)
        {
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var carArgs = Console.ReadLine().Split();

                var model = carArgs[0];
                var fuelAmount = double.Parse(carArgs[1]);
                var consumptionPerKm = double.Parse(carArgs[2]);

                cars.Add(new Car(model, fuelAmount, consumptionPerKm));
            }
        }

        private static void TryToMoveCar(List<Car> cars)
        {
            while (true)
            {
                var commandArgs = Console.ReadLine().Split();

                if (commandArgs[0] == "End")
                {
                    break;
                }

                var model = commandArgs[1];
                var distance = int.Parse(commandArgs[2]);

                var car = cars.First(c => c.Model == model);

                car.TryToMove(distance);
            }
        }
    }
}