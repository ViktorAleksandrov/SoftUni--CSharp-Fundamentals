namespace P12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main()
        {
            var rotationDegrees = GetRotationDegrees();

            var wordsList = FillListWithWords();

            var maxLength = wordsList.Max(w => w.Length);

            var matrix = new char[wordsList.Count][];

            FillMatrix(wordsList, maxLength, matrix);

            PrintOutput(rotationDegrees, matrix);
        }

        private static int GetRotationDegrees()
        {
            var commandArgs = Console.ReadLine()
                .Split(new[] { '(', ')' }, StringSplitOptions.None);

            var rotationDegrees = int.Parse(commandArgs[1]) % 360;

            return rotationDegrees;
        }

        private static List<string> FillListWithWords()
        {
            var wordsList = new List<string>();

            while (true)
            {
                var word = Console.ReadLine();

                if (word == "END")
                {
                    break;
                }

                wordsList.Add(word);
            }

            return wordsList;
        }

        private static void FillMatrix(List<string> wordsList, int maxLength, char[][] matrix)
        {
            for (int row = 0; row < wordsList.Count; row++)
            {
                matrix[row] = wordsList[row].PadRight(maxLength).ToCharArray();
            }
        }

        private static void PrintOutput(int rotationDegrees, char[][] matrix)
        {
            switch (rotationDegrees)
            {
                case 0:
                    PrintWithoutRotation(matrix);
                    break;
                case 90:
                    PrintWithRotation90(matrix);
                    break;
                case 180:
                    PrintWithRotation180(matrix);
                    break;
                case 270:
                    PrintWithRotation270(matrix);
                    break;
            }
        }

        private static void PrintWithoutRotation(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static void PrintWithRotation90(char[][] matrix)
        {
            for (int column = 0; column < matrix[0].Length; column++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row][column]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintWithRotation180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[row].Reverse()));
            }
        }

        private static void PrintWithRotation270(char[][] matrix)
        {
            for (int column = matrix[0].Length - 1; column >= 0; column--)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write(matrix[row][column]);
                }

                Console.WriteLine();
            }
        }
    }
}