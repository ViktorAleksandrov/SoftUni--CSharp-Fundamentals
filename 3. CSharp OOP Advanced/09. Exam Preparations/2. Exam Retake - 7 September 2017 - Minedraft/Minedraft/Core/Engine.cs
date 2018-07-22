public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        while (true)
        {
            string[] inputArgs = this.reader.ReadLine().Split();

            string result = this.commandInterpreter.ProcessCommand(inputArgs);

            this.writer.WriteLine(result);

            if (inputArgs[0] == Constants.EndCommand)
            {
                break;
            }
        }
    }
}
