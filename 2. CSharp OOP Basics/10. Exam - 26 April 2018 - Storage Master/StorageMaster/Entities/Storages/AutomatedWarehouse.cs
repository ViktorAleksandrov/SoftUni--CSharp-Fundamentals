namespace StorageMaster.Entities.Storages
{
    using Vehicles;

    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name)
            : base(name, capacity: 1, garageSlots: 2, vehicles: new[] { new Truck() })
        {
        }
    }
}