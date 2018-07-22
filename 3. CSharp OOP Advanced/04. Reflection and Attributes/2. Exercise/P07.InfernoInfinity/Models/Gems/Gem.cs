﻿using P07.InfernoInfinity.Contracts;
using P07.InfernoInfinity.Enums;

namespace P07.InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        private readonly GemClarity clarity;

        protected Gem(GemClarity clarity, int strengthBonus, int agilityBonus, int vitalityBonus)
        {
            this.clarity = clarity;
            this.StrengthBonus = strengthBonus + (int)clarity;
            this.AgilityBonus = agilityBonus + (int)clarity;
            this.VitalityBonus = vitalityBonus + (int)clarity;
        }

        public int StrengthBonus { get; }

        public int AgilityBonus { get; }

        public int VitalityBonus { get; }
    }
}
