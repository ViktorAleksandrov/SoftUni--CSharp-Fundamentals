using System;
using Logger.Contracts;

namespace Logger.Models.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
            : base(layout, reportLevel)
        {
        }

        public override void Append(string formattedError)
        {
            Console.WriteLine(formattedError);

            this.MessagesCounter++;
        }
    }
}