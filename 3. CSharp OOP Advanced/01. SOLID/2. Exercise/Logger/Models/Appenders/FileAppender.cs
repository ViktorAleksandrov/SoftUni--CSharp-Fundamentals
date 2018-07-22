using Logger.Contracts;

namespace Logger.Models.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ReportLevel reportLevel, ILogFile logFile)
            : base(layout, reportLevel)
        {
            this.logFile = logFile;
        }

        public override void Append(string formattedError)
        {
            this.logFile.Write(formattedError);

            this.MessagesCounter++;
        }

        public override string ToString()
        {
            string result = base.ToString() + $", File size {this.logFile.Size}";

            return result;
        }
    }
}