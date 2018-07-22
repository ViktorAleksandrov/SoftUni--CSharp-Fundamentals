namespace P05.BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var inhabitants = new List<IIdentifiable>();

            while (true)
            {
                var inhabitantInfo = Console.ReadLine().Split();

                if (inhabitantInfo[0] == "End")
                {
                    break;
                }

                AddInhabitant(inhabitants, inhabitantInfo);
            }

            PrintDetaineesIds(inhabitants);
        }

        private static void AddInhabitant(List<IIdentifiable> inhabitants, string[] inhabitantInfo)
        {
            if (inhabitantInfo.Length == 3)
            {
                var name = inhabitantInfo[0];
                var age = int.Parse(inhabitantInfo[1]);
                var id = inhabitantInfo[2];

                inhabitants.Add(new Citizen(name, age, id));
            }
            else
            {
                var model = inhabitantInfo[0];
                var id = inhabitantInfo[1];

                inhabitants.Add(new Robot(model, id));
            }
        }

        private static void PrintDetaineesIds(List<IIdentifiable> inhabitants)
        {
            var fakeIdLastDigits = Console.ReadLine();

            foreach (var detainee in inhabitants.Where(i => i.Id.EndsWith(fakeIdLastDigits)))
            {
                Console.WriteLine(detainee.Id);
            }
        }
    }
}