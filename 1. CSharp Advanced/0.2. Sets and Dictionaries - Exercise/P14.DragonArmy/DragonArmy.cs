namespace P14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main()
        {
            var dragonsNumber = int.Parse(Console.ReadLine());

            var dragonsData = new Dictionary<string, SortedDictionary<string, int[]>>();

            for (var i = 0; i < dragonsNumber; i++)
            {
                var dragonTokens = Console.ReadLine().Split();

                var type = dragonTokens[0];

                if (dragonsData.ContainsKey(type) == false)
                {
                    dragonsData[type] = new SortedDictionary<string, int[]>();
                }

                var damage = dragonTokens[2] != "null"
                    ? int.Parse(dragonTokens[2])
                    : 45;

                var health = dragonTokens[3] != "null"
                    ? int.Parse(dragonTokens[3])
                    : 250;

                var armor = dragonTokens[4] != "null"
                    ? int.Parse(dragonTokens[4])
                    : 10;

                var name = dragonTokens[1];

                dragonsData[type][name] = new[] { damage, health, armor };
            }

            foreach (var kvp in dragonsData)
            {
                var type = kvp.Key;

                var averageDamage = kvp.Value.Values.Average(arr => arr[0]);
                var averageHealth = kvp.Value.Values.Average(arr => arr[1]);
                var averageArmor = kvp.Value.Values.Average(arr => arr[2]);

                Console.WriteLine(
                    $"{type}::({averageDamage:F2}/{averageHealth:F2}/{averageArmor:F2})");

                foreach (var pair in dragonsData[type])
                {
                    var name = pair.Key;

                    var damage = pair.Value[0];
                    var health = pair.Value[1];
                    var armor = pair.Value[2];

                    Console.WriteLine(
                        $"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}