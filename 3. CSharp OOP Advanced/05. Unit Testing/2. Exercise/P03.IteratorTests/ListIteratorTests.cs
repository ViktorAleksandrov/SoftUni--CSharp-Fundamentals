using NUnit.Framework;
using P03.Iterator;

namespace P03.IteratorTests
{
    public class ListIteratorTests
    {
        private const int ExpectedCount = 2;
        private const string ExpectedElement = "1";

        private readonly string[] elements = new[] { "1", "2" };

        private ListIterator listIterator;

        [SetUp]
        public void ListIteratorInit()
        {
            this.listIterator = new ListIterator(this.elements);
        }

        [Test]
        public void ConstructorInitializeInputElements()
        {
            Assert.That(this.listIterator.Count, Is.EqualTo(ExpectedCount));
        }

        [Test]
        public void ConstructorWithNullArgument()
        {
            Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
        }

        [Test]
        public void MoveCurrentIndex()
        {
            Assert.That(this.listIterator.Move(), Is.EqualTo(true));
        }

        [Test]
        public void TryMoveCurrentIndexOutsideArrayBounds()
        {
            this.listIterator.Move();

            Assert.That(this.listIterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void HasNextIndex()
        {
            Assert.That(this.listIterator.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void HasNotNextIndex()
        {
            this.listIterator.Move();

            Assert.That(this.listIterator.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void PrintElement()
        {
            Assert.That(this.listIterator.Print(), Is.EqualTo(ExpectedElement));
        }

        [Test]
        public void PrintOnEmptyCollection()
        {
            this.listIterator = new ListIterator(new string[0]);

            Assert.That(() => this.listIterator.Print(),
                Throws.InvalidOperationException.With.Message.EqualTo("Invalid Operation!"));
        }
    }
}
