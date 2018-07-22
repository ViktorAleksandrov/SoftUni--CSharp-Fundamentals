namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;
    using System.Linq;

    abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        protected string Name { get; private set; }

        protected double Weight { get; set; }

        protected int FoodEaten { get; set; }

        protected abstract double FoodPieceMultiplier { get; }

        protected abstract Type[] AllowedFoods { get; }

        public abstract void ProduceSound();

        public void Eat(Food food)
        {
            Type foodType = food.GetType();

            if (this.AllowedFoods.Contains(foodType) == false)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {foodType.Name}!");
            }

            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * this.FoodPieceMultiplier;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}