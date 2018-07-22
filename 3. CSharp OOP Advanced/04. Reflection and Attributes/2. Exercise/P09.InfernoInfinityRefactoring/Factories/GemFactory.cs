using System;
using System.Linq;
using System.Reflection;
using P09.InfernoInfinityRefactoring.Contracts;
using P09.InfernoInfinityRefactoring.Enums;

namespace P09.InfernoInfinityRefactoring.Factories
{
    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType, string clarityType)
        {
            var assembly = Assembly.GetCallingAssembly();

            Type classType = assembly.GetTypes().First(t => t.Name == gemType);

            GemClarity clarity = Enum.Parse<GemClarity>(clarityType);

            var instance = (IGem)Activator.CreateInstance(classType, clarity);

            return instance;
        }
    }
}
