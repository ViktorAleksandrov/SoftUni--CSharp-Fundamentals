namespace P02.VehiclesExtension
{
    using System;

    public class Truck : Vehicle
    {
        private const double OverConsumption = 1.6;
        private const double FuelLossMultiplier = 0.95;

        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + OverConsumption, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            try
            {
                base.Refuel(liters * FuelLossMultiplier);
            }
            catch (ArgumentException)
            {
                base.Refuel(liters);
            }
        }
    }
}