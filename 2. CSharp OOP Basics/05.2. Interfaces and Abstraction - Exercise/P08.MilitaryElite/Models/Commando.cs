using System;
using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    public Commando(string id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        Missions = new List<IMission>();
    }

    public List<IMission> Missions { get; set; }

    public override string ToString()
    {
        return new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine("Missions:")
            .AppendLine(string.Join(Environment.NewLine, Missions))
            .ToString()
            .TrimEnd();
    }
}