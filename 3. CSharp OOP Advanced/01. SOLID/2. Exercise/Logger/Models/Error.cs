using System;
using Logger.Contracts;

namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Message = message;
        }

        public DateTime DateTime { get; }

        public ReportLevel ReportLevel { get; }

        public string Message { get; }
    }
}