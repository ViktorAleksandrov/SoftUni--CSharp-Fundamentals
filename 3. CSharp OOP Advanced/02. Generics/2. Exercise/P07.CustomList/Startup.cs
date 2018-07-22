namespace P07.CustomList
{
    class Startup
    {
        static void Main()
        {
            var commandInterpreter = new CommandInterpreter();

            commandInterpreter.ParseCommands();
        }
    }
}