using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int totalLapsNumber;
    private int trackLength;
    private int currentLap;
    private string weather;
    private IList<Driver> racingDrivers;
    private Stack<Driver> failedDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;

    public RaceTower()
    {
        this.weather = "Sunny";
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.racingDrivers = new List<Driver>();
        this.failedDrivers = new Stack<Driver>();
    }

    public bool IsRaceOver => this.currentLap == this.totalLapsNumber;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLapsNumber = lapsNumber;
        this.trackLength = trackLength;
        this.currentLap = 0;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            string[] tyreArgs = commandArgs.Skip(4).ToArray();
            Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);

            int hp = int.Parse(commandArgs[2]);
            double fuelAmount = double.Parse(commandArgs[3]);
            var car = new Car(hp, fuelAmount, tyre);

            string driverType = commandArgs[0];
            string driverName = commandArgs[1];
            Driver driver = this.driverFactory.CreateDriver(driverType, driverName, car);

            this.racingDrivers.Add(driver);
        }
        catch { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string boxReason = commandArgs[0];
        string driverName = commandArgs[1];

        Driver driver = this.racingDrivers.First(d => d.Name == driverName);

        driver.Box();

        if (boxReason == "ChangeTyres")
        {
            string[] tyreArgs = commandArgs.Skip(2).ToArray();

            Tyre tyre = this.tyreFactory.CreateTyre(tyreArgs);

            driver.Car.ChangeTyres(tyre);
        }
        else if (boxReason == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);

            driver.Car.Refuel(fuelAmount);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int lapsToProgress = int.Parse(commandArgs[0]);

        if (lapsToProgress > this.totalLapsNumber - this.currentLap)
        {
            return string.Format(OutputMessages.InvalidLapsCount, this.currentLap);
        }

        var output = new StringBuilder();

        for (int lap = 0; lap < lapsToProgress; lap++)
        {
            this.currentLap++;

            for (int index = 0; index < this.racingDrivers.Count; index++)
            {
                Driver driver = this.racingDrivers[index];

                try
                {
                    driver.CompleteLap(this.trackLength);
                }
                catch (ArgumentException ex)
                {
                    driver.FailureReason = ex.Message;

                    this.failedDrivers.Push(driver);
                    this.racingDrivers.RemoveAt(index);

                    index--;
                }
            }

            var orderedDrivers = this.racingDrivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int index = 0; index < orderedDrivers.Count - 1; index++)
            {
                Driver overtakingDriver = orderedDrivers[index];
                Driver overtakenDriver = orderedDrivers[index + 1];

                bool hasCrash = false;

                bool hasOvertake = this.TryOvertake(overtakingDriver, overtakenDriver, ref hasCrash);

                if (hasOvertake)
                {
                    index++;

                    output.AppendLine(string.Format(
                        OutputMessages.OvertakeMessage, overtakingDriver.Name, overtakenDriver.Name, this.currentLap));
                }
                else if (hasCrash)
                {
                    this.failedDrivers.Push(overtakingDriver);
                    this.racingDrivers.Remove(overtakingDriver);
                }
            }
        }

        if (this.IsRaceOver)
        {
            Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();

            output.AppendLine(string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime));
        }

        return output.ToString().TrimEnd();
    }

    private bool TryOvertake(Driver overtakingDriver, Driver overtakenDriver, ref bool hasCrash)
    {
        double timeDiff = overtakingDriver.TotalTime - overtakenDriver.TotalTime;

        bool hasAggressiveCondition = overtakingDriver is AggressiveDriver &&
                                      overtakingDriver.Car.Tyre is UltrasoftTyre;

        bool hasEnduranceCondition = overtakingDriver is EnduranceDriver &&
                                     overtakingDriver.Car.Tyre is HardTyre;

        bool hasCrashCondition = (hasAggressiveCondition && this.weather == "Foggy") ||
                          (hasEnduranceCondition && this.weather == "Rainy");

        if ((hasAggressiveCondition || hasEnduranceCondition) && timeDiff <= 3)
        {
            if (hasCrashCondition)
            {
                overtakingDriver.FailureReason = OutputMessages.Crashed;
                hasCrash = true;

                return false;
            }

            overtakingDriver.TotalTime -= 3;
            overtakenDriver.TotalTime += 3;
            return true;
        }
        else if (timeDiff <= 2)
        {
            overtakingDriver.TotalTime -= 2;
            overtakenDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        var output = new StringBuilder();

        output.AppendLine($"Lap {this.currentLap}/{this.totalLapsNumber}");

        int position = 1;

        foreach (Driver driver in this.racingDrivers.OrderBy(d => d.TotalTime))
        {
            output.AppendLine($"{position++} {driver.Name} {driver.TotalTime:F3}");
        }

        foreach (Driver driver in this.failedDrivers)
        {
            output.AppendLine($"{position++} {driver.Name} {driver.FailureReason}");
        }

        return output.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }
}