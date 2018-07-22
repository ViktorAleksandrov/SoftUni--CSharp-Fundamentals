using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public class Amethyst : Gem
    {
        private const int InitialStrengthBonus = 2;
        private const int InitialAgilityBonus = 8;
        private const int InitialVitalityBonus = 4;

        public Amethyst(GemClarity clarity)
            : base(clarity, InitialStrengthBonus, InitialAgilityBonus, InitialVitalityBonus)
        {
        }
    }
}
