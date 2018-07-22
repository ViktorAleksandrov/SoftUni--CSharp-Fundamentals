using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.mode = Constants.DefaultMode;
        this.harvesters = new List<IHarvester>();
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters.AsReadOnly();

    public string ChangeMode(string mode)
    {
        this.mode = mode;

        var brokenHarvesters = new List<IHarvester>();

        foreach (IHarvester harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch
            {
                brokenHarvesters.Add(harvester);
            }
        }

        foreach (IHarvester entity in brokenHarvesters)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }

    public string Produce()
    {
        double neededEnergy = this.harvesters.Sum(h => h.EnergyRequirement);

        if (this.mode == "Half")
        {
            neededEnergy *= 0.5;
        }
        else if (this.mode == "Energy")
        {
            neededEnergy *= 0.2;
        }

        double minedOres = 0;

        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            minedOres = this.harvesters.Sum(h => h.Produce());

            if (this.mode == "Half")
            {
                minedOres *= 0.5;
            }
            else if (this.mode == "Energy")
            {
                minedOres *= 0.2;
            }

            this.OreProduced += minedOres;
        }

        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);

        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }
}
