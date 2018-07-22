using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int numberOfLaps = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(numberOfLaps, trackLength);

        while (this.raceTower.IsRaceOver == false)
        {
            var commandArgs = Console.ReadLine().Split().ToList();

            string command = commandArgs[0];

            commandArgs.Remove(command);

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    string output = this.raceTower.CompleteLaps(commandArgs);
                    if (output != string.Empty)
                    {
                        Console.WriteLine(output);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandArgs);
                    break;
            }
        }
    }
}