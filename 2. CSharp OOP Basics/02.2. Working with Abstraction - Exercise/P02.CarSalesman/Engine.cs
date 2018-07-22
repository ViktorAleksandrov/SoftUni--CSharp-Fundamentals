using System.Text;

public class Engine
{
    public Engine(string model, string power) : this(model, power, -1, "n/a")
    {
    }

    public Engine(string model, string power, int displacement) : this(model, power, displacement, "n/a")
    {
    }

    public Engine(string model, string power, string efficiency) : this(model, power, -1, efficiency)
    {
    }

    public Engine(string model, string power, int displacement, string efficiency)
    {
        Model = model;
        Power = power;
        Displacement = displacement;
        Efficiency = efficiency;
    }

    public string Model { get; set; }
    public string Power { get; set; }
    public int Displacement { get; set; }
    public string Efficiency { get; set; }

    public override string ToString()
    {
        var displacement = Displacement == -1 ? "n/a" : Displacement.ToString();

        return new StringBuilder()
            .AppendLine($"  {Model}:")
            .AppendLine($"    Power: {Power}")
            .AppendLine($"    Displacement: {displacement}")
            .AppendLine($"    Efficiency: {Efficiency}")
            .ToString()
            .TrimEnd();
    }
}