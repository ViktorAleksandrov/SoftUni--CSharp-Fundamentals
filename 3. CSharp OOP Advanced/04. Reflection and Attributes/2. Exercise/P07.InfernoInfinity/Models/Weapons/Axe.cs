using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        private const int InitialMinDamage = 5;
        private const int InitialMaxDamage = 10;
        private const int GemSocketsNumber = 4;

        public Axe(string name, WeaponRarity rarity)
            : base(name, rarity, InitialMinDamage, InitialMaxDamage, GemSocketsNumber)
        {
        }
    }
}
