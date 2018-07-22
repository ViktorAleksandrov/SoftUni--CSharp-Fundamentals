public class InvalidSongSecondsException : InvalidSongLengthException
{
    private const int MinSeconds = 0;
    private const int MaxSeconds = 59;

    public override string Message => $"Song seconds should be between {MinSeconds} and {MaxSeconds}.";
}