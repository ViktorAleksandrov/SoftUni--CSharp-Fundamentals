namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using Bags;
    using Contracts;
    using Enums;

    public class Cleric : Character, IHealable
    {
        public Cleric(string name, Faction faction)
            : base(name, health: 50.0, armor: 25.0, abilityPoints: 40.0, bag: new Backpack(), faction: faction)
        {
        }

        protected override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            this.CheckAreBothCharactersAlive(character);

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException("Cannot heal enemy character!");
            }

            character.Health += this.AbilityPoints;
        }
    }
}