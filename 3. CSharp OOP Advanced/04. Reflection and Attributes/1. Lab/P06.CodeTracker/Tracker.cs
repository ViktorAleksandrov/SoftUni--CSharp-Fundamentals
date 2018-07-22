using System;
using System.Linq;
using System.Reflection;
using P06.CodeTracker;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);

        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (MethodInfo method in methods)
        {
            if (method.CustomAttributes.Any(m => m.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attributes = method.GetCustomAttributes(false);

                foreach (SoftUniAttribute attribute in attributes)
                {
                    Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                }
            }
        }
    }
}
