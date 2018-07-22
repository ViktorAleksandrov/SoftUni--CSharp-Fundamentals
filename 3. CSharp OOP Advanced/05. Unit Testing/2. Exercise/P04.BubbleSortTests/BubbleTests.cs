using NUnit.Framework;
using P04.BubbleSort;

namespace P04.BubbleSortTests
{
    public class BubbleTests
    {
        [Test]
        public void SortCollection()
        {
            int[] numbersToSort = { int.MaxValue, int.MinValue, 0, 1, -1 };

            var bubble = new Bubble();
            bubble.Sort(numbersToSort);

            int[] expectedSortedNumbers = { int.MinValue, -1, 0, 1, int.MaxValue };

            Assert.That(numbersToSort, Is.EquivalentTo(expectedSortedNumbers));
        }
    }
}
