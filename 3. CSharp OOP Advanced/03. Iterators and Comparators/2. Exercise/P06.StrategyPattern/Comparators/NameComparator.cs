using System;
using System.Collections.Generic;

namespace P06.StrategyPattern.Comparators
{
    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person firstPerson, Person secondPerson)
        {
            int comparisonResult = firstPerson.Name.Length.CompareTo(secondPerson.Name.Length);

            if (comparisonResult == 0)
            {
                char firstPersonLetter = Char.ToUpper(firstPerson.Name[0]);
                char secondPersonLetter = Char.ToUpper(secondPerson.Name[0]);

                comparisonResult = firstPersonLetter.CompareTo(secondPersonLetter);
            }

            return comparisonResult;
        }
    }
}
