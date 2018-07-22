namespace P02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            var matrixSize = int.Parse(Console.ReadLine());

            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;

            var matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrixSize; row++)
            {
                var rowParams = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int column = 0; column < matrixSize; column++)
                {
                    var currentNumber = rowParams[column];

                    if (row == column)
                    {
                        primaryDiagonal += currentNumber;
                    }

                    if (column == matrixSize - 1 - row)
                    {
                        secondaryDiagonal += currentNumber;
                    }

                    matrix[row, column] = currentNumber;
                }
            }

            var difference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}