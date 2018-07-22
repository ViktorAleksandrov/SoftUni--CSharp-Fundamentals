using System;

public class DateModifier
{
    public int DayDifference { get; set; }

    public void CalculateDayDifference(string firstString, string secondString)
    {
        var firstDate = DateTime.Parse(firstString);
        var secondDate = DateTime.Parse(secondString);

        DayDifference = Math.Abs((firstDate - secondDate).Days);
    }
}