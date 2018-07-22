using System;
using Logger.Contracts;
using Logger.Models.Appenders;

namespace Logger.Factories
{
    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string reportLevelType, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            var reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelType);

            IAppender appender = null;

            switch (appenderType)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout, reportLevel);
                    break;
                case nameof(FileAppender):
                    ILogFile logFile = new LogFile();
                    appender = new FileAppender(layout, reportLevel, logFile);
                    break;
            }

            return appender;
        }
    }
}