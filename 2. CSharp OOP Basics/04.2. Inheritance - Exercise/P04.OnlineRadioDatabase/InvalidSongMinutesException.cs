public class InvalidSongMinutesException : InvalidSongLengthException
{
    private const int MinMinutes = 0;
    private const int MaxMinutes = 14;

    public override string Message => $"Song minutes should be between {MinMinutes} and {MaxMinutes}.";
}