using System;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    protected Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    private string Name
    {
        get => name;

        set
        {
            IsEmptyValidation(value);

            name = value;
        }
    }

    private int Age
    {
        get => age;

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }

            age = value;
        }
    }

    private string Gender
    {
        get => gender;

        set
        {
            IsEmptyValidation(value);

            gender = value;
        }
    }

    private static void IsEmptyValidation(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Invalid input!");
        }
    }

    public virtual string ProduceSound()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        return GetType().Name + Environment.NewLine
             + $"{Name} {Age} {Gender}" + Environment.NewLine
             + ProduceSound();
    }
}