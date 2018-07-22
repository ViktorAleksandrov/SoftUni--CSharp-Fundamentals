namespace P04.OpinionPoll
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

            for (int i = 0; i < personsCount; i++)
            {
                var personArgs = Console.ReadLine().Split();

                var age = int.Parse(personArgs[1]);

                if (age > 30)
                {
                    var name = personArgs[0];

                    persons.Add(new Person(name, age));
                }
            }

            foreach (var person in persons.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}