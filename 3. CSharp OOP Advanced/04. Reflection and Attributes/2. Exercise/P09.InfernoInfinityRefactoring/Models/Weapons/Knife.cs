using P09.InfernoInfinityRefactoring.Enums;

namespace P09.InfernoInfinityRefactoring.Models.Weapons
{
    public class Knife : Weapon
    {
        private const int InitialMinDamage = 3;
        private const int InitialMaxDamage = 4;
        private const int GemSocketsNumber = 2;

        public Knife(string name, WeaponRarity rarity)
            : base(name, rarity, InitialMinDamage, InitialMaxDamage, GemSocketsNumber)
        {
        }
    }
}
