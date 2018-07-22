using Moq;
using NUnit.Framework;
using UnitTesting;

namespace Tests
{
    public class HeroTests
    {
        private const int TargetHealth = 0;
        private const int TargetExperience = 20;
        private const string HeroName = "Pesho";

        [Test]
        public void HeroGainsXPAfterAttackIfTargetDiesWithMocking()
        {
            var fakeTarget = new Mock<ITarget>();

            fakeTarget.Setup(t => t.GiveExperience()).Returns(TargetExperience);
            fakeTarget.Setup(t => t.IsDead()).Returns(true);

            var fakeWeapon = new Mock<IWeapon>();

            var hero = new Hero(HeroName, fakeWeapon.Object);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(hero.Experience, TargetExperience);
        }

        [Test]
        public void HeroGainsXPAfterAttackIfTargetDies()
        {
            IWeapon fakeWeapon = new FakeWeapon();
            ITarget fakeTarget = new FakeTarget();

            var hero = new Hero(HeroName, fakeWeapon);

            hero.Attack(fakeTarget);

            Assert.AreEqual(hero.Experience, fakeTarget.GiveExperience());
        }
    }
}
