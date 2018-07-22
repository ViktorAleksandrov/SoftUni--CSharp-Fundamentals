using System;
using System.Collections.Generic;
using System.Linq;

public class Database
{
    private const int Capacity = 16;

    private readonly int[] elements;
    private int currentIndex;

    public Database(params int[] inputNumbers)
    {
        this.elements = new int[Capacity];
        this.currentIndex = 0;
        this.InitializeInputNumbers(inputNumbers);
    }

    public IReadOnlyList<int> Elements => this.elements;

    private void InitializeInputNumbers(int[] inputNumbers)
    {
        if (inputNumbers.Length > Capacity)
        {
            throw new InvalidOperationException();
        }

        Array.Copy(inputNumbers, this.elements, inputNumbers.Length);

        this.currentIndex = inputNumbers.Length;
    }

    public void Add(int number)
    {
        if (this.currentIndex == Capacity)
        {
            throw new InvalidOperationException();
        }

        this.elements[this.currentIndex] = number;
        this.currentIndex++;
    }

    public void Remove()
    {
        if (this.currentIndex == 0)
        {
            throw new InvalidOperationException();
        }

        this.currentIndex--;

        this.elements[this.currentIndex] = default(int);
    }

    public int[] Fetch()
    {
        int[] fetchedNumbers = this.elements.Take(this.currentIndex).ToArray();

        return fetchedNumbers;
    }
}
