namespace P10.CarSalesman
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

                var displacement = "n/a";
                var efficiency = "n/a";

                if (engineArgs.Length > 2)
                {
                    if (int.TryParse(engineArgs[2], out _))
                    {
                        displacement = engineArgs[2];

                        if (engineArgs.Length > 3)
                        {
                            efficiency = engineArgs[3];
                        }
                    }
                    else
                    {
                        efficiency = engineArgs[2];
                    }
                }

                var engineModel = engineArgs[0];
                var power = engineArgs[1];

                var engine = new Engine(engineModel, power, displacement, efficiency);

                engines.Add(engine);
            }
        }

        private static void FillCars(List<Engine> engines, List<Car> cars)
        {
            var carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                var carArgs = Console.ReadLine().Trim().Split();

                var weight = "n/a";
                var color = "n/a";

                if (carArgs.Length > 2)
                {
                    if (int.TryParse(carArgs[2], out _))
                    {
                        weight = carArgs[2];

                        if (carArgs.Length > 3)
                        {
                            color = carArgs[3];
                        }
                    }
                    else
                    {
                        color = carArgs[2];
                    }
                }

                var carModel = carArgs[0];
                var engineModel = carArgs[1];

                var engine = engines.First(e => e.Model == engineModel);

                var car = new Car(carModel, engine, weight, color);

                cars.Add(car);
            }
        }
    }
}