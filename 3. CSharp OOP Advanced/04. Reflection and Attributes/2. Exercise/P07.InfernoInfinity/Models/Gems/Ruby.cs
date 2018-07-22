using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public class Ruby : Gem
    {
        private const int InitialStrengthBonus = 7;
        private const int InitialAgilityBonus = 2;
        private const int InitialVitalityBonus = 5;

        public Ruby(GemClarity clarity)
            : base(clarity, InitialStrengthBonus, InitialAgilityBonus, InitialVitalityBonus)
        {
        }
    }
}
