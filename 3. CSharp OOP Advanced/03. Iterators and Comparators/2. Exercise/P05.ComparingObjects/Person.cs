using System;

namespace P05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }

        public int CompareTo(Person other)
        {
            int comparisonResult = this.Name.CompareTo(other.Name);

            if (comparisonResult == 0)
            {
                comparisonResult = this.Age.CompareTo(other.Age);

                if (comparisonResult == 0)
                {
                    comparisonResult = this.Town.CompareTo(other.Town);
                }
            }

            return comparisonResult;
        }
    }
}
