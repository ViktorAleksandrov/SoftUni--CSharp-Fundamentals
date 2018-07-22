using System.Collections.Generic;

namespace P05.Integration
{
    public class Category
    {
        private HashSet<User> users;
        private HashSet<Category> childCategories;

        public Category(string name)
        {
            this.Name = name;
            this.users = new HashSet<User>();
            this.childCategories = new HashSet<Category>();
        }

        public string Name { get; }

        public IReadOnlyCollection<User> Users => this.users;

        public IReadOnlyCollection<Category> ChildCategories => this.childCategories;

        public void AddUsers(params User[] users)
        {
            this.users.UnionWith(users);
        }

        public void AddChildCategories(params Category[] childCategories)
        {
            this.childCategories.UnionWith(childCategories);
        }

        public void RemoveChildCategory(Category childCategory)
        {
            this.childCategories.Remove(childCategory);
        }

        public override bool Equals(object obj)
        {
            var other = (Category)obj;

            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
