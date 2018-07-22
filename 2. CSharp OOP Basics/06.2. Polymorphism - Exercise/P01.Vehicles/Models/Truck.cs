namespace P01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double OverConsumption = 1.6;
        private const double FuelLossMultiplier = 0.95;

        public Truck(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + OverConsumption)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * FuelLossMultiplier);
        }
    }
}