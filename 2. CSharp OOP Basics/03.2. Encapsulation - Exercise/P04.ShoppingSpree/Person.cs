using System;
using System.Collections.Generic;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> productsBag;

    public string Name
    {
        get => name;

        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    private decimal Money
    {
        get => money;

        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        productsBag = new List<Product>();
    }

    public void TryBuyProduct(Product product)
    {
        string affordOrNot;

        if (Money >= product.Cost)
        {
            Money -= product.Cost;

            productsBag.Add(product);

            affordOrNot = "bought";
        }
        else
        {
            affordOrNot = "can't afford";
        }

        Console.WriteLine($"{Name} {affordOrNot} {product.Name}");
    }

    public override string ToString()
    {
        string purchaseOrNot;

        if (productsBag.Count > 0)
        {
            purchaseOrNot = string.Join(", ", productsBag);
        }
        else
        {
            purchaseOrNot = "Nothing bought";
        }

        return $"{Name} - {purchaseOrNot}";
    }
}