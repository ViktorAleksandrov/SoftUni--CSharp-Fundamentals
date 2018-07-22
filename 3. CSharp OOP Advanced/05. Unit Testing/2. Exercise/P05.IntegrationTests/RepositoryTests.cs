using System.Linq;
using NUnit.Framework;
using P05.Integration;

namespace P05.IntegrationTests
{
    public class RepositoryTests
    {
        private const string CategoryOneName = "CategoryOne";
        private const string CategoryTwoName = "CategoryTwo";
        private const string CategoryThreeName = "CategoryThree";
        private const string TestUserName = "Pesho";

        private Repository repo;
        Category categoryOne;
        Category categoryTwo;
        Category categoryThree;
        User testUser;

        [SetUp]
        public void Initialize()
        {
            this.repo = new Repository();

            this.categoryOne = new Category(CategoryOneName);
            this.categoryTwo = new Category(CategoryTwoName);
            this.categoryThree = new Category(CategoryThreeName);

            this.testUser = new User(TestUserName);

            this.repo.AddCategories(this.categoryOne, this.categoryTwo, this.categoryThree);
        }

        [Test]
        public void RemoveCategoryDeleteRelationFromItsParentCategory()
        {
            this.repo.AssignChildCategory(this.categoryOne, this.categoryTwo);
            this.repo.AssignChildCategory(this.categoryTwo, this.categoryThree);

            this.repo.RemoveCategories(this.categoryTwo);

            Assert.IsFalse(this.categoryOne.ChildCategories.Contains(this.categoryTwo));
        }

        [Test]
        public void MoveUsersFromParentToItsChildCategory()
        {
            this.repo.AssignChildCategory(this.categoryTwo, this.categoryThree);

            this.repo.RemoveCategories(this.categoryTwo);

            foreach (User user in this.categoryTwo.Users)
            {
                Assert.IsTrue(user.Categories.Contains(this.categoryThree));
                Assert.IsTrue(this.categoryThree.Users.Contains(user));
            }

            Assert.IsFalse(this.repo.Categories.Contains(this.categoryTwo));
            Assert.That(this.categoryThree.Users, Is.EquivalentTo(this.categoryTwo.Users));
        }

        [Test]
        public void AssignChildCategoryWithoutParentCategoryToSingleCategory()
        {
            this.repo.AssignChildCategory(this.categoryTwo, this.categoryOne);

            Assert.IsTrue(this.categoryTwo.ChildCategories.Contains(this.categoryOne));
        }

        [Test]
        public void AssignChildCategoryFromOneParentCategoryToAnother()
        {
            this.repo.AssignChildCategory(this.categoryTwo, this.categoryThree);
            this.repo.AssignChildCategory(this.categoryOne, this.categoryThree);

            Assert.IsFalse(this.categoryTwo.ChildCategories.Contains(this.categoryThree));

            Assert.IsTrue(this.categoryOne.ChildCategories.Contains(this.categoryThree));

            Assert.That(this.categoryThree.Users,
                Is.EquivalentTo(this.categoryOne.ChildCategories.First(c => c.Name == CategoryThreeName).Users));
        }

        [Test]
        public void AssignUserToCategory()
        {
            this.repo.AssignUserToCategory(this.testUser, this.categoryOne);

            Assert.That(this.categoryOne.Users.Contains(this.testUser), Is.EqualTo(true));
            Assert.That(this.testUser.Categories.Contains(this.categoryOne), Is.EqualTo(true));
        }
    }
}
