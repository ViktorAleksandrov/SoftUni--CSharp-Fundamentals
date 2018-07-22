namespace P06.AMinerTask
{
    using System;
    using System.Collections.Generic;

    public class AMinerTask
    {
        public static void Main()
        {
            var resourcesQuantities = new Dictionary<string, int>();

            while (true)
            {
                var resource = Console.ReadLine();

                if (resource == "stop")
                {
                    break;
                }

                if (resourcesQuantities.ContainsKey(resource) == false)
                {
                    resourcesQuantities[resource] = 0;
                }

                var quantity = int.Parse(Console.ReadLine());

                resourcesQuantities[resource] += quantity;
            }

            foreach (var pair in resourcesQuantities)
            {
                var resource = pair.Key;
                var quantity = pair.Value;

                Console.WriteLine($"{resource} -> {quantity}");
            }
        }
    }
}