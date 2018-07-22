using System.Globalization;
using Logger.Contracts;

namespace Logger.Models.Layouts
{
    public abstract class Layout : ILayout
    {
        protected const string DateFormat = "M/d/yyyy h:mm:ss tt";

        protected abstract string Format { get; }

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formattedError = string.Format(this.Format, dateString, error.ReportLevel, error.Message);

            return formattedError;
        }
    }
}