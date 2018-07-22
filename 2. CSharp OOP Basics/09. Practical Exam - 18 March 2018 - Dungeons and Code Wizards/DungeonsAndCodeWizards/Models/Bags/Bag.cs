namespace DungeonsAndCodeWizards.Models.Bags
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Items;

    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.capacity = capacity;
            this.items = new List<Item>();
        }

        private int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}