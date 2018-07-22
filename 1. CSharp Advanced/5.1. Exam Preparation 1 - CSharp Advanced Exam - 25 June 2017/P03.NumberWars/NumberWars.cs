namespace P03.NumberWars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        public static void Main()
        {
            var firstPlayerDeck = new Queue<string>(Console.ReadLine().Split());
            var secondPlayerDeck = new Queue<string>(Console.ReadLine().Split());

            var turnsCount = GetTurnsCount(firstPlayerDeck, secondPlayerDeck);

            PrintOutput(firstPlayerDeck, secondPlayerDeck, turnsCount);
        }

        private static int GetTurnsCount(Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck)
        {
            var isGameOver = false;

            var turnsCount = 0;

            while (firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0 && turnsCount < 1_000_000 && isGameOver == false)
            {
                turnsCount++;

                var firstPlayerCard = firstPlayerDeck.Dequeue();
                var secondPlayerCard = secondPlayerDeck.Dequeue();

                var firstPlayerCardNumber = GetCardNumber(firstPlayerCard);
                var secondPlayerCardNumber = GetCardNumber(secondPlayerCard);

                if (firstPlayerCardNumber > secondPlayerCardNumber)
                {
                    firstPlayerDeck.Enqueue(firstPlayerCard);
                    firstPlayerDeck.Enqueue(secondPlayerCard);
                }
                else if (secondPlayerCardNumber > firstPlayerCardNumber)
                {
                    secondPlayerDeck.Enqueue(secondPlayerCard);
                    secondPlayerDeck.Enqueue(firstPlayerCard);
                }
                else
                {
                    var cardsForWinner = new List<string> { firstPlayerCard, secondPlayerCard };

                    isGameOver = IsGameOver(firstPlayerDeck, secondPlayerDeck, cardsForWinner);
                }
            }

            return turnsCount;
        }

        private static int GetCardNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static bool IsGameOver(Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck, List<string> cardsForWinner)
        {
            while (true)
            {
                if (firstPlayerDeck.Count < 3 || secondPlayerDeck.Count < 3)
                {
                    return true;
                }

                var firstPlayerSum = SumCardsLetters(firstPlayerDeck, cardsForWinner);
                var secondPlayerSum = SumCardsLetters(secondPlayerDeck, cardsForWinner);

                if (firstPlayerSum > secondPlayerSum)
                {
                    AddCardsToWinner(firstPlayerDeck, cardsForWinner);
                    break;
                }
                else if (secondPlayerSum > firstPlayerSum)
                {
                    AddCardsToWinner(secondPlayerDeck, cardsForWinner);
                    break;
                }
            }

            return false;
        }

        private static int SumCardsLetters(Queue<string> playerDeck, List<string> cardsForWinner)
        {
            var sum = 0;

            for (int i = 0; i < 3; i++)
            {
                var card = playerDeck.Dequeue();

                cardsForWinner.Add(card);

                var cardLetter = card.Last();

                sum += cardLetter;
            }

            return sum;
        }

        private static void AddCardsToWinner(Queue<string> playerDeck, List<string> cardsForWinner)
        {
            var orderedCardsForWinner = cardsForWinner
                .OrderByDescending(s => GetCardNumber(s))
                .ThenByDescending(s => s.Last())
                .ToList();

            foreach (var card in orderedCardsForWinner)
            {
                playerDeck.Enqueue(card);
            }
        }

        private static void PrintOutput(Queue<string> firstPlayerDeck, Queue<string> secondPlayerDeck, int turnsCount)
        {
            var result = string.Empty;

            if (firstPlayerDeck.Count > secondPlayerDeck.Count)
            {
                result = "First player wins";
            }
            else if (secondPlayerDeck.Count > firstPlayerDeck.Count)
            {
                result = "Second player wins";
            }
            else
            {
                result = "Draw";
            }

            Console.WriteLine($"{result} after {turnsCount} turns");
        }
    }
}