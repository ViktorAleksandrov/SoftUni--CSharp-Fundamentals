namespace P06.Sneaking
{
    using System;
    using System.Linq;

    class StartUp
    {
        static int nicoladzeRow;
        static int nicoladzeColumn;
        static int samRow;
        static int samColumn;
        static bool isSamDead;

        static void Main()
        {
            var roomRowsCount = int.Parse(Console.ReadLine());

            var room = new char[roomRowsCount][];

            FillRoom(roomRowsCount, room);

            var directions = Console.ReadLine();

            for (int turn = 0; turn < directions.Length; turn++)
            {
                MoveEnemy(roomRowsCount, room);

                if (isSamDead)
                {
                    room[samRow][samColumn] = 'X';

                    Console.WriteLine($"Sam died at {samRow}, {samColumn}");
                    break;
                }

                MoveSam(room, directions, turn);

                if (samRow == nicoladzeRow)
                {
                    room[nicoladzeRow][nicoladzeColumn] = 'X';

                    Console.WriteLine("Nikoladze killed!");
                    break;
                }
            }

            PrintRoom(room);
        }

        private static void FillRoom(int roomRowsCount, char[][] room)
        {
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
        }

        private static void MoveEnemy(int roomRowsCount, char[][] room)
        {
            for (int row = 0; row < roomRowsCount; row++)
            {
                if (room[row].Contains('b'))
                {
                    MoveEnemyB(room, row);
                }
                else if (room[row].Contains('d'))
                {
                    MoveEnemyD(room, row);
                }
            }
        }

        private static void MoveEnemyB(char[][] room, int row)
        {
            var enemyColumn = Array.IndexOf(room[row], 'b');

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

        private static void MoveEnemyD(char[][] room, int row)
        {
            var enemyColumn = Array.IndexOf(room[row], 'd');

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

        private static bool IsSamKilledByB(int samRow, int samColumn, int row, int enemyColumn)
        {
            return row == samRow && enemyColumn < samColumn;
        }

        private static bool IsSamKilledByD(int samRow, int samColumn, int row, int enemyColumn)
        {
            return row == samRow && enemyColumn > samColumn;
        }

        private static void MoveSam(char[][] room, string directions, int turn)
        {
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