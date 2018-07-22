using System;
using System.Linq;
using System.Reflection;
using P04.BarrackWarsTheCommandsStrikeBack.Contracts;

namespace P04.BarrackWarsTheCommandsStrikeBack.Core
{
    public class CommandIntrepreter : ICommandInterpreter
    {
        private const string Suffix = "command";

        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandIntrepreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + Suffix);

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            object[] ctorParams = new object[] { data, this.repository, this.unitFactory };

            var commandInstance = (IExecutable)Activator.CreateInstance(commandType, ctorParams);

            return commandInstance;
        }
    }
}
