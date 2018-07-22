using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, List<ISoldier> privates)
        : base(id, firstName, lastName, salary)
    {
        Privates = privates;
    }

    public List<ISoldier> Privates { get; }

    public override string ToString()
    {
        return new StringBuilder()
            .AppendLine(base.ToString())
            .AppendLine("Privates:")
            .AppendLine($"  {string.Join(Environment.NewLine + "  ", Privates)}")
            .ToString()
            .TrimEnd();
    }
}