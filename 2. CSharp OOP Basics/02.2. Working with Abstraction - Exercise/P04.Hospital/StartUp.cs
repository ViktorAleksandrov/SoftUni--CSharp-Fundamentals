namespace P04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var doctors = new Dictionary<string, SortedSet<string>>();
            var departments = new Dictionary<string, List<List<string>>>();

            while (true)
            {
                var hospitalArgs = Console.ReadLine().Split();

                var department = hospitalArgs[0];

                if (department == "Output")
                {
                    break;
                }

                var doctorFullName = $"{hospitalArgs[1]} {hospitalArgs[2]}";

                var patient = hospitalArgs[3];

                AddHospitalData(doctors, departments, department, doctorFullName, patient);
            }

            PrintOutput(doctors, departments);
        }

        private static void AddHospitalData(
            Dictionary<string, SortedSet<string>> doctors,
            Dictionary<string, List<List<string>>> departments,
            string departament, string doctorFullName, string patient)
        {
            if (doctors.ContainsKey(doctorFullName) == false)
            {
                doctors[doctorFullName] = new SortedSet<string>();
            }

            if (departments.ContainsKey(departament) == false)
            {
                departments[departament] = new List<List<string>>();

                for (int room = 0; room < 20; room++)
                {
                    departments[departament].Add(new List<string>());
                }
            }

            var hasFreeBed = departments[departament].SelectMany(x => x).Count() < 60;

            if (hasFreeBed)
            {
                doctors[doctorFullName].Add(patient);

                for (int room = 0; room < departments[departament].Count; room++)
                {
                    if (departments[departament][room].Count < 3)
                    {
                        departments[departament][room].Add(patient);
                        break;
                    }
                }
            }
        }

        private static void PrintOutput(
            Dictionary<string, SortedSet<string>> doctors, Dictionary<string, List<List<string>>> departments)
        {
            while (true)
            {
                var commandArgs = Console.ReadLine().Split();

                var department = commandArgs[0];

                if (department == "End")
                {
                    break;
                }

                if (commandArgs.Length == 1)
                {
                    var departmentPatients = departments[department].Where(x => x.Count > 0).SelectMany(x => x);

                    Console.WriteLine(string.Join(Environment.NewLine, departmentPatients));
                }
                else if (commandArgs.Length == 2 && int.TryParse(commandArgs[1], out int room))
                {
                    var orderedRoomPatients = departments[department][room - 1].OrderBy(x => x);

                    Console.WriteLine(string.Join(Environment.NewLine, orderedRoomPatients));
                }
                else
                {
                    var doctorName = $"{commandArgs[0]} {commandArgs[1]}";

                    Console.WriteLine(string.Join(Environment.NewLine, doctors[doctorName]));
                }
            }
        }
    }
}