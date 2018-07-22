namespace P07.LegoBlocks
{
    using System;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main()
        {
            var rowsNumber = int.Parse(Console.ReadLine());

            var firstArray = new string[rowsNumber][];
            var secondArray = new string[rowsNumber][];

            var bothArraysTotalLength = 0;

            for (int index = 0; index < rowsNumber * 2; index++)
            {
                var currentElements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (index < rowsNumber)
                {
                    firstArray[index] = currentElements;

                }
                else
                {
                    secondArray[index - rowsNumber] = currentElements;
                }

                bothArraysTotalLength += currentElements.Length;
            }

            var totalWidth = firstArray[0].Length + secondArray[0].Length;

            for (int index = 1; index < rowsNumber; index++)
            {
                var currentRowsLengthsSum = firstArray[index].Length + secondArray[index].Length;

                if (currentRowsLengthsSum != totalWidth)
                {
                    Console.WriteLine($"The total number of cells is: {bothArraysTotalLength}");
                    return;
                }
            }

            for (int row = 0; row < rowsNumber; row++)
            {
                var resultRow = firstArray[row].Concat(secondArray[row].Reverse()).ToArray();

                Console.WriteLine($"[{string.Join(", ", resultRow)}]");
            }
        }
    }
}