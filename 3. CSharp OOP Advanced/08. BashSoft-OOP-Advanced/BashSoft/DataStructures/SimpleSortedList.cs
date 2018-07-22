namespace BashSoft.DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Contracts;

    public class SimpleSortedList<T> : ISimpleOrderedBag<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 16;

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparison, int capacity)
        {
            this.comparison = comparison;

            this.InitializeInnerCollection(capacity);
        }

        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparison)
            : this(comparison, DefaultSize)
        {
        }

        public SimpleSortedList()
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Size
        {
            get { return this.size; }
        }

        public int Capacity
        {
            get { return this.innerCollection.Length; }
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (this.innerCollection.Length == this.size)
            {
                this.Resize();
            }

            this.innerCollection[this.size] = element;

            this.size++;

            this.Quicksort(this.innerCollection, 0, this.size - 1);
        }

        private void Resize()
        {
            var newCollection = new T[this.Size * 2];

            Array.Copy(this.innerCollection, newCollection, this.Size);

            this.innerCollection = newCollection;
        }

        private void Quicksort(T[] elements, int start, int end)
        {
            int i = start;
            int j = end;
            T pivot = elements[(start + end) / 2];

            while (i <= j)
            {
                while (this.comparison.Compare(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (this.comparison.Compare(elements[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    T temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;

                    i++;
                    j--;
                }
            }

            if (start < j)
            {
                Quicksort(elements, start, j);
            }

            if (i < end)
            {
                Quicksort(elements, i, end);
            }
        }

        public void AddAll(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + collection.Count > this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (T element in collection)
            {
                this.innerCollection[this.size] = element;

                this.size++;
            }

            this.Quicksort(this.innerCollection, 0, this.size - 1);
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            var newCollection = new T[newSize];

            Array.Copy(this.innerCollection, newCollection, this.size);

            this.innerCollection = newCollection;
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }

            var builder = new StringBuilder();

            foreach (T element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            builder.Remove(builder.Length - joiner.Length, joiner.Length);

            return builder.ToString();
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;

            for (int i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;

                    this.innerCollection[i] = default(T);

                    hasBeenRemoved = true;
                    break;
                }
            }

            if (hasBeenRemoved)
            {
                for (int i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.Size - 1] = default(T);
                this.size--;
            }

            return hasBeenRemoved;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
