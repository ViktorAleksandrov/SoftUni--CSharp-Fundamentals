using System;
using System.Collections.Generic;

namespace P06.TrafficLights
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] trafficLightsColors = Console.ReadLine().Split();

            var trafficLights = new List<TrafficLight>();

            foreach (string color in trafficLightsColors)
            {
                LightColor lightColor = Enum.Parse<LightColor>(color);

                trafficLights.Add(new TrafficLight(lightColor));
            }

            int changesCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < changesCount; counter++)
            {
                trafficLights.ForEach(t => t.ChangeColor());

                Console.WriteLine(string.Join(' ', trafficLights));
            }
        }
    }
}
