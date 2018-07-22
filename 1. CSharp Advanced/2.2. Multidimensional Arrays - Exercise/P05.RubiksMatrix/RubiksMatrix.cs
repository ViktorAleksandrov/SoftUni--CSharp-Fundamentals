namespace P05.RubiksMatrix
{
    using System;

    public class RubiksMatrix
    {
        public static void Main()
        {
            var matrix = ReadMatrixParams();

            FillMatrix(matrix);

            RotateMatrix(matrix);

            PrintOutput(matrix);
        }

        private static int[,] ReadMatrixParams()
        {
            var matrixParams = Console.ReadLine().Split();

            var rowsCount = int.Parse(matrixParams[0]);
            var columnsCount = int.Parse(matrixParams[1]);

            var matrix = new int[rowsCount, columnsCount];

            return matrix;
        }

        private static void FillMatrix(int[,] matrix)
        {
            var currentNumber = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = currentNumber;

                    currentNumber++;
                }
            }
        }

        private static void RotateMatrix(int[,] matrix)
        {
            var commandsCount = int.Parse(Console.ReadLine());

            for (int index = 0; index < commandsCount; index++)
            {
                var commandParams = Console.ReadLine().Split();

                var dimension = int.Parse(commandParams[0]);
                var direction = commandParams[1];
                var moves = int.Parse(commandParams[2]);

                var tempNumber = 0;

                switch (direction)
                {
                    case "up":
                        RotateUp(matrix, dimension, moves, tempNumber);
                        break;
                    case "down":
                        RotateDown(matrix, dimension, moves, tempNumber);
                        break;
                    case "left":
                        RotateLeft(matrix, dimension, moves, tempNumber);
                        break;
                    case "right":
                        RotateRight(matrix, dimension, moves, tempNumber);
                        break;
                }
            }
        }

        private static void RotateUp(int[,] matrix, int dimension, int moves, int tempNumber)
        {
            for (int i = 0; i < moves % matrix.GetLength(0); i++)
            {
                tempNumber = matrix[0, dimension];

                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    matrix[row, dimension] = matrix[row + 1, dimension];
                }

                matrix[matrix.GetLength(0) - 1, dimension] = tempNumber;
            }
        }

        private static void RotateDown(int[,] matrix, int dimension, int moves, int tempNumber)
        {
            for (int i = 0; i < moves % matrix.GetLength(0); i++)
            {
                tempNumber = matrix[matrix.GetLength(0) - 1, dimension];

                for (int row = matrix.GetLength(0) - 1; row > 0; row--)
                {
                    matrix[row, dimension] = matrix[row - 1, dimension];
                }

                matrix[0, dimension] = tempNumber;
            }
        }

        private static void RotateLeft(int[,] matrix, int dimension, int moves, int tempNumber)
        {
            for (int i = 0; i < moves % matrix.GetLength(1); i++)
            {
                tempNumber = matrix[dimension, 0];

                for (int column = 0; column < matrix.GetLength(1) - 1; column++)
                {
                    matrix[dimension, column] = matrix[dimension, column + 1];
                }

                matrix[dimension, matrix.GetLength(1) - 1] = tempNumber;
            }
        }

        private static void RotateRight(int[,] matrix, int dimension, int moves, int tempNumber)
        {
            for (int i = 0; i < moves % matrix.GetLength(1); i++)
            {
                tempNumber = matrix[dimension, matrix.GetLength(1) - 1];

                for (int column = matrix.GetLength(1) - 1; column > 0; column--)
                {
                    matrix[dimension, column] = matrix[dimension, column - 1];
                }

                matrix[dimension, 0] = tempNumber;
            }
        }

        private static void PrintOutput(int[,] matrix)
        {
            var targetNumber = 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (targetNumber != matrix[row, column])
                    {
                        var areNumbersEqual = false;

                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                if (targetNumber == matrix[r, col])
                                {
                                    Console.WriteLine($"Swap ({row}, {column}) with ({r}, {col})");

                                    matrix[r, col] = matrix[row, column];

                                    areNumbersEqual = true;
                                    break;
                                }
                            }

                            if (areNumbersEqual)
                            {
                                break;
                            }
                        }

                        matrix[row, column] = targetNumber;
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }

                    targetNumber++;
                }
            }
        }
    }
}