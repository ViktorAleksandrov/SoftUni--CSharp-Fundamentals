public abstract class Machine
{
    protected Machine(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }

    public abstract string Type { get; }
}