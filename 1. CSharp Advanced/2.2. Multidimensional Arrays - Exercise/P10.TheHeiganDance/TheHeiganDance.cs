namespace P10.TheHeiganDance
{
    using System;

    public class TheHeiganDance
    {
        public static void Main()
        {
            const int chamberSize = 15;

            const int cloudDamage = 3500;
            const int eruptionDamage = 6000;

            var spell = string.Empty;

            var isPlayerHitByCloud = false;

            var playerPoints = 18500;
            var heiganPoints = 3000000.0;

            var damageToHeigan = double.Parse(Console.ReadLine());

            var playerRow = 7;
            var playerColumn = 7;

            while (true)
            {
                var spellParams = Console.ReadLine().Split();

                spell = spellParams[0];

                if (spell == "Cloud")
                {
                    spell = "Plague Cloud";
                }

                if (isPlayerHitByCloud)
                {
                    playerPoints -= cloudDamage;

                    if (playerPoints <= 0)
                    {
                        spell = "Plague Cloud";
                    }

                    isPlayerHitByCloud = false;
                }

                heiganPoints -= damageToHeigan;

                if (playerPoints <= 0 || heiganPoints <= 0)
                {
                    break;
                }

                var hitRow = int.Parse(spellParams[1]);
                var hitColumn = int.Parse(spellParams[2]);

                if (IsPlayerInDamagedArea(hitRow, hitColumn, playerRow, playerColumn))
                {
                    if (IsPlayerInDamagedArea(hitRow, hitColumn, playerRow - 1, playerColumn) == false
                        && playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else if (IsPlayerInDamagedArea(hitRow, hitColumn, playerRow, playerColumn + 1) == false
                        && playerColumn + 1 < chamberSize)
                    {
                        playerColumn++;
                    }
                    else if (IsPlayerInDamagedArea(hitRow, hitColumn, playerRow + 1, playerColumn) == false
                        && playerRow + 1 < chamberSize)
                    {
                        playerRow++;
                    }
                    else if (IsPlayerInDamagedArea(hitRow, hitColumn, playerRow, playerColumn - 1) == false
                        && playerColumn - 1 >= 0)
                    {
                        playerColumn--;
                    }
                    else if (spell == "Plague Cloud")
                    {
                        playerPoints -= cloudDamage;

                        isPlayerHitByCloud = true;
                    }
                    else if (spell == "Eruption")
                    {
                        playerPoints -= eruptionDamage;
                    }

                    if (playerPoints <= 0)
                    {
                        break;
                    }
                }
            }

            PrintOutput(spell, playerPoints, heiganPoints, playerRow, playerColumn);
        }

        private static bool IsPlayerInDamagedArea(int hitRow, int hitColumn, int playerRow, int playerColumn)
        {
            var isHitVertical = playerRow >= hitRow - 1 && playerRow <= hitRow + 1;

            var isHitHorizontal = playerColumn >= hitColumn - 1 && playerColumn <= hitColumn + 1;

            return isHitVertical && isHitHorizontal;
        }

        private static void PrintOutput(string spell, int playerPoints, double heiganPoints, int playerRow, int playerColumn)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:F2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {spell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerColumn}");
        }
    }
}