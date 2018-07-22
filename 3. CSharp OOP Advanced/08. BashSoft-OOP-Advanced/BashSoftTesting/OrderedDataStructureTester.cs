namespace BashSoftTesting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using BashSoft.Contracts;
    using BashSoft.DataStructures;

    public class OrderedDataStructureTester
    {
        private const int DefaultCapacity = 16;
        private const int EmptyListSize = 0;

        private ISimpleOrderedBag<string> names;

        [SetUp]
        public void InitializeSimpleSortedList()
        {
            this.names = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            Assert.AreEqual(this.names.Capacity, DefaultCapacity);
            Assert.AreEqual(this.names.Size, EmptyListSize);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);

            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, EmptyListSize);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, EmptyListSize);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(this.names.Capacity, DefaultCapacity);
            Assert.AreEqual(this.names.Size, EmptyListSize);
        }

        [Test]
        public void TestCtorWithComparerDescending()
        {
            var comparator = Comparer<string>.Create((x, y) => y.CompareTo(x));

            this.names = new SimpleSortedList<string>(comparator)
            {
                "Balkan",
                "Georgi",
                "Rosen"
            };

            string actualResult = string.Join(',', this.names);
            string expectedResult = "Rosen,Georgi,Balkan";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Pesho");

            Assert.AreEqual(1, this.names.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Georgi");
            this.names.Add("Balkan");

            string[] testNames = new[] { "Balkan", "Georgi", "Rosen" };

            int index = 0;

            foreach (string name in this.names)
            {
                Assert.That(name, Is.EqualTo(testNames[index]));
                index++;
            }
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            int elementsCount = 17;

            for (int counter = 0; counter < elementsCount; counter++)
            {
                this.names.Add(counter.ToString());
            }

            Assert.That(this.names.Size, Is.EqualTo(elementsCount));
            Assert.That(this.names.Capacity, Is.Not.EqualTo(DefaultCapacity));
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var testNames = new List<string> { "Pesho", "Gosho" };

            this.names.AddAll(testNames);

            Assert.That(this.names.Size, Is.EqualTo(testNames.Count));
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            var testStrings = new List<string> { "SoftUni", "Pesho", "Gosho" };

            this.names.AddAll(testStrings);

            var testSortedStrings = new List<string> { "Gosho", "Pesho", "SoftUni" };

            string actualResult = string.Join(',', this.names);
            string expectedResult = string.Join(',', testSortedStrings);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            this.names.Add("Pesho");
            this.names.Remove("Pesho");

            Assert.That(this.names.Size, Is.EqualTo(EmptyListSize));
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            this.names.Add("Ivan");
            this.names.Add("Pesho");

            this.names.Remove("Ivan");

            Assert.That(this.names.FirstOrDefault(n => n == "Ivan"), Is.EqualTo(null));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            this.names.Add("Pesho");
            this.names.Add("Gosho");

            Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            this.names.Add("Pesho");
            this.names.Add("Gosho");

            string actualResult = this.names.JoinWith(", ");
            string expectedResult = "Gosho, Pesho";

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
