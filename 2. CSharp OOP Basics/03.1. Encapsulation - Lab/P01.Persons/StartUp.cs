namespace P01.Persons
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var personsCount = int.Parse(Console.ReadLine());

            var persons = new List<Person>();

            for (int counter = 0; counter < personsCount; counter++)
            {
                var personArgs = Console.ReadLine().Split();

                var firstName = personArgs[0];
                var lastName = personArgs[1];
                var age = int.Parse(personArgs[2]);

                var person = new Person(firstName, lastName, age);

                persons.Add(person);
            }

            persons.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}