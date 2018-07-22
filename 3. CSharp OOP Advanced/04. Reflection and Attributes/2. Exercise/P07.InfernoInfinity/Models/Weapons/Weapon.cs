using System.Linq;
using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public abstract class Weapon : IWeapon
    {
        private readonly WeaponRarity rarity;
        private readonly int minDamage;
        private readonly int maxDamage;
        private readonly IGem[] gemSockets;

        protected Weapon(string name, WeaponRarity rarity, int minDamage, int maxDamage, int gemSocketsNumber)
        {
            this.Name = name;
            this.rarity = rarity;
            this.minDamage = minDamage * (int)rarity;
            this.maxDamage = maxDamage * (int)rarity;
            this.gemSockets = new IGem[gemSocketsNumber];
        }

        public string Name { get; }

        public void AddGem(IGem gem, int socketIndex)
        {
            if (this.IsGemSocketExist(socketIndex))
            {
                this.gemSockets[socketIndex] = gem;
            }
        }

        public void RemoveGem(int socketIndex)
        {
            if (this.IsGemSocketExist(socketIndex))
            {
                this.gemSockets[socketIndex] = null;
            }
        }

        private bool IsGemSocketExist(int socketIndex)
        {
            return socketIndex >= 0 && socketIndex < this.gemSockets.Length;
        }

        public override string ToString()
        {
            int strength = 0;
            int agility = 0;
            int vitality = 0;

            foreach (IGem gem in this.gemSockets.Where(g => g != null))
            {
                strength += gem.StrengthBonus;
                agility += gem.AgilityBonus;
                vitality += gem.VitalityBonus;
            }

            int minDamage = this.minDamage + agility + (strength * 2);
            int maxDamage = this.maxDamage + (agility * 4) + (strength * 3);

            string output = $"{this.Name}: {minDamage}-{maxDamage} Damage, " +
                            $"+{strength} Strength, +{agility} Agility, +{vitality} Vitality";

            return output;
        }
    }
}
