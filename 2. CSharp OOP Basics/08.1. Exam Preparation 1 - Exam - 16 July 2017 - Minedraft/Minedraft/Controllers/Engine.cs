using System;
using System.Linq;

public class Engine
{
    private bool isRunning;
    private DraftManager draftManager;

    public Engine()
    {
        this.isRunning = true;
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var arguments = Console.ReadLine().Split().ToList();

            string command = arguments[0];

            arguments.Remove(command);

            string output = null;

            switch (command)
            {
                case "RegisterHarvester":
                    output = this.draftManager.RegisterHarvester(arguments);
                    break;
                case "RegisterProvider":
                    output = this.draftManager.RegisterProvider(arguments);
                    break;
                case "Day":
                    output = this.draftManager.Day();
                    break;
                case "Mode":
                    output = this.draftManager.Mode(arguments);
                    break;
                case "Check":
                    output = this.draftManager.Check(arguments);
                    break;
                case "Shutdown":
                    output = this.draftManager.ShutDown();
                    this.isRunning = false;
                    break;
            }

            Console.WriteLine(output);
        }
    }
}