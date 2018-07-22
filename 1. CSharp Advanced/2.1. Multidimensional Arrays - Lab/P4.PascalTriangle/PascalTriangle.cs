namespace P4.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main()
        {
            var rowsCount = int.Parse(Console.ReadLine());

            var pascalTriangle = new long[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                pascalTriangle[row][0] = 1;

                var rowFirstNumber = pascalTriangle[row][0];

                Console.Write(rowFirstNumber + " ");

                if (row > 1)
                {
                    for (int index = 1; index < row; index++)
                    {
                        var leftNumber = pascalTriangle[row - 1][index - 1];
                        var rightNumber = pascalTriangle[row - 1][index];

                        pascalTriangle[row][index] = leftNumber + rightNumber;

                        var currentNumber = pascalTriangle[row][index];

                        Console.Write(currentNumber + " ");
                    }
                }

                if (row > 0)
                {
                    pascalTriangle[row][row] = 1;

                    var rowLastNumber = pascalTriangle[row][row];

                    Console.WriteLine(rowLastNumber);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }
    }
}