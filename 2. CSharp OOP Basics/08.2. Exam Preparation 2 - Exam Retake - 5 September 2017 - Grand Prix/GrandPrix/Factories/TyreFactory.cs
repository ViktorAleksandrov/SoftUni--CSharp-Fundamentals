using System;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        string tyreName = tyreArgs[0];
        double hardness = double.Parse(tyreArgs[1]);

        switch (tyreName)
        {
            case "Ultrasoft":
                double grip = double.Parse(tyreArgs[2]);
                return new UltrasoftTyre(hardness, grip);
            case "Hard":
                return new HardTyre(hardness);
            default:
                throw new ArgumentException();
        }
    }
}