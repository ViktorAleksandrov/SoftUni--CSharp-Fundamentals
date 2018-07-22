namespace DungeonsAndCodeWizards.Factories
{
    using System;
    using Models.Items;

    public class ItemFactory
    {
        public Item CreateItem(string itemName)
        {
            switch (itemName)
            {
                case "HealthPotion":
                    return new HealthPotion();
                case "PoisonPotion":
                    return new PoisonPotion();
                case "ArmorRepairKit":
                    return new ArmorRepairKit();
                default:
                    throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }
        }
    }
}