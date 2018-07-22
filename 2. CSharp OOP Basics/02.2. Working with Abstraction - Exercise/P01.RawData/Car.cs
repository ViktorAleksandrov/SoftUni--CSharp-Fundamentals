using System.Collections.Generic;

public class Car
{
    public Car(string[] carArgs)
    {
        var model = carArgs[0];
        var engineSpeed = carArgs[1];
        var enginePower = int.Parse(carArgs[2]);
        var cargoWeight = carArgs[3];
        var cargoType = carArgs[4];
        var tire1Pressure = double.Parse(carArgs[5]);
        var tire1Age = carArgs[6];
        var tire2Pressure = double.Parse(carArgs[7]);
        var tire2Age = carArgs[8];
        var tire3Pressure = double.Parse(carArgs[9]);
        var tire3Age = carArgs[10];
        var tire4Pressure = double.Parse(carArgs[11]);
        var tire4Age = carArgs[12];

        Model = model;
        Engine = new Engine(engineSpeed, enginePower);
        Cargo = new Cargo(cargoWeight, cargoType);
        Tires = new List<Tire>
        {
            new Tire(tire1Pressure, tire1Age),
            new Tire(tire2Pressure, tire2Age),
            new Tire(tire3Pressure, tire3Age),
            new Tire(tire4Pressure, tire4Age)
        };
    }

    public string Model { get; set; }

    public Engine Engine { get; set; }

    public Cargo Cargo { get; set; }

    public List<Tire> Tires { get; set; }
}