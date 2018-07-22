namespace P04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var hospitalData = FillHospitalData();

            PrintOutput(hospitalData);
        }

        private static List<string> FillHospitalData()
        {
            var hospitalData = new List<string>();

            while (true)
            {
                var hospitalInfo = Console.ReadLine();

                if (hospitalInfo == "Output")
                {
                    break;
                }

                hospitalData.Add(hospitalInfo);
            }

            return hospitalData;
        }

        private static void PrintOutput(List<string> hospitalData)
        {
            while (true)
            {
                var commandLine = Console.ReadLine();

                if (commandLine == "End")
                {
                    break;
                }

                var commandTokens = commandLine.Split();

                if (commandTokens.Length == 1)
                {
                    PrintGivenDepartmentPatients(hospitalData, commandTokens);
                }
                else if (char.IsDigit(commandTokens[1][0]))
                {
                    PrintPatientsInGivenDepartmentRoom(hospitalData, commandTokens);
                }
                else
                {
                    PrintGivenDoctorPatients(hospitalData, commandLine);
                }
            }
        }

        private static void PrintGivenDepartmentPatients(List<string> hospitalData, string[] commandTokens)
        {
            var department = commandTokens[0];

            hospitalData.Where(s => s.StartsWith(department))
                .Select(s => s.Split().Last())
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static void PrintPatientsInGivenDepartmentRoom(List<string> hospitalData, string[] commandTokens)
        {
            var department = commandTokens[0];
            var room = int.Parse(commandTokens[1]);

            hospitalData.Where(s => s.StartsWith(department))
                .Select(s => s.Split().Last())
                .Skip((room - 1) * 3)
                .Take(3)
                .OrderBy(s => s)
                .ToList()
                .ForEach(Console.WriteLine);
        }

        private static void PrintGivenDoctorPatients(List<string> hospitalData, string doctor)
        {
            hospitalData.Where(s => s.Contains(doctor))
                .Select(s => s.Split().Last())
                .OrderBy(s => s)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}