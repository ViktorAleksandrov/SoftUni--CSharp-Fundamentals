namespace Forum.App.Commands
{
    using Contracts;

    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postService)
        {
            this.session = session;
            this.postService = postService;
        }

        public IMenu Execute(params string[] args)
        {
            int postId = int.Parse(args[0]);
            string replyContent = args[1];
            int userId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyContent, userId);

            return this.session.Back();
        }
    }
}
