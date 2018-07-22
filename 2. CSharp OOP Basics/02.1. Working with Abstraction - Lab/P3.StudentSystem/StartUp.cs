using System;

class StartUp
{
    static void Main()
    {
        var studentSystem = new StudentSystem();

        while (true)
        {
            var commandArgs = Console.ReadLine().Split();

            if (commandArgs[0] == "Exit")
            {
                break;
            }

            studentSystem.ParseCommand(commandArgs);
        }
    }
}