using System;
using System.Collections.Generic;

namespace P07.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            var sortedSet = new SortedSet<Person>();
            var hashSet = new HashSet<Person>();

            int personsCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < personsCount; counter++)
            {
                string[] personArgs = Console.ReadLine().Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);

                var person = new Person(name, age);

                sortedSet.Add(person);
                hashSet.Add(person);
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
