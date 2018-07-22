using NUnit.Framework;

namespace Tests
{
    public class DummyTests
    {
        private const int AttackPoints = 15;
        private const int DummyHealth = 15;
        private const int ExpectedDummyHealth = 0;
        private const int DummyXP = 20;
        private Dummy dummy;

        [SetUp]
        public void DummyInit()
        {
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthAfterAttack()
        {
            this.dummy.TakeAttack(AttackPoints);

            Assert.AreEqual(this.dummy.Health, ExpectedDummyHealth, "Dummy doesn't lose health after attack");
        }

        [Test]
        public void DeadDummyThrowsExceptionAfterAttack()
        {
            this.dummy.TakeAttack(AttackPoints);

            Assert.That(() => this.dummy.TakeAttack(AttackPoints),
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            this.dummy.TakeAttack(AttackPoints);

            Assert.That(this.dummy.GiveExperience(), Is.EqualTo(DummyXP), "Dead dummy can't give XP");
        }

        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(() => this.dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
