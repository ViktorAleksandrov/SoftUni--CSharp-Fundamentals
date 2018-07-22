using System;
using System.Collections.Generic;
using System.Linq;
using P04.WorkForce.Contracts;
using P04.WorkForce.Models;
using P04.WorkForce.Models.Employees;

namespace P04.WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<IEmployee>();
            var jobs = new JobArrayList();

            string inputLine;

            while ((inputLine = Console.ReadLine()) != "End")
            {
                string[] commandArgs = inputLine.Split();

                switch (commandArgs[0])
                {
                    case "Job":
                        AddJob(employees, jobs, commandArgs);
                        break;
                    case "StandardEmployee":
                    case "PartTimeEmployee":
                        AddEmployee(commandArgs, employees);
                        break;
                    case "Pass":
                        PassWeek(jobs);
                        break;
                    case "Status":
                        PrintJobs(jobs);
                        break;
                }
            }
        }

        private static void AddJob(List<IEmployee> employees, JobArrayList jobs, string[] commandArgs)
        {
            string jobName = commandArgs[1];
            int jobWorkHoursRequired = int.Parse(commandArgs[2]);
            string employeeName = commandArgs[3];

            IEmployee cemployee = employees.First(e => e.Name == employeeName);

            var job = new Job(jobName, jobWorkHoursRequired, cemployee);

            jobs.AddJob(job);
        }

        private static void AddEmployee(string[] commandArgs, List<IEmployee> employees)
        {
            string employeeType = commandArgs[0];
            string employeeName = commandArgs[1];

            IEmployee employee = null;

            switch (employeeType)
            {
                case "StandardEmployee":
                    employee = new StandardEmployee(employeeName);
                    break;
                case "PartTimeEmployee":
                    employee = new PartTimeEmployee(employeeName);
                    break;
            }

            employees.Add(employee);
        }

        private static void PassWeek(JobArrayList jobs)
        {
            int length = jobs.Count;
            int index = 0;
            int currentJobsCount = jobs.Count;

            for (int counter = 0; counter < length; counter++)
            {
                var currentJob = (Job)jobs[index];

                currentJob.Update();

                if (currentJobsCount == jobs.Count)
                {
                    index++;
                }
                else
                {
                    currentJobsCount--;
                }
            }
        }

        private static void PrintJobs(JobArrayList jobs)
        {
            foreach (Job job in jobs)
            {
                Console.WriteLine(job);
            }
        }
    }
}
