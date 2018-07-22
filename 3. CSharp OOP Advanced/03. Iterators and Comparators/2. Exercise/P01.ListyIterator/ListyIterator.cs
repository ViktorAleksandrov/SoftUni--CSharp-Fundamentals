using System;
using System.Collections.Generic;

namespace P01.ListyIterator
{
    public class ListyIterator<T>
    {
        private readonly List<T> elements;
        private int currentIndex;

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return this.currentIndex + 1 < this.elements.Count;
        }

        public void Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[this.currentIndex]);
        }
    }
}
