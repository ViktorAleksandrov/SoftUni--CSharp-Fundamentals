namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using Bags;
    using Contracts;
    using Enums;

    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction)
            : base(name, health: 100.0, armor: 50.0, abilityPoints: 40.0, bag: new Satchel(), faction: faction)
        {
        }

        public void Attack(Character character)
        {
            this.CheckAreBothCharactersAlive(character);

            if (this.Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {this.Faction} faction!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}