namespace P08.RadioactiveBunnies
{
    using System;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static void Main()
        {
            var lairDimensions = Console.ReadLine().Split();

            var rowsNumber = int.Parse(lairDimensions[0]);

            var lair = new char[rowsNumber][];

            var playerRow = 0;
            var playerColumn = 0;

            for (int row = 0; row < rowsNumber; row++)
            {
                lair[row] = Console.ReadLine().ToCharArray();

                if (lair[row].Contains('P'))
                {
                    playerRow = row;

                    playerColumn = Array.IndexOf(lair[row], 'P');
                }
            }

            var inputDirections = Console.ReadLine();

            lair[playerRow][playerColumn] = '.';

            var columnsNumber = int.Parse(lairDimensions[1]);

            foreach (var direction in inputDirections)
            {
                var playerPreviousRow = playerRow;
                var playerPreviousColumn = playerColumn;

                switch (direction)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerColumn--;
                        break;
                    case 'R':
                        playerColumn++;
                        break;
                }

                var lairCopy = new char[rowsNumber][];

                for (int row = 0; row < rowsNumber; row++)
                {
                    lairCopy[row] = new char[columnsNumber];

                    Array.Copy(lair[row], lairCopy[row], columnsNumber);
                }

                for (int row = 0; row < rowsNumber; row++)
                {
                    for (int column = 0; column < columnsNumber; column++)
                    {
                        var currentChar = lairCopy[row][column];

                        if (currentChar != 'B')
                        {
                            continue;
                        }

                        if (row > 0)
                        {
                            lair[row - 1][column] = 'B';
                        }

                        if (row < rowsNumber - 1)
                        {
                            lair[row + 1][column] = 'B';
                        }

                        if (column > 0)
                        {
                            lair[row][column - 1] = 'B';
                        }

                        if (column < columnsNumber - 1)
                        {
                            lair[row][column + 1] = 'B';
                        }
                    }
                }

                if (playerRow < 0 || playerRow >= rowsNumber
                    || playerColumn < 0 || playerColumn >= columnsNumber)
                {
                    PrintLair(lair);

                    Console.WriteLine($"won: {playerPreviousRow} {playerPreviousColumn}");
                    break;
                }
                else if (lair[playerRow][playerColumn] == 'B')
                {
                    PrintLair(lair);

                    Console.WriteLine($"dead: {playerRow} {playerColumn}");
                    break;
                }
            }
        }

        private static void PrintLair(char[][] lair)
        {
            foreach (var row in lair)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }
    }
}