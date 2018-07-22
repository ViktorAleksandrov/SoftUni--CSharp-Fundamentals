using System;

public class Rectangle : Quadrangle
{
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int Width { get; set; }
    public int Height { get; set; }

    public override void Draw()
    {
        for (int row = 0; row < Height; row++)
        {
            if (row == 0 || row == Height - 1)
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