namespace P11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ThePartyReservationFilterModule
    {
        public static void Main()
        {
            var filters = new List<string>();

            var guests = Console.ReadLine().Split().ToList();

            while (true)
            {
                var inputParams = Console.ReadLine().Split(';');

                if (inputParams[0] == "Print")
                {
                    break;
                }

                UpdateFilters(inputParams, filters);
            }

            FilterGuests(guests, filters);

            Console.WriteLine(string.Join(" ", guests));
        }

        private static void UpdateFilters(string[] inputParams, List<string> filters)
        {
            var command = inputParams[0];

            var filter = $"{inputParams[1]}-{inputParams[2]}";

            if (command == "Add filter")
            {
                filters.Add(filter);
            }
            else if (command == "Remove filter")
            {
                filters.Remove(filter);
            }
        }

        private static void FilterGuests(List<string> guests, List<string> filters)
        {
            Func<string, string, bool> startsWith = (g, f) => g.StartsWith(f);
            Func<string, string, bool> endsWith = (g, f) => g.EndsWith(f);
            Func<string, string, bool> isLengthEqual = (g, f) => g.Length == int.Parse(f);
            Func<string, string, bool> contains = (g, f) => g.Contains(f);

            foreach (var filter in filters)
            {
                var filterParams = filter.Split('-');

                var filterType = filterParams[0];
                var filterParameter = filterParams[1];

                switch (filterType)
                {
                    case "Starts with":
                        guests.RemoveAll(g => startsWith(g, filterParameter));
                        break;
                    case "Ends with":
                        guests.RemoveAll(g => endsWith(g, filterParameter));
                        break;
                    case "Length":
                        guests.RemoveAll(g => isLengthEqual(g, filterParameter));
                        break;
                    case "Contains":
                        guests.RemoveAll(g => contains(g, filterParameter));
                        break;
                }
            }
        }
    }
}