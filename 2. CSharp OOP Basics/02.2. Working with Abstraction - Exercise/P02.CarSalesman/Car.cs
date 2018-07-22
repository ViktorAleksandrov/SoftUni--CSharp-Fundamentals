using System.Text;

public class Car
{
    public Car(string model, Engine engine) : this(model, engine, -1, "n/a")
    {
    }

    public Car(string model, Engine engine, int weight) : this(model, engine, weight, "n/a")
    {
    }

    public Car(string model, Engine engine, string color) : this(model, engine, -1, color)
    {
    }

    public Car(string model, Engine engine, int weight, string color)
    {
        Model = model;
        Engine = engine;
        Weight = weight;
        Color = color;
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        var weight = Weight == -1 ? "n/a" : Weight.ToString();

        return new StringBuilder()
            .AppendLine($"{Model}:")
            .AppendLine($"{Engine}")
            .AppendLine($"  Weight: {weight}")
            .AppendLine($"  Color: {Color}")
            .ToString()
            .TrimEnd();
    }
}