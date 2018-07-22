using Logger.Contracts;

namespace Logger.Models.Appenders
{
    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.MessagesCounter = 0;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; }

        public int MessagesCounter { get; protected set; }

        public abstract void Append(string formattedError);

        public override string ToString()
        {
            string result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                            $"Report level: {this.ReportLevel}, Messages appended: {this.MessagesCounter}";

            return result;
        }
    }
}