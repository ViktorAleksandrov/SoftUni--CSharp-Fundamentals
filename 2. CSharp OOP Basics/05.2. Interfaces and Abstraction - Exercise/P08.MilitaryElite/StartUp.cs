namespace P08.MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var soldiers = new List<ISoldier>();

            while (true)
            {
                var soldierInfo = Console.ReadLine().Split();

                var soldierType = soldierInfo[0];

                if (soldierType == "End")
                {
                    break;
                }

                var id = soldierInfo[1];
                var firstName = soldierInfo[2];
                var lastName = soldierInfo[3];
                var salary = decimal.Parse(soldierInfo[4]);
                string corps;

                switch (soldierType)
                {
                    case "Private":
                        soldiers.Add(new Private(id, firstName, lastName, salary));
                        break;

                    case "LeutenantGeneral":
                        var privates = new List<ISoldier>();

                        AddPrivates(soldiers, soldierInfo, privates);

                        soldiers.Add(new LeutenantGeneral(id, firstName, lastName, salary, privates));
                        break;

                    case "Engineer":

                        corps = soldierInfo[5];

                        try
                        {
                            var engineer = new Engineer(id, firstName, lastName, salary, corps);

                            AddRepairs(soldierInfo, engineer);

                            soldiers.Add(engineer);
                        }
                        catch (ArgumentException)
                        {
                        }

                        break;

                    case "Commando":

                        corps = soldierInfo[5];

                        try
                        {
                            var commando = new Commando(id, firstName, lastName, salary, corps);

                            AddMissions(soldierInfo, commando);

                            soldiers.Add(commando);
                        }
                        catch (ArgumentException)
                        {
                        }

                        break;

                    case "Spy":
                        var codeNumber = int.Parse(soldierInfo[4]);
                        soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                        break;
                }
            }

            soldiers.ForEach(Console.WriteLine);
        }

        private static void AddPrivates(List<ISoldier> soldiers, string[] soldierInfo, List<ISoldier> privates)
        {
            for (int index = 5; index < soldierInfo.Length; index++)
            {
                var privateId = soldierInfo[index];
                var currentPrivate = soldiers.First(s => s.Id == privateId);

                privates.Add(currentPrivate);
            }
        }

        private static void AddRepairs(string[] soldierInfo, Engineer engineer)
        {
            for (int index = 6; index < soldierInfo.Length; index += 2)
            {
                var partName = soldierInfo[index];
                var hoursWorked = int.Parse(soldierInfo[index + 1]);

                engineer.Repairs.Add(new Repair(partName, hoursWorked));
            }
        }

        private static void AddMissions(string[] soldierInfo, Commando commando)
        {
            for (int index = 6; index < soldierInfo.Length; index += 2)
            {
                var codeName = soldierInfo[index];
                var state = soldierInfo[index + 1];

                try
                {
                    var mission = new Mission(codeName, state);

                    commando.Missions.Add(mission);
                }
                catch (ArgumentException)
                {
                }
            }
        }
    }
}