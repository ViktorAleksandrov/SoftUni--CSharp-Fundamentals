namespace P02.VehiclesExtension
{
    using System;

    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        protected double FuelQuantity { get; set; }

        protected double LitersPerKm { get; set; }

        protected double TankCapacity { get; set; }

        public virtual void Drive(double distance)
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
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.FuelQuantity + liters > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}