using System;
using System.Collections.Generic;

public class RandomList : List<string>
{
    private Random random;

    public RandomList()
    {
        random = new Random();
    }

    public string RandomString()
    {
        var index = random.Next(Count);

        var element = this[index];

        RemoveAt(index);

        return element;
    }
}