using System;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int batteries)
    {
        Model = model;
        Color = color;
        Batteries = batteries;
    }

    public string Model { get; }

    public string Color { get; }

    public int Batteries { get; }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{Color} {GetType()} {Model} with {Batteries} Batteries" + Environment.NewLine
             + Start() + Environment.NewLine
             + Stop();
    }
}