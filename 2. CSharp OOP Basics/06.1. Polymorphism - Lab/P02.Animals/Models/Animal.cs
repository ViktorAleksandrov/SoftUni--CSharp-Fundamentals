﻿public abstract class Animal
{
	protected Animal(string name, string favouriteFood)
	{
		this.Name = name;
		this.FavouriteFood = favouriteFood;
	}

	public string Name { get; protected set; }

	public string FavouriteFood { get; protected set; }

	public virtual string ExplainSelf()
	{
		string result = $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";

		return result;
	}
}