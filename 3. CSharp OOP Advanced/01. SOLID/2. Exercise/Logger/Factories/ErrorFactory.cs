using System;
using System.Globalization;
using Logger.Contracts;
using Logger.Models;

namespace Logger.Factories
{
    public class ErrorFactory
    {
        private const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string reportLevelType, string message)
        {
            var dateTime = DateTime.ParseExact(dateTimeString, DateFormat, CultureInfo.InvariantCulture);
            var errorLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelType);

            IError error = new Error(dateTime, errorLevel, message);

            return error;
        }
    }
}