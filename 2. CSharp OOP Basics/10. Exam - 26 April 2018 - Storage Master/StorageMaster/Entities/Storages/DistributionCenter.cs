namespace StorageMaster.Entities.Storages
{
    using Vehicles;

    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name)
            : base(name, capacity: 2, garageSlots: 5, vehicles: new[] { new Van(), new Van(), new Van() })
        {
        }
    }
}