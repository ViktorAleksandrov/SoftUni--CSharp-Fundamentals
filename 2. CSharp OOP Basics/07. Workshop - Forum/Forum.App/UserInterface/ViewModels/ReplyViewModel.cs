namespace Forum.App.UserInterface.ViewModels
{
    using Forum.App.Services;
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel() { }

        public ReplyViewModel(Reply reply)
        {
            this.Author = UserService.GetUser(reply.AuthorId).Username;
            this.Content = GetLines(reply.Content);
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            char[] contentChars = content.ToCharArray();

            IList<string> lines = new List<string>();

            for (int counter = 0; counter < content.Length; counter += LINE_LENGHT)
            {
                char[] row = contentChars.Skip(counter).Take(LINE_LENGHT).ToArray();
                string rowString = string.Join(string.Empty, row);
                lines.Add(rowString);
            }

            return lines;
        }
    }
}