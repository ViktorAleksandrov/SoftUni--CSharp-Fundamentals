namespace P03.WildFarm.Models.Animals.Mammals
{
    using Foods;
    using System;

    class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override double FoodPieceMultiplier => 0.4;

        protected override Type[] AllowedFoods => new Type[] { typeof(Meat) };

        public override void ProduceSound()
        {
            Console.WriteLine("Woof!");
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), string.Empty);
        }
    }
}