namespace StorageMaster.Entities.Storages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Products;
    using Vehicles;

    public abstract class Storage
    {
        private Vehicle[] garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[garageSlots];
            this.products = new List<Product>();
            this.InitializeGarage(vehicles);
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle sentVehicle = this.GetVehicle(garageSlot);

            if (deliveryLocation.Garage.All(v => v != null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;

            int freeGarageSlotIndex = Array.IndexOf(deliveryLocation.garage, null);

            deliveryLocation.garage[freeGarageSlotIndex] = sentVehicle;

            return freeGarageSlotIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = this.GetVehicle(garageSlot);

            int unloadedProductsCount = 0;

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                Product product = vehicle.Unload();
                this.products.Add(product);

                unloadedProductsCount++;
            }

            return unloadedProductsCount;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            int garageSlot = 0;

            foreach (Vehicle vehicle in vehicles)
            {
                this.garage[garageSlot++] = vehicle;
            }
        }

        public override string ToString()
        {
            double totalMoney = this.Products.Sum(p => p.Price);

            string output = $"{this.Name}:" + Environment.NewLine +
                            $"Storage worth: ${totalMoney:F2}";

            return output;
        }
    }
}