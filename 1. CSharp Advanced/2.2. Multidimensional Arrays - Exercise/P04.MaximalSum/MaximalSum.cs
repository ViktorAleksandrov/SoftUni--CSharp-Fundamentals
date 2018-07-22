namespace P04.MaximalSum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            var matrixParams = Console.ReadLine().Split();

            var rowsCount = int.Parse(matrixParams[0]);
            var columnsCount = int.Parse(matrixParams[1]);

            var matrix = new int[rowsCount, columnsCount];

            var maxSum = int.MinValue;

            var targetRow = 0;
            var targetColumn = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                var rowNumbers = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = rowNumbers[column];

                    if (row < 2 || column < 2)
                    {
                        continue;
                    }

                    var topLeftNumber = matrix[row - 2, column - 2];
                    var topMiddleNumber = matrix[row - 2, column - 1];
                    var topRightNumber = matrix[row - 2, column];

                    var topRowSum = topLeftNumber + topMiddleNumber + topRightNumber;

                    var middleLeftNumber = matrix[row - 1, column - 2];
                    var centerNumber = matrix[row - 1, column - 1];
                    var middleRightNumber = matrix[row - 1, column];

                    var middleRowSum = middleLeftNumber + centerNumber + middleRightNumber;

                    var bottomLeftNumber = matrix[row, column - 2];
                    var bottomMiddleNumber = matrix[row, column - 1];
                    var bottomRightNumber = matrix[row, column];

                    var bottomRowSum = bottomLeftNumber + bottomMiddleNumber + bottomRightNumber;

                    var currentSum = topRowSum + middleRowSum + bottomRowSum;

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;

                        targetRow = row - 2;
                        targetColumn = column - 2;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = targetRow; row < targetRow + 3; row++)
            {
                for (int column = targetColumn; column < targetColumn + 3; column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }

                Console.WriteLine();
            }
        }
    }
}