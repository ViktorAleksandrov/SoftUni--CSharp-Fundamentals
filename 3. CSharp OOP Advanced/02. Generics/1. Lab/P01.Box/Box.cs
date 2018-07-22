using System.Collections.Generic;

public class Box<T>
{
    private readonly Stack<T> data;

    public Box()
    {
        this.data = new Stack<T>();
    }

    public int Count => this.data.Count;

    public void Add(T element)
    {
        this.data.Push(element);
    }

    public T Remove()
    {
        T lastElement = this.data.Pop();

        return lastElement;
    }
}