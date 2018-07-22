namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private const string EndCommand = "END";

        private StorageMaster storageMaster;

        public Engine()
        {
            this.storageMaster = new StorageMaster();
        }

        public void Run()
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != EndCommand)
            {
                string[] commandArgs = inputLine.Split();

                string command = commandArgs[0];

                string output = null;

                try
                {
                    switch (command)
                    {
                        case "AddProduct":
                            {
                                string type = commandArgs[1];
                                double price = double.Parse(commandArgs[2]);

                                output = this.storageMaster.AddProduct(type, price);
                                break;
                            }
                        case "RegisterStorage":
                            {
                                string type = commandArgs[1];
                                string name = commandArgs[2];

                                output = this.storageMaster.RegisterStorage(type, name);
                                break;
                            }
                        case "SelectVehicle":
                            {
                                string storageName = commandArgs[1];
                                int garageSlot = int.Parse(commandArgs[2]);

                                output = this.storageMaster.SelectVehicle(storageName, garageSlot);
                                break;
                            }
                        case "LoadVehicle":
                            {
                                IEnumerable<string> productNames = commandArgs.Skip(1);

                                output = this.storageMaster.LoadVehicle(productNames);
                                break;
                            }
                        case "SendVehicleTo":
                            {
                                string sourceName = commandArgs[1];
                                int sourceGarageSlot = int.Parse(commandArgs[2]);
                                string destinationName = commandArgs[3];

                                output = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                                break;
                            }
                        case "UnloadVehicle":
                            {
                                string storageName = commandArgs[1];
                                int garageSlot = int.Parse(commandArgs[2]);

                                output = this.storageMaster.UnloadVehicle(storageName, garageSlot);
                                break;
                            }
                        case "GetStorageStatus":
                            {
                                string storageName = commandArgs[1];

                                output = this.storageMaster.GetStorageStatus(storageName);
                                break;
                            }
                    }

                    Console.WriteLine(output);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine(this.storageMaster.GetSummary());
        }
    }
}