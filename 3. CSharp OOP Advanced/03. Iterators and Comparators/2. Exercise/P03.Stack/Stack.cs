using System;
using System.Collections;
using System.Collections.Generic;

namespace P03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly List<T> stack;

        public Stack()
        {
            this.stack = new List<T>();
        }

        public void Push(params T[] elements)
        {
            this.stack.AddRange(elements);
        }

        public void Pop()
        {
            if (this.stack.Count == 0)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                this.stack.RemoveAt(this.stack.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int count = 0; count < 2; count++)
            {
                for (int index = this.stack.Count - 1; index >= 0; index--)
                {
                    yield return this.stack[index];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
