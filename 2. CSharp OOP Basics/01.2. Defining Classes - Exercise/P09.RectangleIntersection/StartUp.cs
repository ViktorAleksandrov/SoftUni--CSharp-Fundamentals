namespace P09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var inputArgs = Console.ReadLine().Split();

            var rectanglesCount = int.Parse(inputArgs[0]);

            var rectangles = new List<Rectangle>();

            FillRectangles(rectanglesCount, rectangles);

            var intersectionChecks = int.Parse(inputArgs[1]);

            PrintOutput(intersectionChecks, rectangles);
        }

        private static void FillRectangles(int rectanglesCount, List<Rectangle> rectangles)
        {
            for (int i = 0; i < rectanglesCount; i++)
            {
                var rectangleArgs = Console.ReadLine().Split();

                var id = rectangleArgs[0];
                var width = double.Parse(rectangleArgs[1]);
                var height = double.Parse(rectangleArgs[2]);
                var leftVertical = double.Parse(rectangleArgs[3]);
                var topHorizontal = double.Parse(rectangleArgs[4]);

                var rectangle = new Rectangle(id, width, height, leftVertical, topHorizontal);

                rectangles.Add(rectangle);
            }
        }

        private static void PrintOutput(int intersectionChecks, List<Rectangle> rectangles)
        {
            for (int i = 0; i < intersectionChecks; i++)
            {
                var rectanglesIDs = Console.ReadLine().Split();

                var rectangleOneID = rectanglesIDs[0];
                var rectangleTwoID = rectanglesIDs[1];

                var rectangleOne = rectangles.First(r => r.Id == rectangleOneID);
                var rectangleTwo = rectangles.First(r => r.Id == rectangleTwoID);

                Console.WriteLine(rectangleOne.Intersect(rectangleTwo) ? "true" : "false");
            }
        }
    }
}