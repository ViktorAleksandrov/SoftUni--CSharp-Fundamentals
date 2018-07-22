using System;
using P04.WorkForce.Contracts;

namespace P04.WorkForce.Models
{
    public delegate void JobDoneEventHandler(Job job);

    public class Job
    {
        private string name;
        private int workHoursRequired;
        private IEmployee employee;

        public Job(string name, int workHoursRequired, IEmployee employee)
        {
            this.name = name;
            this.workHoursRequired = workHoursRequired;
            this.employee = employee;
        }

        public event JobDoneEventHandler JobDone;

        public void Update()
        {
            this.workHoursRequired -= this.employee.WorkHoursPerWeek;

            if (this.workHoursRequired <= 0)
            {
                Console.WriteLine($"{this.GetType().Name} {this.name} done!");

                this.JobDone.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.name} Hours Remaining: {this.workHoursRequired}";
        }
    }
}
