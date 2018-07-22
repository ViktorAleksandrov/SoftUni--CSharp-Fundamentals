namespace P03.WildFarm.Models.Animals.Birds
{
    using Foods;
    using System;

    class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize) { }

        protected override double FoodPieceMultiplier => 0.35;

        protected override Type[] AllowedFoods =>
            new Type[] { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}