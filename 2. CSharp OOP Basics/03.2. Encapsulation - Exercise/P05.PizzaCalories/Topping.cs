using System;
using System.Collections.Generic;

public class Topping
{
    private const string INVALID_TYPE = "Cannot place {0} on top of your pizza.";
    private const string INVALID_WEIGHT = "{0} weight should be in the range [{1}..{2}].";
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int BASE_MULTIPLIER = 2;

    private Dictionary<string, double> validToppings = new Dictionary<string, double>
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sauce"] = 0.9
    };

    private string type;
    private int weight;

    private string Type
    {
        get => type;

        set
        {
            if (validToppings.ContainsKey(value.ToLower()) == false)
            {
                throw new ArgumentException(string.Format(INVALID_TYPE, value));
            }

            type = value;
        }
    }

    private int Weight
    {
        get => weight;

        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException(string.Format(INVALID_WEIGHT, Type, MIN_WEIGHT, MAX_WEIGHT));
            }

            weight = value;
        }
    }

    private double ToppingMultiplier => validToppings[Type.ToLower()];

    public double Calories => BASE_MULTIPLIER * Weight * ToppingMultiplier;

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }
}