namespace P3.GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var rowsSizes = new int[3];

            foreach (var num in numbers)
            {
                var index = Math.Abs(num) % 3;

                rowsSizes[index]++;
            }

            var group = new int[][]
            {
                new int[rowsSizes[0]],
                new int[rowsSizes[1]],
                new int[rowsSizes[2]]
            };

            var rowsIndices = new int[3];

            foreach (var num in numbers)
            {
                var remainder = Math.Abs(num) % 3;

                var rowIndex = rowsIndices[remainder];

                group[remainder][rowIndex] = num;

                rowsIndices[remainder]++;
            }

            for (int row = 0; row < group.Length; row++)
            {
                foreach (var number in group[row])
                {
                    Console.Write($"{number} ");
                }

                Console.WriteLine();
            }
        }
    }
}