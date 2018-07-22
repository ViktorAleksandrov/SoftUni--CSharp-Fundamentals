public class StreetExtraordinaire : Cat
{
    public StreetExtraordinaire(string name, string meowsDecibels) : base(name)
    {
        MeowsDecibels = meowsDecibels;
    }

    public string MeowsDecibels { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} {Name} {MeowsDecibels}";
    }
}