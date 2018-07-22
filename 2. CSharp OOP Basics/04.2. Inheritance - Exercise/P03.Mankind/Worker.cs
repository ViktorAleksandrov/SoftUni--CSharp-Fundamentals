using System;

public class Worker : Human
{
    private const string InvalidValue = "Expected value mismatch! Argument: {0}";
    private const int MinSalary = 10;
    private const int MinWorkHours = 1;
    private const int MaxWorkHours = 12;
    private const int WeekWorkDays = 5;

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = workHoursPerDay;
    }

    private decimal WeekSalary
    {
        get => weekSalary;

        set
        {
            if (value <= MinSalary)
            {
                throw new ArgumentException(string.Format(InvalidValue, nameof(weekSalary)));
            }

            weekSalary = value;
        }
    }

    private double WorkHoursPerDay
    {
        get => workHoursPerDay;

        set
        {
            if (value < MinWorkHours || value > MaxWorkHours)
            {
                throw new ArgumentException(string.Format(InvalidValue, nameof(workHoursPerDay)));
            }

            workHoursPerDay = value;
        }
    }

    private decimal SalaryPerHour => WeekSalary / WeekWorkDays / (decimal)WorkHoursPerDay;

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine
            + $"Week Salary: {WeekSalary:F2}" + Environment.NewLine
            + $"Hours per day: {WorkHoursPerDay:F2}" + Environment.NewLine
            + $"Salary per hour: {SalaryPerHour:F2}";
    }
}