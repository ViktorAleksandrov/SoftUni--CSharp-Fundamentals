namespace StorageMaster.Factories
{
    using System;
    using Entities.Storages;

    public class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            Storage storage;

            switch (type)
            {
                case nameof(AutomatedWarehouse):
                    storage = new AutomatedWarehouse(name);
                    break;
                case nameof(DistributionCenter):
                    storage = new DistributionCenter(name);
                    break;
                case nameof(Warehouse):
                    storage = new Warehouse(name);
                    break;
                default:
                    throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}