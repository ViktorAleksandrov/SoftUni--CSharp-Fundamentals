namespace P03.WildFarm.Models.Animals.Birds
{
    using Foods;
    using System;

    class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        protected override double FoodPieceMultiplier => 0.25;

        protected override Type[] AllowedFoods => new Type[] { typeof(Meat) };

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}