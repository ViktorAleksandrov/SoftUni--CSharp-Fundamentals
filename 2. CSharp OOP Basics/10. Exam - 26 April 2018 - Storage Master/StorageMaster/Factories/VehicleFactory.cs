namespace StorageMaster.Factories
{
    using System;
    using Entities.Vehicles;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string vehicleType)
        {
            Vehicle vehicle;

            switch (vehicleType)
            {
                case nameof(Semi):
                    vehicle = new Semi();
                    break;
                case nameof(Truck):
                    vehicle = new Truck();
                    break;
                case nameof(Van):
                    vehicle = new Van();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}