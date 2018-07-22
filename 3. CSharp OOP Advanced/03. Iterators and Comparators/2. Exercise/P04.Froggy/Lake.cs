using System.Collections;
using System.Collections.Generic;

namespace P04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private readonly IList<int> stones;

        public Lake(IList<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = 0; index < this.stones.Count; index += 2)
            {
                yield return this.stones[index];
            }

            int lastOddIndex = this.stones.Count - 1;

            if (lastOddIndex % 2 == 0)
            {
                lastOddIndex--;
            }

            for (int index = lastOddIndex; index > 0; index -= 2)
            {
                yield return this.stones[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
