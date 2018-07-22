namespace P01.Vehicles
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm);

            string[] truckInfo = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfCommands; counter++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string vehicleType = commandArgs[1];
                string command = commandArgs[0];
                double amount = double.Parse(commandArgs[2]);

                switch (vehicleType)
                {
                    case "Car":
                        ExecuteCommand(car, command, amount);
                        break;
                    case "Truck":
                        ExecuteCommand(truck, command, amount);
                        break;
                }
            }

            PrintRemainingFuel(car, truck);
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double amount)
        {
            switch (command)
            {
                case "Drive":
                    vehicle.Drive(amount);
                    break;
                case "Refuel":
                    vehicle.Refuel(amount);
                    break;
            }
        }

        private static void PrintRemainingFuel(Vehicle car, Vehicle truck)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}