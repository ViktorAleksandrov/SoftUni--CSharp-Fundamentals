namespace DungeonsAndCodeWizards.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Factories;
    using Models.Characters;
    using Models.Items;

    public class DungeonMaster
    {
        private int lastSurvivorRounds;
        private List<Character> party;
        private Stack<Item> pool;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.lastSurvivorRounds = 0;
            this.party = new List<Character>();
            this.pool = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string factionName = args[0];
            string characterType = args[1];
            string characterName = args[2];

            Character character = this.characterFactory.CreateCharacter(factionName, characterType, characterName);

            this.party.Add(character);

            return $"{characterName} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.pool.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.TryFindCharacter(characterName);

            if (this.pool.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            Item lastItem = this.pool.Pop();

            character.ReceiveItem(lastItem);

            return $"{characterName} picked up {lastItem.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.TryFindCharacter(characterName);

            string itemName = args[1];
            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            Character giver = this.TryFindCharacter(giverName);

            string receiverName = args[1];
            Character receiver = this.TryFindCharacter(receiverName);

            string itemName = args[2];
            Item item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            Character giver = this.TryFindCharacter(giverName);

            string receiverName = args[1];
            Character receiver = this.TryFindCharacter(receiverName);

            string itemName = args[2];
            Item item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sortedCharacters = this.party
                .OrderByDescending(a => a.IsAlive)
                .ThenByDescending(a => a.Health);

            string output = string.Join(Environment.NewLine, sortedCharacters);

            return output;
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            Character attacker = this.TryFindCharacter(attackerName);

            string receiverName = args[1];
            Character receiver = this.TryFindCharacter(receiverName);

            if (!(attacker is IAttackable attackableCharacter))
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            attackableCharacter.Attack(receiver);

            string output = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                            $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and " +
                            $"{receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (!receiver.IsAlive)
            {
                output += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return output;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            Character healer = this.TryFindCharacter(healerName);

            string healingReceiverName = args[1];
            Character receiver = this.TryFindCharacter(healingReceiverName);

            if (!(healer is IHealable healableCharacter))
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

            healableCharacter.Heal(receiver);

            string output = $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
                            $"{receiver.Name} has {receiver.Health} health now!";

            return output;
        }

        public string EndTurn(string[] args)
        {
            Character[] aliveCharacters = this.party.Where(c => c.IsAlive).ToArray();

            if (aliveCharacters.Length <= 1)
            {
                this.lastSurvivorRounds++;
            }

            var output = new StringBuilder();

            foreach (Character character in aliveCharacters)
            {
                double healthBeforeRest = character.Health;

                character.Rest();

                output.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            return output.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            return this.lastSurvivorRounds > 1;
        }

        private Character TryFindCharacter(string characterName)
        {
            Character character = this.party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}