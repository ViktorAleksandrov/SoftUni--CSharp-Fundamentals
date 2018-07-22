namespace Travel.Entities.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Items.Contracts;

    public class ItemFactory : IItemFactory
    {
        public IItem CreateItem(string type)
        {
            Type itemType = Assembly.GetCallingAssembly().GetTypes()
                .First(t => t.Name == type);

            var item = (IItem)Activator.CreateInstance(itemType);

            return item;
        }
    }
}
