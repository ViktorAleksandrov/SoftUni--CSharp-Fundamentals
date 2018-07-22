namespace P15.TheDrawingTool
{
    using System;

    class StartUp
    {
        static void Main()
        {
            var figure = Console.ReadLine();

            var width = int.Parse(Console.ReadLine());

            DrawingTool drawingTool;

            if (figure == "Square")
            {
                var square = new Square(width);

                drawingTool = new DrawingTool(square);
            }
            else
            {
                var height = int.Parse(Console.ReadLine());

                var rectangle = new Rectangle(width, height);

                drawingTool = new DrawingTool(rectangle);
            }

            drawingTool.Draw();
        }
    }
}