namespace P12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        public static void Main()
        {
            var keyMaterials = new SortedDictionary<string, int>
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };

            var junkMaterials = new SortedDictionary<string, int>();

            while (true)
            {
                var inputTokens = Console.ReadLine().ToLower().Split();

                for (var index = 1; index < inputTokens.Length; index += 2)
                {
                    var material = inputTokens[index];
                    var quantity = int.Parse(inputTokens[index - 1]);

                    if (material == "shards" || material == "fragments" || material == "motes")
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            keyMaterials[material] -= 250;

                            switch (material)
                            {
                                case "shards":
                                    Console.WriteLine("Shadowmourne obtained!");
                                    break;

                                case "fragments":
                                    Console.WriteLine("Valanyr obtained!");
                                    break;

                                case "motes":
                                    Console.WriteLine("Dragonwrath obtained!");
                                    break;
                            }

                            foreach (var pair in keyMaterials.OrderByDescending(kvp => kvp.Value))
                            {
                                var keyMaterialType = pair.Key;
                                var keyMaterialQuantity = pair.Value;

                                Console.WriteLine($"{keyMaterialType}: {keyMaterialQuantity}");
                            }

                            foreach (var junkPair in junkMaterials)
                            {
                                var junkType = junkPair.Key;
                                var junkQuantity = junkPair.Value;

                                Console.WriteLine($"{junkType}: {junkQuantity}");
                            }

                            return;
                        }
                    }
                    else
                    {
                        if (junkMaterials.ContainsKey(material) == false)
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;
                    }
                }
            }
        }
    }
}