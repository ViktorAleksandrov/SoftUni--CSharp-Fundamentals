public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName => firstName;
    public string LastName => lastName;
    public int Age => age;

    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} is {Age} years old.";
    }
}