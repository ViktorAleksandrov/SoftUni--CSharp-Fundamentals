using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] requestedFields)
    {
        var classType = Type.GetType(className);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
