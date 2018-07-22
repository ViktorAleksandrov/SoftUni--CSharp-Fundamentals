namespace P2.SquareWithMaximumSum
{
    using System;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrixParams = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            var rowsNumber = matrixParams[0];
            var columnsNumber = matrixParams[1];

            var matrix = new int[rowsNumber, columnsNumber];

            var topLeftNumber = 0;
            var topRightNumber = 0;

            var bottomLeftNumber = 0;
            var bottomRightNumber = 0;

            var maxSum = 0;

            var searchedRow = 0;
            var searchedColumn = 0;

            for (int row = 0; row < rowsNumber; row++)
            {
                var rowParams = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

                for (int column = 0; column < columnsNumber; column++)
                {
                    var currentNumber = rowParams[column];

                    matrix[row, column] = currentNumber;

                    if (row == 0 || column == 0)
                    {
                        continue;
                    }

                    topLeftNumber = matrix[row - 1, column - 1];
                    topRightNumber = matrix[row - 1, column];

                    var topNumbersSum = topLeftNumber + topRightNumber;

                    bottomLeftNumber = matrix[row, column - 1];
                    bottomRightNumber = matrix[row, column];

                    var bottomNumbersSum = bottomLeftNumber + bottomRightNumber;

                    var wholeSum = topNumbersSum + bottomNumbersSum;

                    if (wholeSum > maxSum)
                    {
                        maxSum = wholeSum;

                        searchedRow = row - 1;
                        searchedColumn = column - 1;
                    }
                }
            }

            topLeftNumber = matrix[searchedRow, searchedColumn];
            topRightNumber = matrix[searchedRow, searchedColumn + 1];

            Console.WriteLine($"{topLeftNumber} {topRightNumber}");

            bottomLeftNumber = matrix[searchedRow + 1, searchedColumn];
            bottomRightNumber = matrix[searchedRow + 1, searchedColumn + 1];

            Console.WriteLine($"{bottomLeftNumber} {bottomRightNumber}");

            Console.WriteLine(maxSum);
        }
    }
}