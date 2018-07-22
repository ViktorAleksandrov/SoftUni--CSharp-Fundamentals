using System;
using Logger.Contracts;
using Logger.Factories;

namespace Logger
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                string[] errorArgs = inputLine.Split('|');

                string reportLevelType = errorArgs[0];
                string dateTimeString = errorArgs[1];
                string message = errorArgs[2];

                IError error = this.errorFactory.CreateError(dateTimeString, reportLevelType, message);

                this.logger.Log(error);
            }

            Console.WriteLine(this.logger);
        }
    }
}