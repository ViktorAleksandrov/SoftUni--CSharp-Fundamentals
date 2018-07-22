using System;

public class DriverFactory
{
    public Driver CreateDriver(string driverType, string driverName, Car car)
    {
        switch (driverType)
        {
            case "Aggressive":
                return new AggressiveDriver(driverName, car);
            case "Endurance":
                return new EnduranceDriver(driverName, car);
            default:
                throw new ArgumentException();
        }
    }
}