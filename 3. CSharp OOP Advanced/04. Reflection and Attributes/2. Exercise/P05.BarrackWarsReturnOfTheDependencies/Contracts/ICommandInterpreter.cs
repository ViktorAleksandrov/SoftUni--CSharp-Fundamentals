namespace P05.BarrackWarsReturnOfTheDependencies.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
