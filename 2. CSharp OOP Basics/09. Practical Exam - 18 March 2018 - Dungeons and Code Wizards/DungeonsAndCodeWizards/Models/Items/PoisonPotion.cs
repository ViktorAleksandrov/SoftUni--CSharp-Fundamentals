namespace DungeonsAndCodeWizards.Models.Items
{
    using System;
    using Characters;

    public class PoisonPotion : Item
    {
        private const double HealthPointsDecrease = 20.0;

        public PoisonPotion()
            : base(weight: 5)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health = Math.Max(0, character.Health - HealthPointsDecrease);

            if (character.Health == 0)
            {
                character.IsAlive = false;
            }
        }
    }
}