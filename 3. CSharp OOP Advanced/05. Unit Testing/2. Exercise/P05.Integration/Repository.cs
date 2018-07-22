using System.Collections.Generic;
using System.Linq;

namespace P05.Integration
{
    public class Repository
    {
        private HashSet<Category> categories;

        public Repository()
        {
            this.categories = new HashSet<Category>();
        }

        public IReadOnlyCollection<Category> Categories => this.categories;

        public void AddCategories(params Category[] categories)
        {
            if (categories != null)
            {
                foreach (Category category in categories.Where(c => c != null && !string.IsNullOrWhiteSpace(c.Name)))
                {
                    this.categories.Add(category);
                }
            }
        }

        public void RemoveCategories(params Category[] categories)
        {
            if (categories == null)
            {
                return;
            }

            foreach (Category categoryToRemove in categories.Where(c => c != null && !string.IsNullOrWhiteSpace(c.Name)))
            {
                if (!this.categories.Contains(categoryToRemove))
                {
                    continue;
                }

                if (categoryToRemove.ChildCategories.Any())
                {
                    foreach (User user in categoryToRemove.Users)
                    {
                        user.RemoveCategory(categoryToRemove);

                        foreach (Category category in categoryToRemove.ChildCategories)
                        {
                            category.AddUsers(user);
                        }
                    }
                }

                Category possibleParentCategory = this.categories
                    .FirstOrDefault(c => c.ChildCategories.Any(x => x.Name == categoryToRemove.Name));

                possibleParentCategory?.RemoveChildCategory(categoryToRemove);

                this.categories.Remove(categoryToRemove);
            }
        }

        public void AssignChildCategory(Category parentCategory, Category childCategory)
        {
            if (!this.categories.Contains(childCategory) || !this.categories.Contains(parentCategory))
            {
                return;
            }

            Category possibleParentCategory = this.categories
                .FirstOrDefault(c => c.ChildCategories.Any(x => x.Name == childCategory.Name));

            possibleParentCategory?.RemoveChildCategory(childCategory);

            var newCategory = new Category(childCategory.Name);

            newCategory.AddUsers(childCategory.Users.ToArray());
            newCategory.AddChildCategories(childCategory.ChildCategories.ToArray());

            parentCategory.AddChildCategories(newCategory);
        }

        public void AssignUserToCategory(User user, Category category)
        {
            if (user != null && this.categories.Contains(category))
            {
                category.AddUsers(user);
                user.AddCategory(category);
            }
        }
    }
}
