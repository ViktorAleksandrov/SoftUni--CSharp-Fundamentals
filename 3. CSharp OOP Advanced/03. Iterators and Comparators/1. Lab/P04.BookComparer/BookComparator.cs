using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        int comparisonResult = x.Title.CompareTo(y.Title);

        if (comparisonResult == 0)
        {
            comparisonResult = y.Year.CompareTo(x.Year);
        }

        return comparisonResult;
    }
}
