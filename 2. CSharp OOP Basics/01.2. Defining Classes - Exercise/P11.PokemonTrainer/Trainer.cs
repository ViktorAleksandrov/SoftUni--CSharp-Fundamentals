using System.Collections.Generic;

public class Trainer
{
    public Trainer(string name)
    {
        Name = name;
        Pokemons = new List<Pokemon>();
    }

    public string Name { get; set; }
    public int BadgesAmount { get; set; }
    public List<Pokemon> Pokemons { get; set; }

    public override string ToString()
    {
        return $"{Name} {BadgesAmount} {Pokemons.Count}";
    }
}