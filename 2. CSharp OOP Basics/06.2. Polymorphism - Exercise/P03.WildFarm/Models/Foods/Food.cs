namespace P03.WildFarm.Models.Foods
{
    abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}