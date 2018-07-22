namespace P04.BarrackWarsTheCommandsStrikeBack.Core.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var assembly = Assembly.GetCallingAssembly();

            Type type = assembly.GetTypes().First(t => t.Name == unitType);

            var instance = (IUnit)Activator.CreateInstance(type);

            return instance;
        }
    }
}
