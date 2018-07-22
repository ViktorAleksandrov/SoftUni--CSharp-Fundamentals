using System;
using System.Text;

public abstract class Harvester : Machine
{
    private const string ErrorMessage = "Harvester is not registered, because of it's {0}";
    private const int MaxEnergyRequirement = 20_000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(this.OreOutput)));
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }

        protected set
        {
            if (value < 0 || value > MaxEnergyRequirement)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(this.EnergyRequirement)));
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder()
            .AppendLine($"{this.Type} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.OreOutput}")
            .Append($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString();
    }
}