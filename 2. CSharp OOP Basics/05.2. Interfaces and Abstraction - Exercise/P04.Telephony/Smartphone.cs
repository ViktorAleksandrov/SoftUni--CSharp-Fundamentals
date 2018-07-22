using System;
using System.Linq;

public class Smartphone : ICallable, IBrowsable
{
    public void Call(string number)
    {
        if (number.All(char.IsDigit))
        {
            Console.WriteLine($"Calling... {number}");
        }
        else
        {
            Console.WriteLine("Invalid number!");
        }
    }

    public void Browse(string site)
    {
        if (site.Any(char.IsDigit))
        {
            Console.WriteLine("Invalid URL!");
        }
        else
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}