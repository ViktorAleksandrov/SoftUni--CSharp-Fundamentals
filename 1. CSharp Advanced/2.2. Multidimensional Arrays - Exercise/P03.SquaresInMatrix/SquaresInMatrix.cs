namespace P03.SquaresInMatrix
{
    using System;

    public class SquaresInMatrix
    {
        public static void Main()
        {
            var matrixParams = Console.ReadLine().Split();

            var rowsCount = int.Parse(matrixParams[0]);
            var columnsCount = int.Parse(matrixParams[1]);

            var matrix = new string[rowsCount, columnsCount];

            var squareCount = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                var rowSymbols = Console.ReadLine().Split();

                for (int column = 0; column < columnsCount; column++)
                {
                    matrix[row, column] = rowSymbols[column];

                    if (row == 0 || column == 0)
                    {
                        continue;
                    }

                    var topLeftSymbol = matrix[row - 1, column - 1];
                    var topRightSymbol = matrix[row - 1, column];
                    var bottomLeftSymbol = matrix[row, column - 1];
                    var bottomRightSymbol = matrix[row, column];

                    if (topLeftSymbol == topRightSymbol
                        && topLeftSymbol == bottomLeftSymbol
                        && topLeftSymbol == bottomRightSymbol)
                    {
                        squareCount++;
                    }
                }
            }

            Console.WriteLine(squareCount);
        }
    }
}