using System;
using System.Linq;
using System.Reflection;

namespace P02.BlackBoxInteger
{
    public class Program
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);

            MethodInfo[] allMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            object classInstance = Activator.CreateInstance(classType, true);

            FieldInfo innerField = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split('_');

                string methodName = inputArgs[0];

                int value = int.Parse(inputArgs[1]);

                MethodInfo method = allMethods.First(m => m.Name == methodName);

                method.Invoke(classInstance, new object[] { value });

                Console.WriteLine(innerField.GetValue(classInstance));
            }
        }
    }
}
