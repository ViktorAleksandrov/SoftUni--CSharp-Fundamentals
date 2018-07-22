using System;
using System.Text;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }

    private string Author
    {
        get => author;

        set
        {
            var names = value.Split();

            if (names.Length == 2 && char.IsDigit(names[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            author = value;
        }
    }

    private string Title
    {
        get => title;

        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }

            title = value;
        }
    }

    protected virtual decimal Price
    {
        get => price;

        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            price = value;
        }
    }

    public override string ToString()
    {
        return new StringBuilder()
            .AppendLine($"Type: {GetType()}")
            .AppendLine($"Title: {Title}")
            .AppendLine($"Author: {Author}")
            .Append($"Price: {Price:F2}")
            .ToString();
    }
}