namespace P06.CompanyRoster
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var employeesCount = int.Parse(Console.ReadLine());

            var employees = new List<Employee>(employeesCount);

            for (int i = 0; i < employeesCount; i++)
            {
                var employee = CreateEmployee();

                employees.Add(employee);
            }

            PrintOutput(employees);
        }

        private static Employee CreateEmployee()
        {
            var employeeArgs = Console.ReadLine().Split();

            var email = "n/a";
            var age = -1;

            if (employeeArgs.Length == 6)
            {
                email = employeeArgs[4];
                age = int.Parse(employeeArgs[5]);
            }
            else if (employeeArgs.Length == 5 && int.TryParse(employeeArgs[4], out age) == false)
            {
                email = employeeArgs[4];
                age = -1;
            }

            var name = employeeArgs[0];
            var salary = decimal.Parse(employeeArgs[1]);
            var position = employeeArgs[2];
            var department = employeeArgs[3];

            return new Employee(name, salary, position, department, email, age);
        }

        private static void PrintOutput(List<Employee> employees)
        {
            var bestDepartment = employees
                            .GroupBy(e => e.Department)
                            .OrderByDescending(g => g.Average(e => e.Salary))
                            .First()
                            .Key;

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            employees
                .Where(e => e.Department == bestDepartment)
                .OrderByDescending(e => e.Salary)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}