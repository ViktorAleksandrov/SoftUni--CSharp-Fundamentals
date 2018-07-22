using System;
using System.Collections.Generic;

namespace P03.Iterator
{
    public class ListIterator
    {
        private int currentIndex;
        private readonly List<string> elements;

        public ListIterator(IEnumerable<string> inputElements)
        {
            ValidateInputElements(inputElements);

            this.currentIndex = 0;
            this.elements = new List<string>(inputElements);
        }

        public int Count => this.elements.Count;

        private void ValidateInputElements(IEnumerable<string> inputElements)
        {
            if (inputElements == null)
            {
                throw new ArgumentNullException();
            }
        }

        public bool Move()
        {
            if (HasNext())
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

        public string Print()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.elements[this.currentIndex];
        }
    }
}
