using System;
using System.Collections.Generic;

public class Dough
{
    private const string INVALID_TYPE = "Invalid type of dough.";
    private const string INVALID_WEIGHT = "Dough weight should be in the range [{0}..{1}].";
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const int BASE_MULTIPLIER = 2;

    private Dictionary<string, double> validFlourTypes = new Dictionary<string, double>
    {
        ["white"] = 1.5,
        ["wholegrain"] = 1.0
    };

    private Dictionary<string, double> validBakingTechniques = new Dictionary<string, double>
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private string flourType;
    private string bakingTechnique;
    private int weight;

    private string FlourType
    {
        get => flourType;

        set
        {
            ValidateTypes(value, validFlourTypes);

            flourType = value.ToLower();
        }
    }

    private string BakingTechnique
    {
        get => bakingTechnique;

        set
        {
            ValidateTypes(value, validBakingTechniques);

            bakingTechnique = value.ToLower();
        }
    }

    private int Weight
    {
        get => weight;

        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException(string.Format(INVALID_WEIGHT, MIN_WEIGHT, MAX_WEIGHT));
            }

            weight = value;
        }
    }

    private double FlourMultiplier => validFlourTypes[FlourType];

    private double BakingTechniqueMultiplier => validBakingTechniques[BakingTechnique];

    public double Calories => BASE_MULTIPLIER * Weight * FlourMultiplier * BakingTechniqueMultiplier;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    private void ValidateTypes(string type, Dictionary<string, double> validTypes)
    {
        if (validTypes.ContainsKey(type.ToLower()) == false)
        {
            throw new ArgumentException(INVALID_TYPE);
        }
    }
}