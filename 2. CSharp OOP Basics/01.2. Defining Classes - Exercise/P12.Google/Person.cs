using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
        Parents = new List<Parent>();
        Children = new List<Child>();
    }

    public string Name { get; set; }
    public Company TheCompany { get; set; }
    public Car TheCar { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine(Name);

        result.AppendLine("Company:");
        if (TheCompany != null)
        {
            result.AppendLine(TheCompany.ToString());
        }

        result.AppendLine("Car:");
        if (TheCar != null)
        {
            result.AppendLine(TheCar.ToString());
        }

        result.AppendLine("Pokemon:");
        Pokemons.ForEach(p => result.AppendLine(p.ToString()));

        result.AppendLine("Parents:");
        Parents.ForEach(p => result.AppendLine(p.ToString()));

        result.AppendLine("Children:");
        Children.ForEach(c => result.AppendLine(c.ToString()));

        return result.ToString();
    }

    public class Company
    {
        public Company(string name, string department, decimal salary)
        {
            Name = name;
            Department = department;
            Salary = salary;
        }

        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name} {Department} {Salary:F2}";
        }
    }

    public class Car
    {
        public Car(string model, string speed)
        {
            Model = model;
            Speed = speed;
        }

        public string Model { get; set; }
        public string Speed { get; set; }

        public override string ToString()
        {
            return $"{Model} {Speed}";
        }
    }

    public class Pokemon
    {
        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"{Name} {Type}";
        }
    }

    public class Parent
    {
        public Parent(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }

    public class Child
    {
        public Child(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }

        public override string ToString()
        {
            return $"{Name} {Birthday}";
        }
    }
}