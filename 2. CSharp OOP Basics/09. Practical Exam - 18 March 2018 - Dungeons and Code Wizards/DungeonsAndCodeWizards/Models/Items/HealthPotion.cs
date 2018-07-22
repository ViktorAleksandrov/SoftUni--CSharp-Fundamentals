namespace DungeonsAndCodeWizards.Models.Items
{
    using Characters;

    public class HealthPotion : Item
    {
        private const double HealthPointsIncrease = 20.0;

        public HealthPotion()
            : base(weight: 5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += HealthPointsIncrease;
        }
    }
}