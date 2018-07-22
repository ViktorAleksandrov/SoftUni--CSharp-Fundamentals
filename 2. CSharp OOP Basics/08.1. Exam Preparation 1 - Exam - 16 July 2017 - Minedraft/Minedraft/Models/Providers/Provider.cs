using System;
using System.Text;

public abstract class Provider : Machine
{
    private const string ErrorMessage = "Provider is not registered, because of it's {0}";
    private const int MaxEnergyOutput = 10_000;

    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }

        private set
        {
            if (value < 0 || value >= MaxEnergyOutput)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(this.EnergyOutput)));
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder()
            .AppendLine($"{this.Type} Provider - {this.Id}")
            .Append($"Energy Output: {this.EnergyOutput}");

        return result.ToString();
    }
}