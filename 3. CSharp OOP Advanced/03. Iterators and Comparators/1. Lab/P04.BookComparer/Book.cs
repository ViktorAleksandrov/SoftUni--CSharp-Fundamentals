﻿using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get; private set; }

    public int Year { get; private set; }

    public IReadOnlyList<string> Authors { get; private set; }

    public int CompareTo(Book other)
    {
        int comparisonResult = this.Year.CompareTo(other.Year);

        if (comparisonResult == 0)
        {
            comparisonResult = this.Title.CompareTo(other.Title);
        }

        return comparisonResult;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}
