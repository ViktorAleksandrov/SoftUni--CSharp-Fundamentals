public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName => firstName;
    public string LastName => lastName;
    public int Age => age;
    public decimal Salary => salary;

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.salary = salary;
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