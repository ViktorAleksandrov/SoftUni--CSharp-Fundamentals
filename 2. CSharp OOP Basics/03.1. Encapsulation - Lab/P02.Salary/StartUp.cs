namespace P02.Salary
{
    using System;
    using System.Collections.Generic;

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
                var salary = decimal.Parse(personArgs[3]);

                var person = new Person(firstName, lastName, age, salary);

                persons.Add(person);
            }

            var bonus = decimal.Parse(Console.ReadLine());

            persons.ForEach(p => p.IncreaseSalary(bonus));

            persons.ForEach(Console.WriteLine);
        }
    }
}