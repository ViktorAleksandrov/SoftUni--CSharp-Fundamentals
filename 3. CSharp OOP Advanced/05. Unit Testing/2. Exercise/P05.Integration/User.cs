using System.Collections.Generic;

namespace P05.Integration
{
    public class User
    {
        private string name;
        private readonly HashSet<Category> categories;

        public User(string name)
        {
            this.name = name;
            this.categories = new HashSet<Category>();
        }

        public IReadOnlyCollection<Category> Categories => this.categories;

        public void AddCategory(Category category)
        {
            this.categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            this.categories.Remove(category);
        }

        public override bool Equals(object obj)
        {
            var other = (User)obj;

            return this.name == other.name;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}
