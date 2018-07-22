public class Student
{
    public Student(string name, int age, double grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }

    public string Name { get; set; }
    public int Age { get; set; }
    public double Grade { get; set; }

    public override string ToString()
    {
        var gradeComment = GetGradeComment();

        return $"{Name} is {Age} years old. {gradeComment}.";
    }

    private string GetGradeComment()
    {
        if (Grade >= 5.00)
        {
            return "Excellent student";
        }
        else if (Grade < 3.50)
        {
            return "Very nice person";
        }
        else
        {
            return "Average student";
        }
    }
}