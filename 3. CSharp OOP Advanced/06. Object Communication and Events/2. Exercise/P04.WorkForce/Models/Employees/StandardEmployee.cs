namespace P04.WorkForce.Models.Employees
{
    public class StandardEmployee : Employee
    {
        private const int DefaultWorkHoursPerWeek = 40;

        public StandardEmployee(string name)
            : base(name, DefaultWorkHoursPerWeek)
        {
        }
    }
}
