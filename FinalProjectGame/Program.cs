using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool exitProgram = false;

        // Initialize player, shop, and inventory
        Player player = new Player(100m);  // Player starts with 100 gold
        Inventory leatherArmor = new Inventory("Leather Armor", 50m, 10, 0, "Light armor, increases mobility", 5);
        Inventory steelArmor = new Inventory("Steel Armor", 100m, 25, 0, "Heavy armor, high defense", 3);
        Shop healthPotion = new Shop("Health Potion", 20m, 0, 0, "Heals 50 health points", 10);
        
        // Shop items
        List<Shop> shopItems = new List<Shop>
        {
            healthPotion,
            new Shop("Sword (Weak)", 30m, 0, 10, "A basic sword", 5),
            new Shop("Sword (Strong)", 75m, 0, 25, "A powerful sword", 2)
        };

        while (!exitProgram)
        {
            Console.Clear();

            Console.WriteLine("Menu:\n    1. Continue Story\n    2. Inventory\n    3. Shop\n    4. Load Previous Game\n    5. Save Game\n    6. Quit");
            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Continuing story...");
                    break;

                case "2":
                    ViewInventory(player, leatherArmor, steelArmor); // View the player's inventory
                    break;

                case "3":
                    ShopMenu(player, shopItems); // Go to the shop menu
                    break;

                case "4":
                    Console.WriteLine("Loading previous game...");
                    break;

                case "5":
                    Console.WriteLine("Saving game...");
                    break;

                case "6":
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Invalid Choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    // Display the player's inventory
    static void ViewInventory(Player player, Inventory leatherArmor, Inventory steelArmor)
    {
        Console.Clear();
        Console.WriteLine("Your Inventory:");
        Console.WriteLine($"Leather Armor: {leatherArmor.GetCurrentQuantity()}");
        Console.WriteLine($"Steel Armor: {steelArmor.GetCurrentQuantity()}");
        Console.WriteLine($"Gold: {player.GetGold()}");
        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();
    }

    // Shop menu where player can buy items
    static void ShopMenu(Player player, List<Shop> shopItems)
    {
        bool inShop = true;

        while (inShop)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Shop! Your Gold: " + player.GetGold());
            Console.WriteLine("Available Items:");

            // Display items in the shop
            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {shopItems[i].GetName()} - {shopItems[i].GetMonetaryValue()} gold");
            }

            Console.WriteLine("\nEnter the number of the item to purchase or 0 to exit.");
            string? choice = Console.ReadLine();
            int itemChoice = int.TryParse(choice, out itemChoice) ? itemChoice : 0;

            if (itemChoice == 0)
            {
                inShop = false;
                continue;
            }

            // Check if the chosen item is valid
            if (itemChoice > 0 && itemChoice <= shopItems.Count)
            {
                Shop selectedItem = shopItems[itemChoice - 1];
                Console.WriteLine($"You selected {selectedItem.GetName()} for {selectedItem.GetMonetaryValue()} gold.");

                Console.WriteLine("How many would you like to buy?");
                string? quantityChoice = Console.ReadLine();
                int quantity = int.TryParse(quantityChoice, out quantity) ? quantity : 0;

                // Try purchasing the item
                if (quantity > 0 && selectedItem.SellItem(player, quantity))
                {
                    Console.WriteLine($"You bought {quantity} {selectedItem.GetName()}.");
                }
                else
                {
                    Console.WriteLine("Not enough gold or stock available.");
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
