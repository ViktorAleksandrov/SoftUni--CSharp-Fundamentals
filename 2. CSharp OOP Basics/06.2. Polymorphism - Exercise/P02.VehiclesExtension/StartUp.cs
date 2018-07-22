namespace P02.VehiclesExtension
{
    using System;

    class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carLitersPerKm = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

            string[] truckInfo = Console.ReadLine().Split();

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckLitersPerKm = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

            string[] busInfo = Console.ReadLine().Split();

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busLitersPerKm = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < numberOfCommands; counter++)
            {
                string[] commandArgs = Console.ReadLine().Split();

                string vehicleType = commandArgs[1];
                string command = commandArgs[0];
                double amount = double.Parse(commandArgs[2]);

                try
                {
                    switch (vehicleType)
                    {
                        case "Car":
                            ExecuteCommand(car, command, amount);
                            break;
                        case "Truck":
                            ExecuteCommand(truck, command, amount);
                            break;
                        case "Bus":
                            ExecuteCommand(bus, command, amount);
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            PrintRemainingFuel(car, truck, bus);
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
                case "DriveEmpty":
                    ((Bus)vehicle).DriveEmpty(amount);
                    break;
            }
        }

        private static void PrintRemainingFuel(Vehicle car, Vehicle truck, Vehicle bus)
        {
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}