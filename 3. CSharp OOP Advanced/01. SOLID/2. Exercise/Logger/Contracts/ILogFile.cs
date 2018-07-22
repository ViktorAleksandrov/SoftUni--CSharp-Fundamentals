namespace Logger.Contracts
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string errorLog);
    }
}