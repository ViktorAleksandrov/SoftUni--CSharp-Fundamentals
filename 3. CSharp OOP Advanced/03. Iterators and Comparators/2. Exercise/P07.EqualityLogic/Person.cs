using System;

namespace P07.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int CompareTo(Person other)
        {
            int comparisonResult = this.Name.CompareTo(other.Name);

            if (comparisonResult == 0)
            {
                comparisonResult = this.Age.CompareTo(other.Age);
            }

            return comparisonResult;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Age == other.Age;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
