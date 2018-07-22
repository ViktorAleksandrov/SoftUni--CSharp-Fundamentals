using System;

class StartUp
{
    static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateModifier = new DateModifier();

        dateModifier.CalculateDayDifference(firstDate, secondDate);

        Console.WriteLine(dateModifier.DayDifference);
    }
}