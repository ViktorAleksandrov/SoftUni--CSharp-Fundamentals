namespace P01.Vehicles
{
    public class Car : Vehicle
    {
        private const double OverConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKm)
            : base(fuelQuantity, litersPerKm + OverConsumption)
        {
        }
    }
}