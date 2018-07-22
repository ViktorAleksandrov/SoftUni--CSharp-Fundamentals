namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }

        protected string Breed { get; private set; }

        public override string ToString()
        {
            return string.Format(base.ToString(), $"{this.Breed}, ");
        }
    }
}