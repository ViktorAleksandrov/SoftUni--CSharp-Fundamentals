public class MyList : AddRemoveCollection, ICountable
{
    public MyList() : base()
    {
    }

    public int Used => collection.Count;

    public override string Remove()
    {
        var firstElement = collection[0];

        collection.RemoveAt(0);

        return firstElement;
    }
}