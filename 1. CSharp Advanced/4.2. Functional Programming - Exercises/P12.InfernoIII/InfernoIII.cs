namespace P12.InfernoIII
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InfernoIII
    {
        public static void Main()
        {
            var gems = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var filters = GetFilters();

            var indicesForDeletion = GetIndicesForDeletion(gems, filters);

            foreach (var index in indicesForDeletion.OrderByDescending(i => i))
            {
                gems.RemoveAt(index);
            }

            Console.WriteLine(string.Join(" ", gems));
        }

        private static List<string> GetFilters()
        {
            var filters = new List<string>();

            while (true)
            {
                var inputParams = Console.ReadLine().Split(';');

                var command = inputParams[0];

                if (command == "Forge")
                {
                    break;
                }

                UpdateFilters(filters, inputParams, command);
            }

            return filters;
        }

        private static void UpdateFilters(List<string> filters, string[] inputParams, string command)
        {
            var filter = $"{inputParams[1]}:{inputParams[2]}";

            if (command == "Exclude")
            {
                filters.Add(filter);
            }
            else if (command == "Reverse")
            {
                filters.Remove(filter);
            }
        }

        private static HashSet<int> GetIndicesForDeletion(List<int> gems, List<string> filters)
        {
            var indicesForDeletion = new HashSet<int>();

            Func<int, int, int, bool> leftOrRightSum = (a, b, c) => a + b == c;
            Func<int, int, int, int, bool> bothSidesSum = (a, b, c, d) => a + b + c == d;

            foreach (var filter in filters)
            {
                var filterParams = filter.Split(':');

                var direction = filterParams[0];
                var filterValue = int.Parse(filterParams[1]);

                for (int index = 0; index < gems.Count; index++)
                {
                    var currentGem = gems[index];

                    var leftGem = 0;

                    if (index > 0)
                    {
                        leftGem = gems[index - 1];
                    }

                    var rightGem = 0;

                    if (index + 1 < gems.Count)
                    {
                        rightGem = gems[index + 1];
                    }

                    if (direction == "Sum Left" && leftOrRightSum(currentGem, leftGem, filterValue))
                    {
                        indicesForDeletion.Add(index);
                    }
                    else if (direction == "Sum Right" && leftOrRightSum(currentGem, rightGem, filterValue))
                    {
                        indicesForDeletion.Add(index);
                    }
                    else if (direction == "Sum Left Right" && bothSidesSum(currentGem, leftGem, rightGem, filterValue))
                    {
                        indicesForDeletion.Add(index);
                    }
                }
            }

            return indicesForDeletion;
        }
    }
}