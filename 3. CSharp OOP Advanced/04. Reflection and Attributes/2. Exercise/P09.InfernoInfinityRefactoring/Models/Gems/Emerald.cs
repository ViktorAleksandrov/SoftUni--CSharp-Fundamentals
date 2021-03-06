﻿using P09.InfernoInfinityRefactoring.Enums;

namespace P09.InfernoInfinityRefactoring.Models.Gems
{
    public class Emerald : Gem
    {
        private const int InitialStrengthBonus = 1;
        private const int InitialAgilityBonus = 4;
        private const int InitialVitalityBonus = 9;

        public Emerald(GemClarity clarity)
            : base(clarity, InitialStrengthBonus, InitialAgilityBonus, InitialVitalityBonus)
        {
        }
    }
}
