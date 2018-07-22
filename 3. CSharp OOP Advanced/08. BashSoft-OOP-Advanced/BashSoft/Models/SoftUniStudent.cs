﻿namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Exceptions;

    public class SoftUniStudent : IStudent
    {
        private string userName;
        private Dictionary<string, ICourse> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses
        {
            get
            {
                return this.enrolledCourses;
            }
        }

        public IReadOnlyDictionary<string, double> MarksByCourseName
        {
            get
            {
                return this.marksByCourseName;
            }
        }

        public void EnrollInCourse(ICourse course)
        {
            if (this.EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.userName, course.Name);
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }

            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        public int CompareTo(IStudent other)
        {
            return this.UserName.CompareTo(other.UserName);
        }

        private double CalculateMark(int[] scores)
        {
            double percentageOfSolvedExam =
                scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);

            double mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }

        public override string ToString()
        {
            return this.UserName;
        }
    }
}