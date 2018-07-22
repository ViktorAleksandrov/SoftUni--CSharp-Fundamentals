namespace StorageMaster.Entities.Storages
{
    using Vehicles;

    public class Warehouse : Storage
    {
        public Warehouse(string name)
            : base(name, capacity: 10, garageSlots: 10, vehicles: new[] { new Semi(), new Semi(), new Semi() })
        {
        }
    }
}