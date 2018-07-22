namespace P01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            var matrixParams = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rowsCount = matrixParams[0];
            var columnsCount = matrixParams[1];

            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            var matrix = new string[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    var sideLetter = alphabet[row].ToString();
                    var middleLetter = alphabet[column + row].ToString();

                    matrix[row, column] = sideLetter + middleLetter + sideLetter;

                    Console.Write(matrix[row, column] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}