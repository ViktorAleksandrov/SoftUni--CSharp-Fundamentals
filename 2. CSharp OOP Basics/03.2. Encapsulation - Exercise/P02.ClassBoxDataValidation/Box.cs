using System;

public class Box
{
    private const string ErrorMessage = "cannot be zero or negative.";

    private double length;
    private double width;
    private double height;

    public double Length
    {
        get => length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length {ErrorMessage}");
            }

            length = value;
        }
    }

    public double Width
    {
        get => width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width {ErrorMessage}");
            }

            width = value;
        }
    }

    public double Height
    {
        get => height;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height {ErrorMessage}");
            }

            height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double GetSurfaceArea()
    {
        return 2 * length * width + GetLateralSurfaceArea();
    }

    public double GetLateralSurfaceArea()
    {
        return 2 * (length * height + width * height);
    }

    public double GetVolume()
    {
        return length * width * height;
    }

    public override string ToString()
    {
        return $"Surface Area - {GetSurfaceArea():F2}{Environment.NewLine}" +
               $"Lateral Surface Area - {GetLateralSurfaceArea():F2}{Environment.NewLine}" +
               $"Volume - {GetVolume():F2}";
    }
}