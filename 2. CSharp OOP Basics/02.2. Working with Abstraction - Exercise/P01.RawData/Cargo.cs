public class Cargo
{
    public Cargo(string weight, string type)
    {
        Weight = weight;
        Type = type;
    }

    public string Weight { get; set; }

    public string Type { get; set; }
}