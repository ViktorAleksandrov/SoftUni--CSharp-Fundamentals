using NUnit.Framework;
using P06.Twitter.Contracts;
using P06.Twitter.Models;

namespace P06.TwitterTests
{
    public class TwitterTests
    {
        private const string TestMessage = "test";

        ITweet tweet;
        IClient client;

        [SetUp]
        public void TwitterInit()
        {
            this.tweet = new Tweet(TestMessage);
            this.client = new Client();
        }

        [Test]
        public void RetrieveSameMessage()
        {
            Assert.That(TestMessage, Is.EqualTo(this.tweet.RetrieveMessage()));
        }

        [Test]
        public void ProcessTweetIncreaseTweetsCounter()
        {
            int tweetsCountBeforeProcessTweet = this.client.TweetsCount;

            this.client.ProcessTweet(this.tweet);

            Assert.That(tweetsCountBeforeProcessTweet + 1, Is.EqualTo(this.client.TweetsCount));
        }

        [Test]
        public void ProcessTweetAddTweetsToServer()
        {
            this.client.ProcessTweet(this.tweet);

            Assert.That(TestMessage, Is.EqualTo(this.client.LastMessage));
        }

        [Test]
        public void LastMessageReturnsNullIFServerIsEmpty()
        {
            Assert.That(this.client.LastMessage, Is.EqualTo(null));
        }
    }
}
