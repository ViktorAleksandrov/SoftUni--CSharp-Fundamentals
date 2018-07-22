namespace FestivalManager.Entities.Factories
{
    using System;

    using Contracts;
    using Entities.Contracts;

    public class PerformerFactory : IPerformerFactory
    {
        public IPerformer CreatePerformer(string name, int age)
        {
            var performer = (IPerformer)Activator.CreateInstance(typeof(Performer), name, age);

            return performer;
        }
    }
}