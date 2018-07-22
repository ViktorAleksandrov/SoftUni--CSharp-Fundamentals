namespace P12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var persons = new List<Person>();

            while (true)
            {
                var inputTokens = Console.ReadLine().Split();

                var personName = inputTokens[0];

                if (personName == "End")
                {
                    break;
                }

                var person = persons.FirstOrDefault(p => p.Name == personName);

                if (person == null)
                {
                    person = new Person(personName);

                    persons.Add(person);
                }

                AddCategory(inputTokens, person);
            }

            PrintPerson(persons);
        }

        private static void AddCategory(string[] inputTokens, Person person)
        {
            var category = inputTokens[1];

            switch (category)
            {
                case "company":
                    AddCompany(inputTokens, person);
                    break;
                case "car":
                    AddCar(inputTokens, person);
                    break;
                case "pokemon":
                    AddPokemon(inputTokens, person);
                    break;
                case "parents":
                    AddParent(inputTokens, person);
                    break;
                case "children":
                    AddChild(inputTokens, person);
                    break;
            }
        }

        private static void AddCompany(string[] inputTokens, Person person)
        {
            var name = inputTokens[2];
            var department = inputTokens[3];
            var salary = decimal.Parse(inputTokens[4]);

            var company = new Person.Company(name, department, salary);

            person.TheCompany = company;
        }

        private static void AddCar(string[] inputTokens, Person person)
        {
            var model = inputTokens[2];
            var speed = inputTokens[3];

            var car = new Person.Car(model, speed);

            person.TheCar = car;
        }

        private static void AddPokemon(string[] inputTokens, Person person)
        {
            var name = inputTokens[2];
            var type = inputTokens[3];

            var pokemon = new Person.Pokemon(name, type);

            person.Pokemons.Add(pokemon);
        }

        private static void AddParent(string[] inputTokens, Person person)
        {
            var name = inputTokens[2];
            var birthday = inputTokens[3];

            var parent = new Person.Parent(name, birthday);

            person.Parents.Add(parent);
        }

        private static void AddChild(string[] inputTokens, Person person)
        {
            var name = inputTokens[2];
            var birthday = inputTokens[3];

            var child = new Person.Child(name, birthday);

            person.Children.Add(child);
        }

        private static void PrintPerson(List<Person> persons)
        {
            var personName = Console.ReadLine();

            var person = persons.First(p => p.Name == personName);

            Console.Write(person);
        }
    }
}