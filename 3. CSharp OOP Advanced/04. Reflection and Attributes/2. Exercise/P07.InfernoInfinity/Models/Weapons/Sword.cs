using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        private const int InitialMinDamage = 4;
        private const int InitialMaxDamage = 6;
        private const int GemSocketsNumber = 3;

        public Sword(string name, WeaponRarity rarity)
            : base(name, rarity, InitialMinDamage, InitialMaxDamage, GemSocketsNumber)
        {
        }
    }
}
