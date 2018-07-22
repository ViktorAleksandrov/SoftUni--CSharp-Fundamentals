namespace P4.AcademyGraduation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AcademyGraduation
    {
        public static void Main()
        {
            var studentsCount = int.Parse(Console.ReadLine());

            var studentsGrades = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                var studentName = Console.ReadLine();

                var grades = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                studentsGrades.Add(studentName, grades);
            }

            foreach (var pair in studentsGrades)
            {
                var studentName = pair.Key;
                var averageGrade = pair.Value.Average();

                Console.WriteLine($"{studentName} is graduated with {averageGrade}");
            }
        }
    }
}