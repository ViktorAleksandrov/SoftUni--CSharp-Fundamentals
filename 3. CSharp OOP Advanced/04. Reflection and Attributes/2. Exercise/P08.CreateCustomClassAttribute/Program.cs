using System;
using System.Reflection;

namespace P08.CreateCustomClassAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomAttribute attribute = typeof(Weapon).GetCustomAttribute<CustomAttribute>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"{command}: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"{command}: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class {command.ToLower()}: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"{command}: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }
            }
        }
    }
}
