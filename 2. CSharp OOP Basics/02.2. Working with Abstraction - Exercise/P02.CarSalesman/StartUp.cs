namespace P02.CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var engines = new List<Engine>();

            FillEngines(engines);

            var cars = new List<Car>();

            FillCars(engines, cars);

            cars.ForEach(Console.WriteLine);
        }

        private static void FillEngines(List<Engine> engines)
        {
            var enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                var engineArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engineengineModel = engineArgs[0];
                var power = engineArgs[1];
                int displacement = -1;

                if (engineArgs.Length == 3 && int.TryParse(engineArgs[2], out displacement))
                {
                    engines.Add(new Engine(engineengineModel, power, displacement));
                }
                else if (engineArgs.Length == 3)
                {
                    var efficiency = engineArgs[2];

                    engines.Add(new Engine(engineengineModel, power, efficiency));
                }
                else if (engineArgs.Length == 4)
                {
                    displacement = int.Parse(engineArgs[2]);
                    var efficiency = engineArgs[3];

                    engines.Add(new Engine(engineengineModel, power, displacement, efficiency));
                }
                else
                {
                    engines.Add(new Engine(engineengineModel, power));
                }
            }
        }

        private static void FillCars(List<Engine> engines, List<Car> cars)
        {
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var carArgs = Console.ReadLine().Trim().Split();

                var carModel = carArgs[0];
                var engineModel = carArgs[1];
                var weight = -1;

                var engine = engines.First(e => e.Model == engineModel);

                if (carArgs.Length == 3 && int.TryParse(carArgs[2], out weight))
                {
                    cars.Add(new Car(carModel, engine, weight));
                }
                else if (carArgs.Length == 3)
                {
                    var color = carArgs[2];

                    cars.Add(new Car(carModel, engine, color));
                }
                else if (carArgs.Length == 4)
                {
                    weight = int.Parse(carArgs[2]);
                    var color = carArgs[3];

                    cars.Add(new Car(carModel, engine, weight, color));
                }
                else
                {
                    cars.Add(new Car(carModel, engine));
                }
            }
        }
    }
}