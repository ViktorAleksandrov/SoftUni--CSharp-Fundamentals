using System.Collections.Generic;
using System.Text;

public class Person
{
    public Person(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public string Name { get; set; }
    public string Birthdate { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"{Name} {Birthdate}");

        result.AppendLine("Parents:");
        Parents.ForEach(p => result.AppendLine($"{p.Name} {p.Birthdate}"));

        result.AppendLine("Children:");
        Children.ForEach(c => result.AppendLine($"{c.Name} {c.Birthdate}"));

        return result.ToString();
    }
}