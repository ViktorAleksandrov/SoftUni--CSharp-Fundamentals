namespace DungeonsAndCodeWizards.Factories
{
    using System;
    using Models.Characters;
    using Models.Enums;

    public class CharacterFactory
    {
        public Character CreateCharacter(string factionName, string characterType, string characterName)
        {
            if (!Enum.TryParse(factionName, out Faction faction))
            {
                throw new ArgumentException($"Invalid faction \"{factionName}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(characterName, faction);
                case "Cleric":
                    return new Cleric(characterName, faction);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}