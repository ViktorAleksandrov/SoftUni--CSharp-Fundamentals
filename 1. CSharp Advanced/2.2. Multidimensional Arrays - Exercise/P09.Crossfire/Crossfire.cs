namespace P09.Crossfire
{
    using System;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            var matrixDimensions = Console.ReadLine().Split();

            var matrix = ReadMatrix(matrixDimensions);

            var columnsNumber = int.Parse(matrixDimensions[1]);

            FillMatrix(matrix, columnsNumber);

            matrix = CrossfireAtMatrix(matrix);

            PrintMatrix(matrix);
        }

        private static int[][] ReadMatrix(string[] matrixDimensions)
        {
            var rowsNumber = int.Parse(matrixDimensions[0]);

            var matrix = new int[rowsNumber][];

            return matrix;
        }

        private static void FillMatrix(int[][] matrix, int columnsNumber)
        {
            var counter = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[columnsNumber];

                for (int column = 0; column < columnsNumber; column++)
                {
                    matrix[row][column] = counter;

                    counter++;
                }
            }
        }

        private static int[][] CrossfireAtMatrix(int[][] matrix)
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "Nuke it from orbit")
            {
                var crossfireParams = inputLine.Split();

                var coordRow = int.Parse(crossfireParams[0]);
                var coordColumn = int.Parse(crossfireParams[1]);

                var radius = int.Parse(crossfireParams[2]);

                FireVertically(matrix, coordRow, coordColumn, radius);

                FireHorizontally(matrix, coordRow, coordColumn, radius);

                matrix = RemoveMatrixEmptyRowsAndElements(matrix);

                inputLine = Console.ReadLine();
            }

            return matrix;
        }

        private static void FireVertically(int[][] matrix, int coordRow, int coordColumn, int radius)
        {
            if (coordRow >= 0 && coordRow < matrix.Length)
            {
                var startColumn = Math.Max(0, coordColumn - radius);
                var endColumn = Math.Min(matrix[coordRow].Length - 1, coordColumn + radius);

                for (var column = startColumn; column <= endColumn; column++)
                {
                    matrix[coordRow][column] = 0;
                }
            }
        }

        private static void FireHorizontally(int[][] matrix, int coordRow, int coordColumn, int radius)
        {
            if (coordColumn >= 0)
            {
                var startRow = Math.Max(0, coordRow - radius);
                var endRow = Math.Min(matrix.Length - 1, coordRow + radius);

                for (var row = startRow; row <= endRow; row++)
                {
                    if (coordColumn < matrix[row].Length)
                    {
                        matrix[row][coordColumn] = 0;
                    }
                }
            }
        }

        private static int[][] RemoveMatrixEmptyRowsAndElements(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                if (matrix[row].Any(n => n == 0))
                {
                    matrix[row] = matrix[row].Where(n => n > 0).ToArray();

                    if (matrix[row].Length == 0)
                    {
                        matrix = matrix
                            .Take(row)
                            .Concat(matrix.Skip(row + 1))
                            .ToArray();

                        row--;
                    }
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}