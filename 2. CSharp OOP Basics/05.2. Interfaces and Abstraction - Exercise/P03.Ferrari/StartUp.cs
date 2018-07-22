using System;

class StartUp
{
    static void Main()
    {
        var driverName = Console.ReadLine();

        ICar ferrari = new Ferrari(driverName);

        Console.WriteLine(ferrari);
    }
}