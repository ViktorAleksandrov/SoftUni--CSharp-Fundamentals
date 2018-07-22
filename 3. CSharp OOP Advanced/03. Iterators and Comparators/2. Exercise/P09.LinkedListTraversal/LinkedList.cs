using System.Collections;
using System.Collections.Generic;

namespace P09.LinkedListTraversal
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node head;

        public LinkedList()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new Node(item);
            }
            else
            {
                this.head.AddNextNode(item);
            }

            this.Count++;
        }

        public bool Remove(T item)
        {
            if (this.head == null)
            {
                return false;
            }

            Node currentNode = this.head;
            Node previousNode = null;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                    }
                    else
                    {
                        this.head = this.head.Next;
                    }

                    this.Count--;
                    return true;
                }

                previousNode = currentNode;
                currentNode = currentNode.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = this.head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; }

            public Node Next { get; set; }

            public void AddNextNode(T value)
            {
                if (this.Next == null)
                {
                    this.Next = new Node(value);
                }
                else
                {
                    this.Next.AddNextNode(value);
                }
            }
        }
    }
}
