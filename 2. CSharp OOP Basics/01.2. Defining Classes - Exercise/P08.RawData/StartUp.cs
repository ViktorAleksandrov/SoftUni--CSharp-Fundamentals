namespace P08.RawData
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

                var speed = int.Parse(carArgs[1]);
                var power = int.Parse(carArgs[2]);

                var engine = new Engine(speed, power);

                var weight = int.Parse(carArgs[3]);
                var type = carArgs[4];

                var cargo = new Cargo(weight, type);

                var tires = new List<Tire>(4);

                for (int index = 5; index < carArgs.Length; index += 2)
                {
                    var pressure = double.Parse(carArgs[index]);
                    var age = int.Parse(carArgs[index + 1]);

                    var tire = new Tire(pressure, age);

                    tires.Add(tire);
                }

                var model = carArgs[0];

                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
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