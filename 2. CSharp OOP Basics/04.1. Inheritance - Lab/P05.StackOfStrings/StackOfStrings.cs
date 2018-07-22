using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        data = new List<string>();
    }

    public void Push(string element)
    {
        data.Add(element);
    }

    public string Pop()
    {
        var element = data.Last();

        data.Remove(element);

        return element;
    }

    public string Peek()
    {
        return data.Last();
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}