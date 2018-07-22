using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";
    private const string ResultOutput = "Results:";
    private const string SoldiersOutput = "Soldiers:";

    private readonly IWriter writer;
    private readonly MissionController missionController;
    private readonly ISoldierFactory soldierFactory;
    private readonly IMissionFactory missionFactory;
    private IArmy army;
    private IWareHouse wareHouse;
    //private IAmmunitionFactory ammunitionFactory;

    public GameController(IWriter writer)
    {
        this.writer = writer;
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        //this.ammunitionFactory = new AmmunitionFactory();
    }

    public void ProcessCommand(string input)
    {
        var data = input.Split().ToList();

        string commandType = data[0];

        data.RemoveAt(0);

        string commandFullName = CommandPrefix + commandType + CommandSuffix;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[] { data });
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }

    private void ParseWareHouseCommand(IList<string> data)
    {
        string name = data[0];
        int quantity = int.Parse(data[1]);

        this.wareHouse.AddAmmunitions(name, quantity);
    }

    private void ParseSoldierCommand(IList<string> data)
    {
        if (data[0] == RegenerateCommand)
        {
            this.army.RegenerateTeam(data[1]);
        }
        else
        {
            this.AddSoldierToArmy(data);
        }
    }

    private void AddSoldierToArmy(IList<string> data)
    {
        string type = data[0];
        string name = data[1];
        int age = int.Parse(data[2]);
        double experience = double.Parse(data[3]);
        double endurance = double.Parse(data[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseMissionCommand(IList<string> data)
    {
        string difficultyLevel = data[0];
        double scoreToComplete = double.Parse(data[1]);
        IMission mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.StoreMessage(this.missionController.PerformMission(mission));
    }

    public void ProduceSummary()
    {
        var orderedArmy = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.writer.StoreMessage(ResultOutput);

        this.writer.StoreMessage(
            string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));

        this.writer.StoreMessage(
            string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));

        this.writer.StoreMessage(SoldiersOutput);

        foreach (ISoldier soldier in orderedArmy)
        {
            this.writer.StoreMessage(soldier.ToString());
        }
    }
}
