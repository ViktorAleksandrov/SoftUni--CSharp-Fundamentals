namespace P10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main()
        {
            var countriesData = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var inputTokens = Console.ReadLine().Split('|');

                var city = inputTokens[0];

                if (city == "report")
                {
                    break;
                }

                var country = inputTokens[1];
                var cityPopulation = long.Parse(inputTokens[2]);

                if (countriesData.ContainsKey(country) == false)
                {
                    countriesData[country] = new Dictionary<string, long>();
                }

                countriesData[country][city] = cityPopulation;
            }

            var orderedCountriesData = countriesData
                .OrderByDescending(kvp => kvp.Value.Values.Sum());

            foreach (var pair in orderedCountriesData)
            {
                var country = pair.Key;
                var countryPopulation = pair.Value.Values.Sum();

                Console.WriteLine($"{country} (total population: {countryPopulation})");

                var cityData = pair.Value
                    .OrderByDescending(kvp => kvp.Value);

                foreach (var kvp in cityData)
                {
                    var city = kvp.Key;
                    var cityPopulation = kvp.Value;

                    Console.WriteLine($"=>{city}: {cityPopulation}");
                }
            }
        }
    }
}