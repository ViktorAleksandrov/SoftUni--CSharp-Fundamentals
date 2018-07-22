namespace P03.JediGalaxy
{
    using System;

    class StartUp
    {
        static void Main()
        {
            int[,] galaxy = CreateGalaxy();

            long sum = 0;

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Let the Force be with you")
                {
                    break;
                }

                DestroyStars(galaxy);

                sum = SumStars(galaxy, sum, inputLine);
            }

            Console.WriteLine(sum);
        }

        private static int[,] CreateGalaxy()
        {
            var dimensions = Console.ReadLine().Split();

            var rowsNumber = int.Parse(dimensions[0]);
            var columnsNumber = int.Parse(dimensions[1]);

            var galaxy = new int[rowsNumber, columnsNumber];

            var counter = 0;

            for (int row = 0; row < rowsNumber; row++)
            {
                for (int column = 0; column < columnsNumber; column++)
                {
                    galaxy[row, column] = counter++;
                }
            }

            return galaxy;
        }

        private static void DestroyStars(int[,] galaxy)
        {
            var evilPosition = Console.ReadLine().Split();

            var evilRow = int.Parse(evilPosition[0]);
            var evilColumn = int.Parse(evilPosition[1]);

            while (evilRow >= 0 && evilColumn >= 0)
            {
                if (IsInsideGalaxy(galaxy, evilRow, evilColumn))
                {
                    galaxy[evilRow, evilColumn] = 0;
                }

                evilRow--;
                evilColumn--;
            }
        }

        private static long SumStars(int[,] galaxy, long sum, string inputLine)
        {
            var ivoPosition = inputLine.Split();

            var ivoRow = int.Parse(ivoPosition[0]);
            var ivoColumn = int.Parse(ivoPosition[1]);

            while (ivoRow >= 0 && ivoColumn < galaxy.GetLength(1))
            {
                if (IsInsideGalaxy(galaxy, ivoRow, ivoColumn))
                {
                    sum += galaxy[ivoRow, ivoColumn];
                }

                ivoRow--;
                ivoColumn++;
            }

            return sum;
        }

        private static bool IsInsideGalaxy(int[,] galaxy, int row, int column)
        {
            return row >= 0
                && row < galaxy.GetLength(0)
                && column >= 0
                && column < galaxy.GetLength(1);
        }
    }
}