using System.Collections.Generic;

using NUnit.Framework;

public class ProviderControllerTests
{
    private ProviderController providerController;
    private EnergyRepository energyRepository;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProduceCorrectEnergyOutput()
    {
        var firstSolarProvider = new List<string> { "Solar", "1", "100" };

        var secondSolarProvider = new List<string> { "Solar", "2", "100" };

        this.providerController.Register(firstSolarProvider);
        this.providerController.Register(secondSolarProvider);

        this.providerController.Produce();

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(200));
    }

    [Test]
    public void BrokenProviderIsRemoved()
    {
        var provider = new List<string> { "Pressure", "1", "100" };

        this.providerController.Register(provider);

        for (int i = 0; i < 10; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.Entities.Count, Is.EqualTo(0));
    }
}
