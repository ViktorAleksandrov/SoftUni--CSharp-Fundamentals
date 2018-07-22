namespace P02.KnightGame
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            var boardSize = int.Parse(Console.ReadLine());

            if (boardSize < 3)
            {
                Console.WriteLine(0);
                return;
            }

            var board = FillBoard(boardSize);

            var knigthsToRemove = CountRemovedKnights(boardSize, board);

            Console.WriteLine(knigthsToRemove);
        }

        private static char[][] FillBoard(int boardSize)
        {
            var board = new char[boardSize][];

            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().Trim().ToCharArray();
            }

            return board;
        }

        private static int CountRemovedKnights(int boardSize, char[][] board)
        {
            var knigthsToRemove = 0;

            while (true)
            {
                var maxAttacks = 0;

                var targetRow = 0;
                var targetColumn = 0;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        if (board[row][column] == '0')
                        {
                            continue;
                        }

                        var currentAttacks = CountAttacks(row, column, board, boardSize);

                        if (currentAttacks > maxAttacks)
                        {
                            targetRow = row;
                            targetColumn = column;

                            maxAttacks = currentAttacks;

                            if (maxAttacks == 8)
                            {
                                break;
                            }
                        }
                    }

                    if (maxAttacks == 8)
                    {
                        break;
                    }
                }

                if (maxAttacks > 0)
                {
                    board[targetRow][targetColumn] = '0';
                    knigthsToRemove++;
                }
                else
                {
                    break;
                }
            }

            return knigthsToRemove;
        }

        private static int CountAttacks(int row, int column, char[][] board, int boardSize)
        {
            int attacksCounter = 0;

            if (IsPositionAttacked(row - 2, column - 1, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row - 2, column + 1, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row - 1, column - 2, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row - 1, column + 2, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row + 1, column - 2, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row + 1, column + 2, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row + 2, column - 1, board, boardSize))
            {
                attacksCounter++;
            }

            if (IsPositionAttacked(row + 2, column + 1, board, boardSize))
            {
                attacksCounter++;
            }

            return attacksCounter;
        }

        private static bool IsPositionAttacked(int row, int column, char[][] board, int boardSize)
        {
            var isOnBoard = row >= 0 && row < boardSize && column >= 0 && column < boardSize;

            if (isOnBoard && board[row][column] == 'K')
            {
                return true;
            }

            return false;
        }
    }
}