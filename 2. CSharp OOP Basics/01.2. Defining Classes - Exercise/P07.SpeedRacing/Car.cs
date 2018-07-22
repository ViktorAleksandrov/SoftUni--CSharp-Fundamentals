using System;

public class Car
{
    public Car(string model, double fuelAmount, double consumptionPerKm)
    {
        Model = model;
        FuelAmount = fuelAmount;
        ConsumptionPerKm = consumptionPerKm;
        TraveledDistance = 0;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double ConsumptionPerKm { get; set; }
    public int TraveledDistance { get; set; }

    public void TryToMove(int distance)
    {
        var neededFuel = distance * ConsumptionPerKm;

        if (FuelAmount >= neededFuel)
        {
            FuelAmount -= neededFuel;
            TraveledDistance += distance;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:F2} {TraveledDistance}";
    }
}