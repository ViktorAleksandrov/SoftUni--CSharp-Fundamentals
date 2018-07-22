using System;

public class UltrasoftTyre : Tyre
{
    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base("Ultrasoft", hardness)
    {
        this.grip = grip;
    }

    public override double Degradation
    {
        get => base.Degradation;

        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(OutputMessages.BlownTyre);
            }

            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        base.ReduceDegradation();

        this.Degradation -= this.grip;
    }
}