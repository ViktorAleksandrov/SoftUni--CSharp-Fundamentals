namespace P06.Twitter.Contracts
{
    public interface IClient
    {
        int TweetsCount { get; }

        string LastMessage { get; }

        void ProcessTweet(ITweet tweet);
    }
}
