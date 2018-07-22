namespace Forum.App.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Data;
    using DataModels;
    using ViewModels;

    public class PostService : IPostService
    {
        private ForumData forumData;
        private IUserService userService;

        public PostService(ForumData forumData, IUserService userService)
        {
            this.forumData = forumData;
            this.userService = userService;
        }

        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyTitle = string.IsNullOrWhiteSpace(postTitle);
            bool emptyCategory = string.IsNullOrWhiteSpace(postCategory);
            bool emptyContent = string.IsNullOrWhiteSpace(postContent);

            if (emptyTitle || emptyCategory || emptyContent)
            {
                throw new ArgumentException("All fields must be filled!");
            }

            Category category = this.EnsureCategory(postCategory);

            int postId = this.forumData.Posts.Any() ? this.forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            var post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            this.forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            this.forumData.SaveChanges();

            return post.Id;
        }

        private Category EnsureCategory(string postCategory)
        {
            Category category = this.forumData.Categories
                .FirstOrDefault(c => c.Name == postCategory);

            if (category == null)
            {
                int categoryId = this.forumData.Categories.LastOrDefault()?.Id + 1 ?? 1;

                category = new Category(categoryId, postCategory);

                this.forumData.Categories.Add(category);
                this.forumData.SaveChanges();
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            if (string.IsNullOrWhiteSpace(replyContents))
            {
                throw new ArgumentException("Can't add an empty reply!");
            }

            Post post = this.forumData.Posts.SingleOrDefault(p => p.Id == postId);

            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;

            var reply = new Reply(replyId, replyContents, userId, postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);

            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData.Categories
                .Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;

            if (categoryName == null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }

            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            IEnumerable<IPostInfoViewModel> categoryPosts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(p => new PostInfoViewModel(p.Id, p.Title, p.Replies.Count));

            return categoryPosts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            Post post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);

            IPostViewModel postView = new PostViewModel(
                post.Title, this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData.Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }
    }
}
