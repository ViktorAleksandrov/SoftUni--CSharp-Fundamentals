using System;
using System.Linq;
using System.Reflection;
using P05.BarrackWarsReturnOfTheDependencies.Attributes;
using P05.BarrackWarsReturnOfTheDependencies.Contracts;

namespace P05.BarrackWarsReturnOfTheDependencies.Core
{
    public class CommandIntrepreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IServiceProvider serviceProvider;

        public CommandIntrepreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + Suffix);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes.Any(a => a.AttributeType == typeof(InjectAttribute)))
                .ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] ctorParams = new object[] { data }.Concat(injectArgs).ToArray();

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, ctorParams);

            return commandInstance;
        }
    }
}
