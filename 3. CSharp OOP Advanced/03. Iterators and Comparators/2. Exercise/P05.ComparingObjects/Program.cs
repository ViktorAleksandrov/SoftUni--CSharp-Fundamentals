using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] personArgs = inputLine.Split();

                string name = personArgs[0];
                int age = int.Parse(personArgs[1]);
                string town = personArgs[2];

                var person = new Person(name, age, town);

                persons.Add(person);
            }

            int personIndex = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = persons[personIndex];

            int equalPeopleCount = persons.Count(p => p.CompareTo(personToCompare) == 0);

            if (equalPeopleCount > 1)
            {
                int notEqualPeopleCount = persons.Count - equalPeopleCount;

                Console.WriteLine($"{equalPeopleCount} {notEqualPeopleCount} {persons.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
