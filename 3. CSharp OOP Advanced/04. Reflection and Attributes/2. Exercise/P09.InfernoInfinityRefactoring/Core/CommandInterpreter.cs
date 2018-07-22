using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using P09.InfernoInfinityRefactoring.Attributes;
using P09.InfernoInfinityRefactoring.Contracts;

namespace P09.InfernoInfinityRefactoring.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            string commandFullName = commandName + CommandSuffix;

            Type commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(t => t.Name == commandFullName);

            object[] constructorParams = this.GetConstructorParams(commandType, data);

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, constructorParams);

            return commandInstance;
        }

        private object[] GetConstructorParams(Type commandType, IEnumerable data)
        {
            FieldInfo[] fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null)
                .ToArray();

            object[] injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType))
                .ToArray();

            object[] constructorParams = new object[] { data }.Concat(injectArgs).ToArray();

            return constructorParams;
        }
    }
}
