namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    using Contracts;
    using DataStructures;
    using Exceptions;
    using Models;

    public class StudentsRepository : IDatabase
    {
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, IStudent> students;
        private bool isDataInitialized;
        private IDataFilter filter;
        private IDataSorter sorter;

        public StudentsRepository(IDataFilter filter, IDataSorter sorter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataAlreadyInitializedException);
            }

            this.students = new Dictionary<string, IStudent>();
            this.courses = new Dictionary<string, ICourse>();
            OutputWriter.WriteMessageOnNewLine("Reading data...");
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                throw new ArgumentException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;
            if (File.Exists(path))
            {
                string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s\d]+)";
                Regex rgx = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    if (!string.IsNullOrEmpty(allInputLines[line]) && rgx.IsMatch(allInputLines[line]))
                    {
                        Match currentMatch = rgx.Match(allInputLines[line]);
                        string courseName = currentMatch.Groups[1].Value;
                        string userName = currentMatch.Groups[2].Value;
                        string scoresStr = currentMatch.Groups[3].Value;

                        try
                        {
                            int[] scores = scoresStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse)
                                .ToArray();

                            if (scores.Any(s => s > 100 || s < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                                continue;
                            }

                            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new SoftUniStudent(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new SoftUniCourse(courseName));
                            }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[userName];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                        catch (FormatException fex)
                        {
                            OutputWriter.DisplayException(fex.Message + $"at line {line}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidPathException();
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read!");
        }

        private bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (this.courses.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private bool IsQueryForStudentPossiblе(string courseName, string studentUserName)
        {
            if (this.IsQueryForCoursePossible(courseName)
                && this.courses[courseName].StudentsByName.ContainsKey(studentUserName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string username)
        {
            if (IsQueryForStudentPossiblе(courseName, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(username,
                    this.courses[courseName].StudentsByName[username].MarksByCourseName[courseName]));
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (KeyValuePair<string, IStudent> studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(x => x.Key, x => x.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp)
        {
            var sortedCourses = new SimpleSortedList<ICourse>(cmp);

            sortedCourses.AddAll(this.courses.Values);

            return sortedCourses;
        }

        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp)
        {
            var sortedStudents = new SimpleSortedList<IStudent>(cmp);

            sortedStudents.AddAll(this.students.Values);

            return sortedStudents;
        }
    }
}