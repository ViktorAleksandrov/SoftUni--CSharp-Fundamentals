using System;
using System.Collections.Generic;
using System.Text;

public class Player
{
    private const string INVALID_NAME = "A name should not be empty.";
    private const string INVALID_STATS = "{0} should be between {1} and {2}.";
    private const int MIN_STATS = 0;
    private const int MAX_STATS = 100;

    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

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

    private int Endurance
    {
        get => endurance;

        set
        {
            ValidateStats(value, nameof(Endurance));

            endurance = value;
        }
    }

    private int Sprint
    {
        get => sprint;

        set
        {
            ValidateStats(value, nameof(Sprint));

            sprint = value;
        }
    }

    private int Dribble
    {
        get => dribble;

        set
        {
            ValidateStats(value, nameof(Dribble));

            dribble = value;
        }
    }

    private int Passing
    {
        get => passing;

        set
        {
            ValidateStats(value, nameof(Passing));

            passing = value;
        }
    }

    private int Shooting
    {
        get => shooting;

        set
        {
            ValidateStats(value, nameof(Shooting));

            shooting = value;
        }
    }

    public double SkillLevel => (Endurance + Sprint + Dribble + Passing + Shooting) / 5.0;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        Name = name;
        Endurance = endurance;
        Sprint = sprint;
        Dribble = dribble;
        Passing = passing;
        Shooting = shooting;
    }

    private void ValidateStats(int value, string stat)
    {
        if (value < MIN_STATS || value > MAX_STATS)
        {
            throw new ArgumentException(string.Format(INVALID_STATS, stat, MIN_STATS, MAX_STATS));
        }
    }
}