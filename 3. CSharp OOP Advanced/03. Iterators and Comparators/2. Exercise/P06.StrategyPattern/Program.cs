using System;
using System.Collections.Generic;
using P06.StrategyPattern.Comparators;

namespace P06.StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var nameSortedPersons = new SortedSet<Person>(new NameComparator());
            var ageSortedPersons = new SortedSet<Person>(new AgeComparator());

            int personsCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < personsCount; counter++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                var person = new Person(name, age);

                nameSortedPersons.Add(person);
                ageSortedPersons.Add(person);
            }

            Console.WriteLine(string.Join(Environment.NewLine, nameSortedPersons));
            Console.WriteLine(string.Join(Environment.NewLine, ageSortedPersons));
        }
    }
}
