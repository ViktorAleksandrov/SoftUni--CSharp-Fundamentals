public class Rectangle : Shape
{
	public Rectangle(double height, double width)
	{
		this.Height = height;
		this.Width = width;
	}

	public double Height { get; set; }

	public double Width { get; set; }

	public override double CalculatePerimeter()
	{
		double perimeter = (this.Height + this.Width) * 2;

		return perimeter;
	}

	public override double CalculateArea()
	{
		double area = this.Height * this.Width;

		return area;
	}

	public override string Draw()
	{
		string result = base.Draw() + "Rectangle";

		return result;
	}
}