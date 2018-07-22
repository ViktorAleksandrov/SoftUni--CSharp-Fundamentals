using System;
using NUnit.Framework;
using P02.ExtendedDatabase;

namespace P02.ExtendedDatabaseTests
{
    public class ExtendedDatabaseTests
    {
        private const long TestPersonId = 1;
        private const string TestPersonUsername = "Pesho";
        private const string TestPersonLowercaseUsername = "pesho";
        private const int NonexistingId = 2;
        private const string NonexistingUsername = "Gosho";
        private const long NegativeId = -1;
        private const int ExpectedDatabaseCount = 1;

        private Database database;
        private Person testPerson;

        [SetUp]
        public void DatabaseInit()
        {
            this.testPerson = new Person(TestPersonId, TestPersonUsername);

            this.database = new Database(this.testPerson, null);
        }

        [Test]
        public void ConstructorWithNullParameter()
        {
            Assert.DoesNotThrow(() => new Database(null));
        }

        [Test]
        public void InitializePersonsByConstructor()
        {
            Assert.That(this.database.Count, Is.EqualTo(ExpectedDatabaseCount));
        }

        [Test]
        public void AddValidPerson()
        {
            var otherPerson = new Person(NonexistingId, NonexistingUsername);

            this.database.Add(otherPerson);

            Assert.That(otherPerson, Is.EqualTo(this.database.PeopleById[otherPerson.Id]));
        }

        [Test]
        public void AddPersonWithSameUsernameOrId()
        {
            Assert.That(() => this.database.Add(new Person(NonexistingId, TestPersonUsername)),
                Throws.InvalidOperationException);

            Assert.That(() => this.database.Add(new Person(TestPersonId, NonexistingUsername)),
                Throws.InvalidOperationException);
        }

        [Test]
        public void RemoveExistingPerson()
        {
            this.database.Remove(this.testPerson);

            Assert.That(!this.database.PeopleById.ContainsKey(TestPersonId));
        }

        [Test]
        public void RemoveNonexistingPerson()
        {
            int dbCountBeforeRemove = this.database.Count;

            var otherPerson = new Person(NonexistingId, NonexistingUsername);
            this.database.Remove(otherPerson);

            int dbCountAfterRemove = this.database.Count;

            Assert.That(dbCountBeforeRemove, Is.EqualTo(dbCountAfterRemove));
        }

        [Test]
        public void FindByUsernameValid()
        {
            Person foundPerson = this.database.FindByUsername(TestPersonUsername);

            Assert.That(foundPerson, Is.EqualTo(this.testPerson));
        }

        [Test]
        public void FindByUsernameNonexistingUsername()
        {
            Assert.That(() => this.database.FindByUsername(TestPersonLowercaseUsername), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByUsernameNullUsernameParameter()
        {
            Assert.That(() => this.database.FindByUsername(null), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByIdValid()
        {
            Person foundPerson = this.database.FindById(TestPersonId);

            Assert.That(foundPerson, Is.EqualTo(this.testPerson));
        }

        [Test]
        public void FindByIdPersonIdDoesntExist()
        {
            Assert.That(() => this.database.FindById(NonexistingId), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdNegativeIdParameter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.database.FindById(NegativeId));
        }
    }
}
