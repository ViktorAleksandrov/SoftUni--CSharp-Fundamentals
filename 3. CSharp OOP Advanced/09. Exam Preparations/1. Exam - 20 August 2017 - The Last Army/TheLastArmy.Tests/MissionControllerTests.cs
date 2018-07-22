using NUnit.Framework;

public class MissionControllerTests
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void ArmyInit()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();

        this.missionController = new MissionController(this.army, this.wareHouse);
    }

    [Test]
    public void MisssionControllerDisplaysFailMessage()
    {
        var mission = new Easy(1);

        string result = string.Empty;

        for (int i = 0; i < 4; i++)
        {
            result = this.missionController.PerformMission(mission);
        }

        Assert.IsTrue(result.Contains("declined"));
    }

    [Test]
    public void MisssionControllerDisplaysSuccessMessage()
    {
        var mission = new Easy(0);

        string result = this.missionController.PerformMission(mission);

        Assert.IsTrue(result.Contains("completed"));
    }
}
