using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public IProviderController ProviderController { get; private set; }

    public string ProcessCommand(IList<string> args)
    {
        ICommand command = this.CreateCommand(args);

        string output = command.Execute();

        return output;
    }

    private ICommand CreateCommand(IList<string> args)
    {
        string commandName = args[0];

        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandName + "Command");

        ParameterInfo[] ctorParams = commandType.GetConstructors()
            .First()
            .GetParameters();

        object[] parameters = new object[ctorParams.Length];

        for (int index = 0; index < parameters.Length; index++)
        {
            Type paramType = ctorParams[index].ParameterType;

            if (paramType == typeof(IList<string>))
            {
                parameters[index] = args.Skip(1).ToList();
            }
            else
            {
                PropertyInfo param = this.GetType().GetProperties()
                    .FirstOrDefault(p => p.PropertyType == paramType);

                parameters[index] = param.GetValue(this);
            }
        }

        var command = (ICommand)Activator.CreateInstance(commandType, parameters);

        return command;
    }
}
