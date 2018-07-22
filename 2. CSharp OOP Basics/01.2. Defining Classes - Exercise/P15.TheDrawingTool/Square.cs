using System;

public class Square : Quadrangle
{
    public Square(int width)
    {
        Width = width;
    }

    public int Width { get; set; }

    public override void Draw()
    {
        for (int row = 0; row < Width; row++)
        {
            if (row == 0 || row == Width - 1)
            {
                Console.WriteLine($"|{new string('-', Width)}|");
            }
            else
            {
                Console.WriteLine($"|{new string(' ', Width)}|");
            }
        }
    }
}