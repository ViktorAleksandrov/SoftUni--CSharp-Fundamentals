using NUnit.Framework;

namespace Tests
{
    public class AxeTests
    {
        private const int AxeAttack = 2;
        private const int AxeDurability = 1;
        private const int AxeExpectedDurability = 0;
        private const int DummyHealth = 20;
        private const int DummyXP = 20;
        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void AxeAndDummyInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            this.axe.Attack(this.dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(AxeExpectedDurability),
                "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void BrokenAxeCantAttack()
        {
            this.axe.Attack(this.dummy);

            Assert.That(() => this.axe.Attack(this.dummy),
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."),
                "Broken axe can attack.");
        }
    }
}
