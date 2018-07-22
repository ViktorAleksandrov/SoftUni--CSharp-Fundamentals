namespace P08.CustomListSorter
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