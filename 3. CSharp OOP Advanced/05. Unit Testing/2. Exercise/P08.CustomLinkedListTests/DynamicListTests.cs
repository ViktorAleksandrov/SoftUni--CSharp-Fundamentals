using System;
using NUnit.Framework;
using P08.CustomLinkedList;

namespace P08.CustomLinkedListTests
{
    public class DynamicListTests
    {
        private const int TestElement1 = 1;
        private const int TestElement2 = 2;

        private DynamicList<int> dynamicList;

        [SetUp]
        public void DynamicListInit()
        {
            this.dynamicList = new DynamicList<int>();
            this.dynamicList.Add(TestElement1);
        }

        [Test]
        [TestCase(0)]
        public void NewDynamicListCountIsZero(int expectedCount)
        {
            this.dynamicList = new DynamicList<int>();

            Assert.That(this.dynamicList.Count, Is.EqualTo(expectedCount), "Count is not 0");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void GetElementAtInvalidIndex(int index)
        {
            Assert.That(() => this.dynamicList[index], Throws.InstanceOf<ArgumentOutOfRangeException>(),
                "Getting element at invalid index doesn't throw correct exception");
        }

        [Test]
        [TestCase(0)]
        public void GetElementAtIndex(int index)
        {
            Assert.That(this.dynamicList[index], Is.EqualTo(TestElement1), "Indexator doesn't return correct element");
        }

        [Test]
        [TestCase(0)]
        public void SetElementAtIndex(int index)
        {
            this.dynamicList[index] = TestElement2;

            Assert.That(this.dynamicList[index], Is.EqualTo(TestElement2), "Indexator doesn't set element at correct index");
        }

        [Test]
        [TestCase(2)]
        public void AddElementIncreaseCount(int expectedCount)
        {
            this.dynamicList.Add(TestElement2);

            Assert.That(this.dynamicList.Count, Is.EqualTo(expectedCount),
                "Adding an element doesn't increase the collection's count");
        }

        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void RemoveElementAtInvalidIndex(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.dynamicList.RemoveAt(index),
                "Removing element at invalid index doesn't throw correct exception");
        }

        [Test]
        [TestCase(0)]
        public void RemovetAtIndexReturnCorrectElement(int index)
        {
            Assert.That(() => this.dynamicList.RemoveAt(index), Is.EqualTo(TestElement1), "Removed element is not correct");
        }

        [Test]
        [TestCase(-1)]
        public void RemoveNonexistingElement(int index)
        {
            Assert.That(() => this.dynamicList.Remove(TestElement2), Is.EqualTo(index), "Returned index is not -1");
        }

        [Test]
        [TestCase(0)]
        public void RemoveExistingElement(int index)
        {
            Assert.That(() => this.dynamicList.Remove(TestElement1), Is.EqualTo(index), "Returned index is not correct");
        }

        [Test]
        [TestCase(-1)]
        public void GetIndexOfNonexistingElement(int index)
        {
            Assert.That(() => this.dynamicList.IndexOf(TestElement2), Is.EqualTo(index), "Returned index is not -1");
        }

        [Test]
        [TestCase(0)]
        public void GetIndexOfExistingElement(int index)
        {
            Assert.That(() => this.dynamicList.Remove(TestElement1), Is.EqualTo(index), "Returned index is not correct");
        }

        [Test]
        public void ContainsElementReturnTrueIfElementExists()
        {
            Assert.That(() => this.dynamicList.Contains(TestElement1), Is.EqualTo(true),
                "Contains returns false for existing element");
        }

        [Test]
        public void ContainsElementReturnFalseIfElementDoesntExist()
        {
            Assert.That(() => this.dynamicList.Contains(TestElement2), Is.EqualTo(false),
                "Contains returns true for element, which doesn't exists");
        }
    }
}
