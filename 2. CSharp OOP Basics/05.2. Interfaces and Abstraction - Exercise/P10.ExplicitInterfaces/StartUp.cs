namespace P10.ExplicitInterfaces
{
    using System;

    class StartUp
    {
        static void Main()
        {
            while (true)
            {
                var citizenInfo = Console.ReadLine().Split();

                var name = citizenInfo[0];

                if (name == "End")
                {
                    break;
                }

                var country = citizenInfo[1];
                var age = int.Parse(citizenInfo[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}