namespace StorageMaster.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Entities.Products;
    using Entities.Storages;
    using Factories;
    using Entities.Vehicles;

    public class StorageMaster
    {
        private Vehicle currentVehicle;
        private List<Product> productsPool;
        private List<Storage> storageRegistry;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.productsPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = this.productFactory.CreateProduct(type, price);
            this.productsPool.Add(product);

            string output = $"Added {type} to pool";

            return output;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            string output = $"Registered {name}";

            return output;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.First(s => s.Name == storageName);

            this.currentVehicle = storage.GetVehicle(garageSlot);

            string output = $"Selected {this.currentVehicle.GetType().Name}";

            return output;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;

            foreach (string name in productNames)
            {
                Product product = this.productsPool.LastOrDefault(p => p.GetType().Name == name);

                if (product == null)
                {
                    throw new InvalidOperationException($"{name} is out of stock!");
                }

                this.productsPool.Remove(product);

                if (this.currentVehicle.IsFull)
                {
                    break;
                }

                this.currentVehicle.LoadProduct(product);

                loadedProductsCount++;
            }

            string output = $"Loaded {loadedProductsCount}/{productNames.Count()} products " +
                            $"into {this.currentVehicle.GetType().Name}";

            return output;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            Storage sourceStorage = this.storageRegistry
                .FirstOrDefault(s => s.Name == sourceName)
                ?? throw new InvalidOperationException("Invalid source storage!");

            Storage destinationStorage = this.storageRegistry
                .FirstOrDefault(s => s.Name == destinationName)
                ?? throw new InvalidOperationException("Invalid destination storage!");

            string vehicleType = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;

            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string output = $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";

            return output;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.First(s => s.Name == storageName);

            int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;

            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            string output = $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";

            return output;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = this.storageRegistry.First(s => s.Name == storageName);

            double productsWeightSum = storage.Products.Sum(p => p.Weight);

            string[] productsInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Select(g => $"{g.Key} ({g.Count()})")
                .ToArray();

            string stockInfoOutput = $"Stock ({productsWeightSum}/{storage.Capacity}): [{string.Join(", ", productsInfo)}]";

            Vehicle[] garage = storage.Garage.ToArray();

            string[] vehiclesNames = garage.Select(v => v?.GetType().Name ?? "empty").ToArray();

            string vehiclesOutput = $"Garage: [{string.Join('|', vehiclesNames)}]";

            string output = stockInfoOutput + Environment.NewLine + vehiclesOutput;

            return output;
        }

        public string GetSummary()
        {
            var orderedStorages = this.storageRegistry
                .OrderByDescending(s => s.Products.Sum(p => p.Price))
                .ToList();

            string output = string.Join(Environment.NewLine, orderedStorages);

            return output;
        }
    }
}