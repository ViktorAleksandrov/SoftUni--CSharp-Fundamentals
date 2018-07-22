using System.Collections.Generic;
using System.Text;
using Logger.Contracts;

namespace Logger.Models
{
    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.ReportLevel <= error.ReportLevel)
                {
                    string formattedError = appender.Layout.FormatError(error);

                    appender.Append(formattedError);
                }
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine("Logger info");

            foreach (IAppender appender in this.appenders)
            {
                result.AppendLine(appender.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}