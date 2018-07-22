namespace DungeonsAndCodeWizards.Models.Characters
{
    using System;
    using Bags;
    using Enums;
    using Items;

    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => this.health;

            set => this.health = Math.Min(value, this.BaseHealth);
        }

        public double BaseArmor { get; }

        public double Armor
        {
            get => this.armor;

            set => this.armor = Math.Min(value, this.BaseArmor);
        }

        public double AbilityPoints { get; }

        public Bag Bag { get; }

        public Faction Faction { get; }

        public bool IsAlive { get; set; }

        protected virtual double RestHealMultiplier => 0.2;

        public void TakeDamage(double hitPoints)
        {
            double remainingHitPoints = Math.Max(0, hitPoints - this.Armor);

            this.Armor = Math.Max(0, this.Armor - hitPoints);
            this.Health = Math.Max(0, this.Health - remainingHitPoints);

            if (this.Health == 0)
            {
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            this.CheckIsThisCharacterAlive();

            this.Health += this.BaseHealth * this.RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            this.UseItemOn(item, this);
        }

        public void UseItemOn(Item item, Character character)
        {
            this.CheckIsThisCharacterAlive();

            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            this.CheckIsThisCharacterAlive();

            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            this.CheckIsThisCharacterAlive();

            this.Bag.AddItem(item);
        }

        private void CheckIsThisCharacterAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        protected void CheckAreBothCharactersAlive(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

        public override string ToString()
        {
            string status = this.IsAlive ? "Alive" : "Dead";

            string output = $"{this.Name} - HP: {this.Health}/{this.BaseHealth}, " +
                            $"AP: {this.Armor}/{this.BaseArmor}, Status: {status}";

            return output;
        }
    }
}