namespace P04.WorkForce.Models.Employees
{
    public class PartTimeEmployee : Employee
    {
        private const int DefaultWorkHoursPerWeek = 20;

        public PartTimeEmployee(string name)
            : base(name, DefaultWorkHoursPerWeek)
        {
        }
    }
}
