using P06.Twitter.Contracts;

namespace P06.Twitter.Models
{
    public class Tweet : ITweet
    {
        private string message;

        public Tweet(string message)
        {
            this.message = message;
        }

        public string RetrieveMessage()
        {
            return this.message;
        }
    }
}
