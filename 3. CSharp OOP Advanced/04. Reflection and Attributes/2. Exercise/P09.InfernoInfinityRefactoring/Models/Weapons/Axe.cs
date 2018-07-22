using P09.InfernoInfinityRefactoring.Enums;

namespace P09.InfernoInfinityRefactoring.Models.Weapons
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
