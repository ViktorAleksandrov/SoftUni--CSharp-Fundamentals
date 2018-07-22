namespace P01.DangerousFloor
{
    using System;

    public class DangerousFloor
    {
        const int boardSize = 8;

        public static void Main()
        {
            var board = FillBoard();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                ProcessInputLine(board, inputLine);
            }
        }

        private static string[][] FillBoard()
        {
            var board = new string[boardSize][];

            for (int row = 0; row < boardSize; row++)
            {
                board[row] = Console.ReadLine().Split(',');
            }

            return board;
        }

        private static void ProcessInputLine(string[][] board, string inputLine)
        {
            var piece = inputLine[0].ToString();
            var startRow = int.Parse(inputLine[1].ToString());
            var startColumn = int.Parse(inputLine[2].ToString());
            var finalRow = int.Parse(inputLine[4].ToString());
            var finalColumn = int.Parse(inputLine[5].ToString());

            var boardElement = board[startRow][startColumn];

            if (boardElement != piece)
            {
                Console.WriteLine("There is no such a piece!");
            }
            else if (IsMoveInvalid(piece, startRow, startColumn, finalRow, finalColumn))
            {
                Console.WriteLine("Invalid move!");
            }
            else if (IsInsideBoard(finalRow, finalColumn))
            {
                board[startRow][startColumn] = "x";
                board[finalRow][finalColumn] = piece;
            }
            else
            {
                Console.WriteLine("Move go out of board!");
            }
        }

        private static bool IsInsideBoard(int row, int column)
        {
            return row >= 0 && row < boardSize && column >= 0 && column < boardSize;
        }

        private static bool IsMoveInvalid(string piece, int startRow, int startColumn, int finalRow, int finalColumn)
        {
            switch (piece)
            {
                case "K":
                    return IsKingMoveInvalid(startRow, startColumn, finalRow, finalColumn);
                case "R":
                    return IsRookMoveInvalid(startRow, startColumn, finalRow, finalColumn);
                case "B":
                    return IsBishopMoveInvalid(startRow, startColumn, finalRow, finalColumn);
                case "Q":
                    return IsRookMoveInvalid(startRow, startColumn, finalRow, finalColumn)
                        && IsBishopMoveInvalid(startRow, startColumn, finalRow, finalColumn);
                default:
                    return IsPawnMoveInvalid(startRow, startColumn, finalRow, finalColumn);
            }
        }

        private static bool IsKingMoveInvalid(int startRow, int startColumn, int finalRow, int finalColumn)
        {
            return Math.Abs(startRow - finalRow) > 1 || Math.Abs(startColumn - finalColumn) > 1;
        }

        private static bool IsRookMoveInvalid(int startRow, int startColumn, int finalRow, int finalColumn)
        {
            return startRow != finalRow && startColumn != finalColumn;
        }

        private static bool IsBishopMoveInvalid(int startRow, int startColumn, int finalRow, int finalColumn)
        {
            return Math.Abs(startRow - finalRow) != Math.Abs(startColumn - finalColumn);
        }

        private static bool IsPawnMoveInvalid(int startRow, int startColumn, int finalRow, int finalColumn)
        {
            return startRow - 1 != finalRow || startColumn != finalColumn;
        }
    }
}