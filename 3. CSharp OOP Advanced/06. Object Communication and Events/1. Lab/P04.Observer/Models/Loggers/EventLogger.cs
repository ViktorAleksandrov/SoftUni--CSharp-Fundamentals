using System;

public class EventLogger : Logger
{
    public override void Handle(LogType type, string message)
    {
        switch (type)
        {
            case LogType.TARGET:
                Console.WriteLine($"{type}: {message}");
                break;
            case LogType.ERROR:
                Console.WriteLine($"{type}: {message}");
                break;
            case LogType.EVENT:
                Console.WriteLine($"{type}: {message}");
                break;
        }

        this.PassToSuccessor(type, message);
    }
}
