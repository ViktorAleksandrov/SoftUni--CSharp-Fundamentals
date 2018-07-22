using System;
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public IReadOnlyCollection<Person> FirstTeam => firstTeam;

    public IReadOnlyCollection<Person> ReserveTeam => reserveTeam;

    public Team(string name)
    {
        this.name = name;
        firstTeam = new List<Person>();
        reserveTeam = new List<Person>();
    }

    public void AddPlayer(Person player)
    {
        if (player.Age < 40)
        {
            firstTeam.Add(player);
        }
        else
        {
            reserveTeam.Add(player);
        }
    }

    public override string ToString()
    {
        return $"First team has {FirstTeam.Count} players.{Environment.NewLine}" +
               $"Reserve team has {ReserveTeam.Count} players.";
    }
}