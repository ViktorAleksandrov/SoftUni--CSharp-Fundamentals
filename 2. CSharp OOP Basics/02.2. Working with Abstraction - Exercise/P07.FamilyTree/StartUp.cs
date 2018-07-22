namespace P07.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var relations = new List<string>();
            var persons = new List<Person>();

            var personArgument = Console.ReadLine();

            FillCollections(relations, persons);

            var person = persons
                .First(p => p.Name == personArgument || p.Birthdate == personArgument);

            AddRelativesToPerson(relations, persons, person);

            Console.Write(person);
        }

        private static void FillCollections(List<string> relations, List<Person> persons)
        {
            while (true)
            {
                var line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                if (line.Contains(" - "))
                {
                    relations.Add(line);
                }
                else
                {
                    var lineTokens = line.Split();

                    var name = $"{lineTokens[0]} {lineTokens[1]}";
                    var birthdate = lineTokens[2];

                    persons.Add(new Person(name, birthdate));
                }
            }
        }

        private static void AddRelativesToPerson(List<string> relations, List<Person> persons, Person person)
        {
            foreach (var relation in relations)
            {
                if (relation.Contains(person.Name) == false && relation.Contains(person.Birthdate) == false)
                {
                    continue;
                }

                var relationTokens = relation.Split(" - ");

                var parentArgument = relationTokens[0];
                var childArgument = relationTokens[1];

                if (parentArgument == person.Name || parentArgument == person.Birthdate)
                {
                    person.Children.Add(persons.First(p => p.Name == childArgument || p.Birthdate == childArgument));
                }
                else if (childArgument == person.Name || childArgument == person.Birthdate)
                {
                    person.Parents.Add(persons.First(p => p.Name == parentArgument || p.Birthdate == parentArgument));
                }
            }
        }
    }
}