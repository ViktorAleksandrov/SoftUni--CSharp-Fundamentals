using System;
using System.Linq;

public class Student : Human
{
    private const int MinLength = 5;
    private const int MaxLength = 10;

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    private string FacultyNumber
    {
        get => facultyNumber;

        set
        {
            if (value.All(char.IsLetterOrDigit) == false || value.Length < MinLength || value.Length > MaxLength)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine
             + $"Faculty number: {FacultyNumber}";
    }
}