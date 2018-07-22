namespace P06.BirthdayCelebrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var inhabitants = new List<IBornable>();

            while (true)
            {
                var inhabitantInfo = Console.ReadLine().Split();

                if (inhabitantInfo[0] == "End")
                {
                    break;
                }

                AddInhabitant(inhabitants, inhabitantInfo);
            }

            PrintBirthdates(inhabitants);
        }

        private static void AddInhabitant(List<IBornable> inhabitants, string[] inhabitantInfo)
        {
            var type = inhabitantInfo[0];
            var name = inhabitantInfo[1];

            if (type == "Citizen")
            {
                var age = int.Parse(inhabitantInfo[2]);
                var id = inhabitantInfo[3];
                var birthdate = inhabitantInfo[4];

                inhabitants.Add(new Citizen(name, age, id, birthdate));
            }
            else if (type == "Pet")
            {
                var birthdate = inhabitantInfo[2];

                inhabitants.Add(new Pet(name, birthdate));
            }
        }

        private static void PrintBirthdates(List<IBornable> inhabitants)
        {
            var targetYear = Console.ReadLine();

            foreach (var inhabitant in inhabitants.Where(i => i.Birthdate.EndsWith(targetYear)))
            {
                Console.WriteLine(inhabitant.Birthdate);
            }
        }
    }
}