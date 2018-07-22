namespace P05.GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var bagCapacity = long.Parse(Console.ReadLine());

            var safeItems = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var itemsData = new Dictionary<string, Dictionary<string, long>>
            {
                ["Gold"] = new Dictionary<string, long>(),
                ["Gem"] = new Dictionary<string, long>(),
                ["Cash"] = new Dictionary<string, long>()
            };

            var goldAmount = 0L;
            var gemAmount = 0L;
            var cashAmount = 0L;

            for (int index = 0; index < safeItems.Length; index += 2)
            {
                var itemName = safeItems[index];
                var quantity = long.Parse(safeItems[index + 1]);

                if (goldAmount + gemAmount + cashAmount + quantity > bagCapacity)
                {
                    continue;
                }

                var itemType = GetItemType(itemName);

                if (itemType == "Gold")
                {
                    goldAmount += AddQuantityToItem(itemsData, itemType, itemName, quantity);
                }
                else if (itemType == "Gem" && goldAmount >= gemAmount + quantity)
                {
                    gemAmount += AddQuantityToItem(itemsData, itemType, itemName, quantity);
                }
                else if (itemType == "Cash" && gemAmount >= cashAmount + quantity)
                {
                    cashAmount += AddQuantityToItem(itemsData, itemType, itemName, quantity);
                }
            }

            PrintOutput(itemsData);
        }

        private static string GetItemType(string itemName)
        {
            var itemType = string.Empty;

            if (itemName.ToLower() == "gold")
            {
                itemType = "Gold";
            }
            else if (itemName.Length == 3)
            {
                itemType = "Cash";
            }
            else if (itemName.ToLower().EndsWith("gem"))
            {
                itemType = "Gem";
            }

            return itemType;
        }

        private static long AddQuantityToItem(
            Dictionary<string, Dictionary<string, long>> itemsData, string itemType, string itemName, long quantity)
        {
            if (itemsData[itemType].ContainsKey(itemName) == false)
            {
                itemsData[itemType][itemName] = 0;
            }

            itemsData[itemType][itemName] += quantity;

            return quantity;
        }

        private static void PrintOutput(Dictionary<string, Dictionary<string, long>> itemsData)
        {
            var orderedItemsData = itemsData
                .Where(kvp => kvp.Value.Count > 0)
                .OrderByDescending(kvp => kvp.Value.Values.Sum())
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var itemData in orderedItemsData)
            {
                var itemType = itemData.Key;
                var totalAmount = itemData.Value.Values.Sum();

                Console.WriteLine($"<{itemType}> ${totalAmount}");

                var orderedItemsQuantity = itemData.Value
                    .OrderByDescending(kvp => kvp.Key)
                    .ThenBy(kvp => kvp.Value)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                foreach (var kvp in orderedItemsQuantity)
                {
                    var item = kvp.Key;
                    var amount = kvp.Value;

                    Console.WriteLine($"##{item} - {amount}");
                }
            }
        }
    }
}