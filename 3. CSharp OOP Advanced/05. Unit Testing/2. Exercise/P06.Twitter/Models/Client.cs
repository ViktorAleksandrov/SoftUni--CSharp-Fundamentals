using System;
using System.Collections.Generic;
using System.Linq;
using P06.Twitter.Contracts;

namespace P06.Twitter.Models
{
    public class Client : IClient
    {
        private List<string> server;

        public Client()
        {
            this.server = new List<string>();
        }

        public int TweetsCount => this.server.Count;

        public string LastMessage => this.TweetsCount > 0 ? this.server.Last() : null;

        public void ProcessTweet(ITweet tweet)
        {
            string message = tweet.RetrieveMessage();

            Console.WriteLine(message);

            this.server.Add(message);
        }
    }
}
