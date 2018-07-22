using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const string INVALID_LENGTH = "Pizza name should be between {0} and {1} symbols.";
    private const string INVALID_TOPPINGS_NUMBER = "Number of toppings should be in range [{0}..{1}].";
    private const int MIN_LENGTH = 1;
    private const int MAX_LENGTH = 15;
    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;

    private string name;

    public string Name
    {
        get => name;

        private set
        {
            if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
            {
                throw new ArgumentException(string.Format(INVALID_LENGTH, MIN_LENGTH, MAX_LENGTH));
            }

            name = value;
        }
    }

    public Dough Dough { get; set; }

    private List<Topping> Toppings { get; set; }

    private double ToppingsCalories => Toppings.Sum(t => t.Calories);

    public double TotalCalories => Dough.Calories + ToppingsCalories;

    public Pizza(string name)
    {
        Name = name;
        Toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        if (Toppings.Count == MAX_TOPPINGS)
        {
            throw new ArgumentException(string.Format(INVALID_TOPPINGS_NUMBER, MIN_TOPPINGS, MAX_TOPPINGS));
        }

        Toppings.Add(topping);
    }
}