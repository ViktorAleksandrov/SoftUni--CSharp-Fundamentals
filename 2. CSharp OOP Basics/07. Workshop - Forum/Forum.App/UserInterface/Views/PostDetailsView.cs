﻿namespace Forum.App.Views
{
    using System.Collections.Generic;

    using Forum.App.UserInterface;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.ViewModels;

    public class PostDetailsView : IView
    {
        private const int AUTHOR_OFFSET = 8;
        private const int LEFT_OFFSET = 18;
        private const int TOP_OFFSET = 7;

        public PostDetailsView(PostViewModel post, bool isLoggedIn = false)
        {
            this.Post = post;
            this.IsLoggedIn = isLoggedIn;
            this.SetBuffer();
            this.InitalizeLabels();
        }

        public ILabel[] Labels { get; private set; }

        public ILabel[] Buttons { get; private set; }

        private PostViewModel Post { get; }

        public bool IsLoggedIn { get; }

        private void SetBuffer()
        {
            int totalLines = 10 + this.Post.Content.Count;

            foreach (ReplyViewModel reply in this.Post.Replies)
            {
                totalLines += 2 + reply.Content.Count;
            }

            if (totalLines > 30)
            {
                ForumViewEngine.SetBufferHeight(totalLines);
            }
        }

        private void InitalizeLabels()
        {
            Position consoleCenter = Position.ConsoleCenter();

            var titlePosition = new Position(consoleCenter.Left - this.Post.Title.Length / 2, consoleCenter.Top - 10);
            var authorPosition = new Position(consoleCenter.Left - this.Post.Author.Length, consoleCenter.Top - 9);

            var labels = new List<ILabel>()
            {
                new Label(this.Post.Title, titlePosition),
                new Label($"Author: {this.Post.Author}", authorPosition),
            };

            int leftPosition = consoleCenter.Left - LEFT_OFFSET;

            int lineCount = this.Post.Content.Count;

            // Add post contents
            for (int i = 0; i < lineCount; i++)
            {
                var position = new Position(leftPosition, consoleCenter.Top - (TOP_OFFSET - i));
                ILabel label = new Label(this.Post.Content[i], position);
                labels.Add(label);
            }

            int currentRow = consoleCenter.Top - (TOP_OFFSET - lineCount) + 1;

            InitializeButtons(leftPosition, currentRow);

            // Add replies
            var repliesStartPosition = new Position(leftPosition, currentRow++);
            int repliesCount = this.Post.Replies.Count;

            labels.Add(new Label($"Replies: {repliesCount}", repliesStartPosition));

            foreach (ReplyViewModel reply in this.Post.Replies)
            {
                var replyAuthorPosition = new Position(leftPosition, ++currentRow);

                labels.Add(new Label(reply.Author, replyAuthorPosition));

                foreach (string line in reply.Content)
                {
                    var rowPosition = new Position(leftPosition, ++currentRow);
                    labels.Add(new Label(line, rowPosition));
                }

                currentRow++;
            }

            this.Labels = labels.ToArray();
        }

        private void InitializeButtons(int left, int top)
        {
            this.Buttons = new ILabel[2];

            this.Buttons[0] = new Label("Back", new Position(left + 33, top));
            this.Buttons[1] = new Label("Add Reply", new Position(left + 28, top - 1), !this.IsLoggedIn);
        }
    }
}