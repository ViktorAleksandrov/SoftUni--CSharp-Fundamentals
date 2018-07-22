using System;
using System.IO;
using System.Linq;
using Logger.Contracts;

namespace Logger
{
    public class LogFile : ILogFile
    {
        private const string DefaultFilePath = "../../../log.txt";

        public LogFile()
        {
            this.Size = 0;
        }

        public int Size { get; private set; }

        public void Write(string errorLog)
        {
            File.AppendAllText(DefaultFilePath, errorLog + Environment.NewLine);

            this.Size += errorLog.Where(char.IsLetter).Sum(c => c);
        }
    }
}