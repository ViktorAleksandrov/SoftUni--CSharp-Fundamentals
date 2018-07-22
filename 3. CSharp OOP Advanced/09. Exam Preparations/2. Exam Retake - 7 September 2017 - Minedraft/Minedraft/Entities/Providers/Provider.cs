using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000.0;
    private const int DurabilityLoss = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability
    {
        get => this.durability;

        protected set
        {
            if (value < 0)
            {
                throw new Exception();
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= DurabilityLoss;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + nameof(this.Durability) + $": {this.Durability}";
    }
}
