using System;

public class Car
{
    private const double MaxFuel = 160.0;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; }

    public double FuelAmount
    {
        get => this.fuelAmount;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, MaxFuel);
        }
    }

    public Tyre Tyre { get; private set; }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    public void ReduceFuel(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}