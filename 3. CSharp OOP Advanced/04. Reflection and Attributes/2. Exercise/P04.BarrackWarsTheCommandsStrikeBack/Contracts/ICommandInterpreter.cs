namespace P04.BarrackWarsTheCommandsStrikeBack.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string[] data, string commandName);
    }
}
