namespace Logger.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}