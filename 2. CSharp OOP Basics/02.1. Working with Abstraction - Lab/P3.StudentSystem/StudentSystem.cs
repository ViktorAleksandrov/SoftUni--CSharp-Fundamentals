using System;
using System.Collections.Generic;

public class StudentSystem
{
    public StudentSystem()
    {
        StudentsInfo = new Dictionary<string, Student>();
    }

    public Dictionary<string, Student> StudentsInfo { get; private set; }

    public void ParseCommand(string[] commandArgs)
    {
        var command = commandArgs[0];
        var name = commandArgs[1];

        if (command == "Create")
        {
            var age = int.Parse(commandArgs[2]);
            var grade = double.Parse(commandArgs[3]);

            CreateStudent(name, age, grade);
        }
        else if (command == "Show")
        {
            ShowStudentInfo(name);
        }
    }

    private void CreateStudent(string name, int age, double grade)
    {
        if (StudentsInfo.ContainsKey(name) == false)
        {
            var student = new Student(name, age, grade);

            StudentsInfo[name] = student;
        }
    }

    private void ShowStudentInfo(string name)
    {
        if (StudentsInfo.ContainsKey(name))
        {
            var student = StudentsInfo[name];

            Console.WriteLine(student);
        }
    }
}