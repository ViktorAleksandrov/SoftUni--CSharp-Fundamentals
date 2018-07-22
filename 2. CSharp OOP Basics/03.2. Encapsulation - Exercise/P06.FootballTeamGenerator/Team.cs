using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private const string INVALID_NAME = "A name should not be empty.";
    private const string INVALID_PLAYER = "Player {0} is not in {1} team.";

    private string name;

    public string Name
    {
        get => name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(INVALID_NAME);
            }

            name = value;
        }
    }

    private List<Player> Players { get; set; }

    public int Rating
    {
        get
        {
            if (Players.Count == 0)
            {
                return 0;
            }

            return (int)Math.Round(Players.Average(p => p.SkillLevel));
        }
    }

    public Team(string name)
    {
        Name = name;
        Players = new List<Player>();
    }

    public void AddPlayer(Player player)
    {
        Players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var player = Players.FirstOrDefault(p => p.Name == playerName);

        if (player == null)
        {
            throw new ArgumentException(string.Format(INVALID_PLAYER, playerName, Name));
        }

        Players.Remove(player);
    }

    public override string ToString()
    {
        return $"{Name} - {Rating}";
    }
}