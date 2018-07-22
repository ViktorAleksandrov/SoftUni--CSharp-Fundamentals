﻿public class PressureProvider : Provider
{
    private const double EnergyOutputMultiplier = 1.5;

    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput * EnergyOutputMultiplier)
    {
    }

    public override string Type => "Pressure";
}