using System;

public class Person
{
    const int MinNameLength = 3;
    const decimal MinSalary = 460;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get
        {
            return firstName;
        }
        private set
        {
            if (value?.Length < MinNameLength)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

            firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return lastName;
        }
        private set
        {
            if (value?.Length < MinNameLength)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }

            lastName = value;
        }
    }
    public int Age
    {
        get
        {
            return age;
        }
        private set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }

            age = value;
        }
    }
    public decimal Salary
    {
        get
        {
            return salary;
        }
        private set
        {
            if (value < MinSalary)
            {
                throw new ArgumentException($"Salary cannot be less than {MinSalary} leva!");
            }

            salary = value;
        }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        var increase = salary * percentage / 100;

        if (age < 30)
        {
            increase /= 2;
        }

        salary += increase;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} receives {salary:F2} leva.";
    }
}