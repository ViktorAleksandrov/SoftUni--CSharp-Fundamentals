namespace P03.WildFarm.Models.Animals.Mammals
{
    abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        protected string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString() + "{0}" + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}