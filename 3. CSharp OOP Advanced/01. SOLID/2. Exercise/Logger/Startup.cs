namespace Logger
{
    using System;
    using Logger.Contracts;
    using Logger.Factories;
    using Logger.Models;

    public class Program
    {
        static void Main()
        {
            ILogger logger = InitializeILogger();

            var errorFactory = new ErrorFactory();

            var engine = new Engine(logger, errorFactory);
            engine.Run();
        }

        static ILogger InitializeILogger()
        {
            int appenderCount = int.Parse(Console.ReadLine());

            var appenders = new IAppender[appenderCount];
            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory(layoutFactory);

            for (int index = 0; index < appenderCount; index++)
            {
                string[] appenderArgs = Console.ReadLine().Split();

                string appenderType = appenderArgs[0];
                string layoutType = appenderArgs[1];
                string reportLevelType = "INFO";

                if (appenderArgs.Length == 3)
                {
                    reportLevelType = appenderArgs[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appenderType, reportLevelType, layoutType);
                appenders[index] = appender;
            }

            ILogger logger = new Logger(appenders);

            return logger;
        }
    }
}