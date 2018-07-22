namespace Logger.Contracts
{
    public interface ILogger
    {
        void Log(IError error);
    }
}