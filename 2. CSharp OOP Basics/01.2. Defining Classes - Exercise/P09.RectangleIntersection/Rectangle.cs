public class Rectangle
{
    public Rectangle(string id, double width, double height, double leftVertical, double topHorizontal)
    {
        Id = id;
        Width = width;
        Height = height;
        LeftVertical = leftVertical;
        TopHorizontal = topHorizontal;
    }

    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double LeftVertical { get; set; }
    public double TopHorizontal { get; set; }

    public bool Intersect(Rectangle rectangle)
    {
        if (LeftVertical > rectangle.LeftVertical + rectangle.Width
            || rectangle.LeftVertical > LeftVertical + Width
            || TopHorizontal > rectangle.TopHorizontal + rectangle.Height
            || rectangle.TopHorizontal > TopHorizontal + Height)
        {
            return false;
        }

        return true;
    }
}