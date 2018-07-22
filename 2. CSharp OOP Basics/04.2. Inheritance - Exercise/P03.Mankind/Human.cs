using System;

public class Human
{
    private const string InvalidFirstLetter = "Expected upper case letter! Argument: {0}";
    private const string InvalidNameLength = "Expected length at least {0} symbols! Argument: {1}";
    private const int FirstNameMinLength = 4;
    private const int LastNameMinLength = 3;

    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    private string FirstName
    {
        get => firstName;

        set
        {
            ValidateName(value, nameof(firstName), FirstNameMinLength);

            firstName = value;
        }
    }

    private string LastName
    {
        get => lastName;

        set
        {
            ValidateName(value, nameof(lastName), LastNameMinLength);

            lastName = value;
        }
    }

    private void ValidateName(string value, string nameType, int minLength)
    {
        if (char.IsUpper(value[0]) == false)
        {
            throw new ArgumentException(string.Format(InvalidFirstLetter, nameType));
        }

        if (value.Length < minLength)
        {
            throw new ArgumentException(string.Format(InvalidNameLength, minLength, nameType));
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}" + Environment.NewLine
             + $"Last Name: {LastName}";
    }
}