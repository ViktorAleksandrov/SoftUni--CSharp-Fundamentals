namespace P09.CustomListIterator
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