namespace P02.VehiclesExtension
{
    public class Car : Vehicle
    {
        private const double OverConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm + OverConsumption, tankCapacity)
        {
        }
    }
}