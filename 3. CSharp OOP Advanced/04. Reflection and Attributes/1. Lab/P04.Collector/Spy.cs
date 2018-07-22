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

    public string AnalyzeAcessModifiers(string className)
    {
        var classType = Type.GetType(className);

        FieldInfo[] classPublicFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        var stringBuilder = new StringBuilder();

        foreach (FieldInfo field in classPublicFields)
        {
            stringBuilder.AppendLine($"{field.Name} must be private!");
        }

        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be public!");
        }

        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} have to be private!");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);

        MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"All Private Methods of Class: {className}");
        stringBuilder.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classPrivateMethods)
        {
            stringBuilder.AppendLine(method.Name);
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);

        MethodInfo[] classMethods = classType.GetMethods(
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        var stringBuilder = new StringBuilder();

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().TrimEnd();
    }
}
