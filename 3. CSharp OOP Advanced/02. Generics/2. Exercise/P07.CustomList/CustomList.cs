using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.CustomList
{
    public class CustomList<T>
        where T : IComparable<T>
    {
        private readonly List<T> data;

        public CustomList()
        {
            this.data = new List<T>();
        }

        public void Add(T element)
        {
            this.data.Add(element);
        }

        public T Remove(int index)
        {
            T element = this.data[index];

            this.data.RemoveAt(index);

            return element;
        }

        public bool Contains(T element)
        {
            return this.data.Contains(element);
        }

        public void Swap(int index1, int index2)
        {
            T temp = this.data[index1];
            this.data[index1] = this.data[index2];
            this.data[index2] = temp;
        }

        public int CountGreaterThan(T element)
        {
            int count = this.data.Count(e => e.CompareTo(element) > 0);

            return count;
        }

        public T Max()
        {
            return this.data.Max();
        }

        public T Min()
        {
            return this.data.Min();
        }

        public void Print()
        {
            this.data.ForEach(e => Console.WriteLine(e));
        }
    }
}