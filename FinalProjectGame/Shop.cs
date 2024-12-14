using System;

public class Shop : Items
{
    public int _stockQuantity;
    
    public Shop(string itemName, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits, int stockQuantity)
        : base(itemName, monetaryValue, defensiveValue, offensiveValue, specialTraits)
    {
        _stockQuantity = stockQuantity;
    }

    public bool SellItem(Player player, int quantity)
    {
        decimal totalCost = GetMonetaryValue() * quantity;

        if (_stockQuantity >= quantity && player.GetGold() >= totalCost)
        {
            _stockQuantity -= quantity;
            player.RemoveGold(totalCost);
            return true;
        }
        return false;
    }

    public int GetStockQuantity() 
    {
        return _stockQuantity;
    }

    public string GetDescription()
    {
        return $"{GetName()} - {GetMonetaryValue()} gold\n" +
               $"Defensive Value: {GetDefensiveValue()}\n" +
               $"Offensive Value: {GetOffensiveValue()}\n" +
               $"Special Traits: {GetSpecialTraits()}\n" +
               $"Stock Quantity: {_stockQuantity}";
    }

    public static void ShopMenu(Player player, List<Shop> shopItems, Dictionary<string, Inventory> playerInventory)
    {
        bool inShop = true;

        while (inShop)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Shop! Your Gold: {player.GetGold()}");
            Console.WriteLine("Available Items:");

            // Display items in the shop
            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {shopItems[i].GetName()} - {shopItems[i].GetMonetaryValue()} gold ({shopItems[i].GetStockQuantity()} in stock)");
            }

            Console.WriteLine("\nEnter the number of the item to purchase or press ENTER to exit.");
            string? choice = Console.ReadLine();
            if (string.IsNullOrEmpty(choice))
            {
                inShop = false;
                continue;
            }

            if (int.TryParse(choice, out int itemChoice) && itemChoice > 0 && itemChoice <= shopItems.Count)
            {
                Shop selectedItem = shopItems[itemChoice - 1];
                Console.WriteLine($"You selected {selectedItem.GetName()} for {selectedItem.GetMonetaryValue()} gold.");

                Console.WriteLine("How many would you like to buy?");
                string? quantityChoice = Console.ReadLine();
                int quantity = int.TryParse(quantityChoice, out quantity) ? quantity : 0;

                if (quantity > 0 && selectedItem.SellItem(player, quantity))
                {
                    Console.WriteLine($"You bought {quantity} {selectedItem.GetName()}.");

                    if (playerInventory.ContainsKey(selectedItem.GetName()))
                    {
                        playerInventory[selectedItem.GetName()].AddItem(quantity);
                    }
                    else
                    {
                        // Create a new inventory item with the correct current quantity
                        Inventory newItem = new Inventory(
                            selectedItem.GetName(),
                            selectedItem.GetMonetaryValue(),
                            selectedItem.GetDefensiveValue(),
                            selectedItem.GetOffensiveValue(),
                            selectedItem.GetSpecialTraits()
                        );
                        newItem.SetCurrentQuantity(quantity); // Set the purchased quantity
                        player.AddToMemory(newItem.GetName(), newItem);
                    }
                }
                else
                {
                    Console.WriteLine("Not enough gold and/or stock available.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("\nPress any key to return to the shop menu.");
            Console.ReadKey();
        }
    }
}
