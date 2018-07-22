namespace Forum.App.Controllers
{
    using Forum.App.Controllers.Contracts;
    using Forum.App.Services;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.UserInterface.Input;
    using Forum.App.UserInterface.ViewModels;
    using Forum.App.Views;
    using System.Linq;

    public class AddReplyController : IController
    {
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 6;
        private const int POST_MAX_LENGTH = 220;

        private static int centerTop = Position.ConsoleCenter().Top;
        private static int centerLeft = Position.ConsoleCenter().Left;

        private PostViewModel postViewModel;

        public AddReplyController()
        {
            this.ResetReply();
        }

        private enum Command
        {
            Write, Post
        }

        public ReplyViewModel Reply { get; private set; }

        private TextArea TextArea { get; set; }

        public bool Error { get; private set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.Write:
                    this.TextArea.Write();
                    this.Reply.Content = this.TextArea.Lines.ToList();
                    return MenuState.AddReply;
                case Command.Post:
                    bool validReply = PostService.TrySaveReply(this.Reply, this.postViewModel.PostId);
                    if (!validReply)
                    {
                        this.Error = true;
                        return MenuState.Rerender;
                    }
                    return MenuState.ReplyAdded;
            }

            throw new InvalidCommandException();
        }

        public IView GetView(string userName)
        {
            this.Reply.Author = userName;
            return new AddReplyView(this.postViewModel, this.Reply, this.TextArea, this.Error);
        }

        public void ResetReply()
        {
            this.Error = false;
            this.Reply = new ReplyViewModel();

            int contentLength = this.postViewModel?.Content.Count ?? 0;

            this.TextArea = new TextArea(
                centerLeft - 18, centerTop + contentLength - 6, TEXT_AREA_WIDTH, TEXT_AREA_HEIGHT, POST_MAX_LENGTH);
        }

        public void SetPostId(int postId)
        {
            this.postViewModel = PostService.GetPostViewModel(postId);

            this.ResetReply();
        }
    }
}