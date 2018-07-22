using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01.HarvestingFields
{
    public class Program
    {
        public static void Main()
        {
            Type classType = typeof(HarvestingFields);

            FieldInfo[] allFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var result = new StringBuilder();

            string command;

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                IEnumerable<FieldInfo> fieldToPrint = null;

                switch (command)
                {
                    case "private":
                        fieldToPrint = allFields.Where(f => f.IsPrivate);
                        break;
                    case "protected":
                        fieldToPrint = allFields.Where(f => f.IsFamily);
                        break;
                    case "public":
                        fieldToPrint = allFields.Where(f => f.IsPublic);
                        break;
                    case "all":
                        fieldToPrint = allFields;
                        break;
                }

                foreach (FieldInfo field in fieldToPrint)
                {
                    result.AppendLine($"{field.Attributes.ToString().ToLower()} {field.FieldType.Name} {field.Name}");
                }
            }

            string output = result.Replace("family", "protected").ToString().TrimEnd();

            Console.WriteLine(output);
        }
    }
}
