public class Siamese : Cat
{
    public Siamese(string name, string earSize) : base(name)
    {
        EarSize = earSize;
    }

    public string EarSize { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} {Name} {EarSize}";
    }
}