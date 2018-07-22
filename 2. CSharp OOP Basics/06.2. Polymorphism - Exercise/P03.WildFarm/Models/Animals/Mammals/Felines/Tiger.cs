namespace P03.WildFarm.Models.Animals.Mammals.Felines
{
    using Foods;
    using System;

    class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed) { }

        protected override double FoodPieceMultiplier => 1;

        protected override Type[] AllowedFoods => new Type[] { typeof(Meat) };

        public override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}