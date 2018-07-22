public class DrawingTool
{
    public DrawingTool(Quadrangle quadrangle)
    {
        Quadrangle = quadrangle;
    }

    public Quadrangle Quadrangle { get; set; }

    public void Draw()
    {
        Quadrangle.Draw();
    }
}