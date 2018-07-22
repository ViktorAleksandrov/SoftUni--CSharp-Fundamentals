using System.Collections.Generic;

public class AddCollection : IAddable
{
    protected List<string> collection;

    public AddCollection()
    {
        collection = new List<string>();
    }

    public virtual int Add(string element)
    {
        collection.Add(element);

        return collection.Count - 1;
    }
}