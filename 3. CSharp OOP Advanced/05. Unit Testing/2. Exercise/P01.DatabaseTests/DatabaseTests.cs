using System.Linq;
using NUnit.Framework;

namespace P01.DatabaseTests
{
    public class DatabaseTests
    {
        private const int Capacity = 16;
        private const int TestNumber = 1;

        private Database database;

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 0 })]
        [TestCase(new int[] { int.MinValue, int.MaxValue })]
        public void InitializeInputNumbersByConstructor(int[] numbers)
        {
            this.database = new Database(numbers);

            int[] dbElements = this.database.Elements.Take(numbers.Length).ToArray();

            Assert.That(dbElements, Is.EquivalentTo(numbers));
        }

        [Test]
        public void CountOfInputNumbersExceedCapacity()
        {
            int[] numbers = new int[Capacity + 1];

            Assert.That(() => new Database(numbers), Throws.InvalidOperationException);
        }

        [Test]
        public void AddElement()
        {
            this.database = new Database();

            this.database.Add(TestNumber);

            int firstDbElement = this.database.Elements.First();

            Assert.That(firstDbElement, Is.EqualTo(TestNumber));
        }

        [Test]
        public void AddElementToFullDatabase()
        {
            int[] numbers = new int[Capacity];

            this.database = new Database(numbers);

            Assert.That(() => this.database.Add(TestNumber), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new[] { int.MinValue, TestNumber, int.MaxValue })]
        public void RemoveElement(int[] numbers)
        {
            this.database = new Database(numbers);

            this.database.Remove();

            numbers = numbers.Take(numbers.Length - 1).ToArray();

            int[] dbElements = this.database.Elements.Take(numbers.Length).ToArray();

            Assert.That(dbElements, Is.EquivalentTo(numbers));
        }

        [Test]
        public void RemoveElementFromEmptyDatabase()
        {
            this.database = new Database();

            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(new[] { int.MinValue, TestNumber, int.MaxValue })]
        public void Fetch(int[] numbers)
        {
            this.database = new Database(numbers);

            int[] fetchedNumbers = this.database.Fetch();

            int[] dbElements = this.database.Elements.Take(numbers.Length).ToArray();

            Assert.That(fetchedNumbers, Is.EquivalentTo(dbElements));
        }
    }
}
