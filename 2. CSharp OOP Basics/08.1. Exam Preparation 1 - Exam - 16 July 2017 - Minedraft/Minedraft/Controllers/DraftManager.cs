using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = "Full";
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = this.harvesterFactory.CreateHarvester(arguments);
            this.harvesters.Add(harvester);

            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = this.providerFactory.CreateProvider(arguments);
            this.providers.Add(provider);

            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        double dailyProvidedEnergy = this.providers.Sum(p => p.EnergyOutput);
        this.totalStoredEnergy += dailyProvidedEnergy;

        double requiredEnergy = this.harvesters.Sum(h => h.EnergyRequirement);
        double dailyMinedOre = this.harvesters.Sum(h => h.OreOutput);

        if (this.mode == "Half")
        {
            requiredEnergy *= 0.6;
            dailyMinedOre *= 0.5;
        }

        if (this.mode != "Energy" && this.totalStoredEnergy >= requiredEnergy)
        {
            this.totalStoredEnergy -= requiredEnergy;
            this.totalMinedOre += dailyMinedOre;
        }
        else
        {
            dailyMinedOre = 0;
        }

        StringBuilder output = new StringBuilder()
            .AppendLine("A day has passed.")
            .AppendLine($"Energy Provided: {dailyProvidedEnergy}")
            .Append($"Plumbus Ore Mined: {dailyMinedOre}");

        return output.ToString();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        Machine machine = (Machine)this.harvesters.FirstOrDefault(h => h.Id == id)
            ?? this.providers.FirstOrDefault(p => p.Id == id);

        if (machine != null)
        {
            return machine.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder output = new StringBuilder()
            .AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return output.ToString();
    }
}