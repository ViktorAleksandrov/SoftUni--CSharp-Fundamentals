public class Cymric : Cat
{
    public Cymric(string name, string furLength) : base(name)
    {
        FurLength = furLength;
    }

    public string FurLength { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} {Name} {double.Parse(FurLength):F2}";
    }
}