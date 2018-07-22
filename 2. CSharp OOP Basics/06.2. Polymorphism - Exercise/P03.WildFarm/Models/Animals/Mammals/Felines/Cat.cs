namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;
    using System;

    class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override double FoodPieceMultiplier => 0.3;

        protected override Type[] AllowedFoods => new Type[] { typeof(Vegetable), typeof(Meat) };

        public override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}