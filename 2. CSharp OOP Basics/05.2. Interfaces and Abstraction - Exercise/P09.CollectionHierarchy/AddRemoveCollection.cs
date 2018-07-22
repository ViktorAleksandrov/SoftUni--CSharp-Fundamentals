public class AddRemoveCollection : AddCollection, IRemovable
{
    public AddRemoveCollection() : base()
    {
    }

    public override int Add(string element)
    {
        collection.Insert(0, element);

        return 0;
    }

    public virtual string Remove()
    {
        var lastIndex = collection.Count - 1;

        var lastElement = collection[lastIndex];

        collection.RemoveAt(lastIndex);

        return lastElement;
    }
}