using System;
using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Repairs = new List<IRepair>();
    }

    public List<IRepair> Repairs { get; set; }

    public override string ToString()
    {
        return new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine("Repairs:")
            .AppendLine(string.Join(Environment.NewLine, Repairs))
            .ToString()
            .TrimEnd();
    }
}