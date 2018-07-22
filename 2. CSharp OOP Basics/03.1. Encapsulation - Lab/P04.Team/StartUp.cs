using System;

class StartUp
{
    static void Main()
    {
        var personsCount = int.Parse(Console.ReadLine());

        var team = new Team("SoftUni");

        for (int counter = 0; counter < personsCount; counter++)
        {
            var personArgs = Console.ReadLine().Split();

            var firstName = personArgs[0];
            var lastName = personArgs[1];
            var age = int.Parse(personArgs[2]);
            var salary = decimal.Parse(personArgs[3]);

            try
            {
                var person = new Person(firstName, lastName, age, salary);

                team.AddPlayer(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        Console.WriteLine(team);
    }
}