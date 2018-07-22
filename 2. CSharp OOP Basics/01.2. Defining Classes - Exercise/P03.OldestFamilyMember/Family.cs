using System.Collections.Generic;
using System.Linq;

public class Family
{
    public Family()
    {
        Members = new List<Person>();
    }

    List<Person> Members { get; set; }

    public void AddMember(Person member)
    {
        Members.Add(member);
    }

    public Person GetOldestMember()
    {
        return Members
            .OrderByDescending(p => p.Age)
            .FirstOrDefault();
    }
}