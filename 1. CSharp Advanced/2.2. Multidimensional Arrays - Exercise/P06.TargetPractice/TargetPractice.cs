namespace P06.TargetPractice
{
    using System;

    public class TargetPractice
    {
        public static void Main()
        {
            var matrix = ReadMatrixDimensions();

            FillWholeMatrix(matrix);

            ClearCellsInShotRange(matrix);

            LandChars(matrix);

            PrintMatrix(matrix);
        }

        private static char[,] ReadMatrixDimensions()
        {
            var matrixDimensions = Console.ReadLine().Split();

            var rowsNumber = int.Parse(matrixDimensions[0]);
            var columnsNumber = int.Parse(matrixDimensions[1]);

            var matrix = new char[rowsNumber, columnsNumber];

            return matrix;
        }

        private static void FillWholeMatrix(char[,] matrix)
        {
            var startFromRightSide = true;

            var snake = Console.ReadLine();

            var snakeIndex = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (startFromRightSide)
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        FillMatrixRow(matrix, snake, ref snakeIndex, row, column);
                    }

                    startFromRightSide = false;
                }
                else
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        FillMatrixRow(matrix, snake, ref snakeIndex, row, column);
                    }

                    startFromRightSide = true;
                }
            }
        }

        private static void FillMatrixRow(char[,] matrix, string snake, ref int snakeIndex, int row, int column)
        {
            var currentChar = snake[snakeIndex];

            matrix[row, column] = currentChar;

            snakeIndex++;

            if (snakeIndex >= snake.Length)
            {
                snakeIndex = 0;
            }
        }

        private static void ClearCellsInShotRange(char[,] matrix)
        {
            var shotParams = Console.ReadLine().Split();

            var impactRow = int.Parse(shotParams[0]);
            var impactColumn = int.Parse(shotParams[1]);
            var shotRadius = int.Parse(shotParams[2]);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var deltaRow = Math.Pow(row - impactRow, 2);
                    var deltaColumn = Math.Pow(column - impactColumn, 2);

                    var distance = Math.Sqrt(deltaRow + deltaColumn);

                    if (distance <= shotRadius)
                    {
                        matrix[row, column] = ' ';
                    }
                }
            }
        }

        private static void LandChars(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row > 0; row--)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var currentChar = matrix[row, column];

                    if (currentChar != ' ')
                    {
                        continue;
                    }

                    for (int currentRow = row - 1; currentRow >= 0; currentRow--)
                    {
                        var targetChar = matrix[currentRow, column];

                        if (targetChar != ' ')
                        {
                            matrix[row, column] = targetChar;

                            matrix[currentRow, column] = ' ';

                            break;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    var currentChar = matrix[row, column];

                    Console.Write(currentChar);
                }

                Console.WriteLine();
            }
        }
    }
}