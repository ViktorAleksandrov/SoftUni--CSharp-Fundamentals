namespace P03.WildFarm.Models.Animals.Mammals
{
    using Foods;
    using System;

    class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion) { }

        protected override double FoodPieceMultiplier => 0.1;

        protected override Type[] AllowedFoods => new Type[] { typeof(Vegetable), typeof(Fruit) };

        public override void ProduceSound()
        {
            Console.WriteLine("Squeak");
        }

        public override string ToString()
        {
            return string.Format(base.ToString(), string.Empty);
        }
    }
}