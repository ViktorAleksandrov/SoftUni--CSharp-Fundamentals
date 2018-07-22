namespace P11.ParkingSystem
{
    using System;

    public class ParkingSystem
    {
        public static void Main()
        {
            var parkingDimensions = Console.ReadLine().Split();

            var rowsNumber = int.Parse(parkingDimensions[0]);
            var columnsNumber = int.Parse(parkingDimensions[1]);

            var parking = new byte[rowsNumber][];

            while (true)
            {
                var parkingParams = Console.ReadLine().Split();

                if (parkingParams[0] == "stop")
                {
                    break;
                }

                var entryRow = int.Parse(parkingParams[0]);
                var parkingRow = int.Parse(parkingParams[1]);
                var parkingColumn = int.Parse(parkingParams[2]);

                if (parking[parkingRow] == null)
                {
                    parking[parkingRow] = new byte[columnsNumber];
                }

                var moves = Math.Abs(entryRow - parkingRow) + 1;

                if (parking[parkingRow][parkingColumn] == 0)
                {
                    FillParkingSpot(parking, parkingRow, parkingColumn, moves);
                }
                else
                {
                    SearchForParkingSpot(columnsNumber, parking, parkingRow, parkingColumn, moves);
                }
            }
        }

        private static void SearchForParkingSpot(
            int columnsNumber, byte[][] parking, int parkingRow, int parkingColumn, int moves)
        {
            var counter = 1;

            while (true)
            {
                var leftColumn = parkingColumn - counter;
                var rightColumn = parkingColumn + counter;

                if (leftColumn < 1 && rightColumn >= columnsNumber)
                {
                    Console.WriteLine($"Row {parkingRow} full");
                    break;
                }

                if (leftColumn > 0 && parking[parkingRow][leftColumn] == 0)
                {
                    FillParkingSpot(parking, parkingRow, leftColumn, moves);
                    break;
                }

                if (rightColumn < columnsNumber && parking[parkingRow][rightColumn] == 0)
                {
                    FillParkingSpot(parking, parkingRow, rightColumn, moves);
                    break;
                }

                counter++;
            }
        }

        private static void FillParkingSpot(byte[][] parking, int parkingRow, int targetColumn, int moves)
        {
            parking[parkingRow][targetColumn] = 1;

            moves += targetColumn;

            Console.WriteLine(moves);
        }
    }
}