namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string InvalidCommand = "The command {0} is invalid!";

        public InvalidCommandException(string commandName)
            : base(string.Format(InvalidCommand, commandName))
        {
        }
    }
}