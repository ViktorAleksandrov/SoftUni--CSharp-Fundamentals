namespace P01.Vehicles
{
    using System;

    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm)
        {
            this.FuelQuantity = fuelQuantity;
            this.LitersPerKm = litersPerKm;
        }

        protected double FuelQuantity { get; set; }

        protected double LitersPerKm { get; set; }

        public void Drive(double distance)
        {
            string result;

            double neededFuel = distance * this.LitersPerKm;

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

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}