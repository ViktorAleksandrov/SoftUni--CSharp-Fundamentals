public class Rectangle
{
    public Rectangle(int bottomLeftX, int bottomLeftY, int topRightX, int topRightY)
    {
        BottomLeft = new Point(bottomLeftX, bottomLeftY);
        TopRight = new Point(topRightX, topRightY);
    }

    public Point BottomLeft { get; set; }
    public Point TopRight { get; set; }

    public bool Contains(Point point)
    {
        return point.X >= BottomLeft.X
            && point.X <= TopRight.X
            && point.Y >= BottomLeft.Y
            && point.Y <= TopRight.Y;
    }
}