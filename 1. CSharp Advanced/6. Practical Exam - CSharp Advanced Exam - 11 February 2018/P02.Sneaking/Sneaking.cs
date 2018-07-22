namespace P02.Sneaking
{
    using System;
    using System.Linq;

    public class Sneaking
    {
        public static void Main()
        {
            var roomRowsCount = int.Parse(Console.ReadLine());

            var room = new char[roomRowsCount][];

            var nicoladzeRow = 0;
            var nicoladzeColumn = 0;

            var samRow = 0;
            var samColumn = 0;

            for (int row = 0; row < roomRowsCount; row++)
            {
                room[row] = Console.ReadLine().ToArray();

                if (room[row].Contains('N'))
                {
                    nicoladzeRow = row;
                    nicoladzeColumn = Array.IndexOf(room[row], 'N');
                }
                else if (room[row].Contains('S'))
                {
                    samRow = row;
                    samColumn = Array.IndexOf(room[row], 'S');
                }
            }

            var directions = Console.ReadLine();

            for (int turn = 0; turn < directions.Length; turn++)
            {
                var isSamDead = false;

                for (int row = 0; row < roomRowsCount; row++)
                {
                    var enemyColumn = 0;

                    if (room[row].Contains('b'))
                    {
                        enemyColumn = Array.IndexOf(room[row], 'b');

                        if (enemyColumn + 1 < room[row].Length)
                        {
                            room[row][enemyColumn] = '.';
                            room[row][enemyColumn + 1] = 'b';

                            if (IsSamKilledByB(samRow, samColumn, row, enemyColumn))
                            {
                                isSamDead = true;
                            }
                        }
                        else
                        {
                            room[row][enemyColumn] = 'd';

                            if (IsSamKilledByD(samRow, samColumn, row, enemyColumn))
                            {
                                isSamDead = true;
                            }
                        }
                    }
                    else if (room[row].Contains('d'))
                    {
                        enemyColumn = Array.IndexOf(room[row], 'd');

                        if (enemyColumn > 0)
                        {
                            room[row][enemyColumn] = '.';
                            room[row][enemyColumn - 1] = 'd';

                            if (IsSamKilledByD(samRow, samColumn, row, enemyColumn))
                            {
                                isSamDead = true;
                            }
                        }
                        else
                        {
                            room[row][enemyColumn] = 'b';

                            if (IsSamKilledByB(samRow, samColumn, row, enemyColumn))
                            {
                                isSamDead = true;
                            }
                        }
                    }
                }

                if (isSamDead)
                {
                    room[samRow][samColumn] = 'X';

                    Console.WriteLine($"Sam died at {samRow}, {samColumn}");
                    break;
                }

                room[samRow][samColumn] = '.';

                var currentDirection = directions[turn];

                switch (currentDirection)
                {
                    case 'U':
                        samRow--;
                        break;
                    case 'D':
                        samRow++;
                        break;
                    case 'L':
                        samColumn--;
                        break;
                    case 'R':
                        samColumn++;
                        break;
                }

                room[samRow][samColumn] = 'S';

                if (samRow == nicoladzeRow)
                {
                    room[nicoladzeRow][nicoladzeColumn] = 'X';

                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintRoom(room);
        }

        private static bool IsSamKilledByB(int samRow, int samColumn, int row, int enemyColumn)
        {
            return row == samRow && enemyColumn < samColumn;
        }

        private static bool IsSamKilledByD(int samRow, int samColumn, int row, int enemyColumn)
        {
            return row == samRow && enemyColumn > samColumn;
        }

        private static void PrintRoom(char[][] room)
        {
            foreach (var row in room)
            {
                Console.WriteLine(row);
            }
        }
    }
}