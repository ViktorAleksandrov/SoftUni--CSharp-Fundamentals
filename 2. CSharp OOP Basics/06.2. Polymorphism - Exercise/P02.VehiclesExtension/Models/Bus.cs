namespace P02.VehiclesExtension
{
    using System;

    public class Bus : Vehicle
    {
        private const double OverConsumption = 1.4;

        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            string result;

            double neededFuel = distance * (this.LitersPerKm + OverConsumption);

            if (neededFuel > this.FuelQuantity)
            {
                result = $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= neededFuel;

                result = $"{this.GetType().Name} travelled {distance} km";
            }

            Console.WriteLine(result);
        }

        public void DriveEmpty(double distance)
        {
            base.Drive(distance);
        }
    }
}