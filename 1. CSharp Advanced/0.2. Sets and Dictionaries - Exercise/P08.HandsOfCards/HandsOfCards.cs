namespace P08.HandsOfCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HandsOfCards
    {
        public static void Main()
        {
            var playersCards = new Dictionary<string, HashSet<string>>();

            while (true)
            {
                var inputTokens = Console.ReadLine()
                    .Split(':');

                var player = inputTokens[0];

                if (player == "JOKER")
                {
                    break;
                }

                if (playersCards.ContainsKey(player) == false)
                {
                    playersCards[player] = new HashSet<string>();
                }

                var cards = inputTokens[1]
                    .Split(',')
                    .Select(c => c.Trim());

                playersCards[player].UnionWith(cards);
            }

            foreach (var pair in playersCards)
            {
                var cardsOfPlayer = pair.Value;

                var player = pair.Key;
                var totalValue = CalcCardsTotalValue(cardsOfPlayer);

                Console.WriteLine($"{player}: {totalValue}");
            }
        }

        private static int CalcCardsTotalValue(HashSet<string> cardsOfPlayer)
        {
            var totalValue = 0;

            foreach (var card in cardsOfPlayer)
            {
                var power = card.Substring(0, card.Length - 1);

                var value = 0;

                switch (power)
                {
                    case "J":
                        value = 11;
                        break;
                    case "Q":
                        value = 12;
                        break;
                    case "K":
                        value = 13;
                        break;
                    case "A":
                        value = 14;
                        break;
                    default:
                        value = int.Parse(power);
                        break;
                }

                var type = card.Last();

                switch (type)
                {
                    case 'D':
                        value *= 2;
                        break;
                    case 'H':
                        value *= 3;
                        break;
                    case 'S':
                        value *= 4;
                        break;
                }

                totalValue += value;
            }

            return totalValue;
        }
    }
}