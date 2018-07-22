namespace P1.SumMatrixElements
{
    using System;
    using System.Linq;

    public class SumMatrixElements
    {
        public static void Main()
        {
            var rowsColumns = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var rowCount = rowsColumns[0];
            var columnCount = rowsColumns[1];

            var matrix = new int[rowCount, columnCount];

            var sum = 0;

            for (int row = 0; row < rowCount; row++)
            {
                var rowValues = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

                for (int column = 0; column < columnCount; column++)
                {
                    var currentNumber = rowValues[column];

                    matrix[row, column] = currentNumber;

                    sum += currentNumber;
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}