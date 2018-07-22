namespace Logger.Contracts
{
    public interface IAppender : IReportLevelable
    {
        ILayout Layout { get; }

        int MessagesCounter { get; }

        void Append(string formattedError);
    }
}