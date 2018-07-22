using System;

namespace Logger.Contracts
{
    public interface IError : IReportLevelable
    {
        DateTime DateTime { get; }

        string Message { get; }
    }
}