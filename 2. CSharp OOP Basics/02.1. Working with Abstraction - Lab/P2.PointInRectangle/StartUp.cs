namespace P2.PointInRectangle
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var rectangle = CreateRectangle();

            var pointsNumber = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < pointsNumber; counter++)
            {
                var pointCoordinates = Console.ReadLine().Split();

                var x = int.Parse(pointCoordinates[0]);
                var y = int.Parse(pointCoordinates[1]);

                var point = new Point(x, y);

                var isInRectangle = rectangle.Contains(point);

                Console.WriteLine(isInRectangle);
            }
        }

        private static Rectangle CreateRectangle()
        {
            var coordinates = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            var bottomLeftX = coordinates[0];
            var bottomLeftY = coordinates[1];

            var topRightX = coordinates[2];
            var topRightY = coordinates[3];

            return new Rectangle(bottomLeftX, bottomLeftY, topRightX, topRightY);
        }
    }
}