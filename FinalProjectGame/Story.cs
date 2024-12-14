using System;
using System.Collections.Generic;

public class Story
{
    protected Player player;
    private bool hasStarted;
    protected static List<Shop> shopItems = new List<Shop>
    {
        new Shop("Health Potion", 20m, 20, 0, "Heals 20 health points", 100),
        new Shop("Sword (Weak)", 30m, 0, 2, "A basic sword", 1),
        new Shop("Sword (Strong)", 75m, 0, 5, "A powerful sword", 1)
    };

    Dictionary<string, Inventory> playerInventory = new Dictionary<string, Inventory>();

    public Story(Player player)
    {
        this.player = player;
        this.hasStarted = false;
    }

    public void ContinueStory()
    {
        Console.Clear();

        if (!hasStarted)
        {
            Console.WriteLine("You are a cowboy, wandering through the Arizona desert.");
            Console.WriteLine("Suddenly, you are surrounded by a blinding blue light.");
            Console.WriteLine("The light engulfs you, and the next thing you know, you wake up in a sterile, brightly lit room.");
            Console.WriteLine("Confused, you begin to search the room.");

            // Simulate finding items
            Console.WriteLine("\nAfter searching the room, you find:");
            Console.WriteLine("- Your favorite revolver");
            Console.WriteLine("- A suit of shiny silver armor");
            Console.WriteLine("- 100 gold coins");

            hasStarted = true;
        
            Inventory revolver = new Inventory("Revolver", 0m, 0, 5, "A trusty revolver", 1);
            Inventory silverArmor = new Inventory("Silver Armor", 0m, 20, 0, "Armor made of shining silver", 1);
            player.AddToMemory(revolver.GetName(), revolver);
            player.AddToMemory(silverArmor.GetName(), silverArmor);
            player.AddGold(100m);

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        EnterNextRoom();
    }

    protected virtual void EnterNextRoom()
    {
        Random random = new Random();
        int roomChoice = random.Next(1, 101);

        Battle battle;

        if (roomChoice <= 25)
        {
            GiftRoom giftRoom = new GiftRoom(player);
            giftRoom.EnterGiftRoom();
        }
        else if (roomChoice <= 60)
        {
            battle = new EasyBattle(player);
            battle.StartBattle();
        }
        else if (roomChoice <= 80)
        {
            battle = new MediumBattle(player);
            battle.StartBattle();
        }
        else if (roomChoice <= 93)
        {
            battle = new DifficultBattle(player);
            battle.StartBattle();
        }
        else
        {
            battle = new BossBattle(player);
            battle.StartBattle();
        }

        ShowStoryMenu();
    }

    protected void ShowStoryMenu()
    {
        bool menuActive = true;
        while (menuActive)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Continue Story");
            Console.WriteLine("2. Access Inventory");
            Console.WriteLine("3. Equip Item");
            Console.WriteLine("4. Shop");
            Console.WriteLine("5. Quit");

            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    EnterNextRoom();
                    break;

                case "2":
                    Console.Clear();
                    ViewInventory(player);
                    Console.WriteLine("\nPress any key to return to the main menu.");
                    Console.ReadKey();
                    break;

                case "3":
                    EquipItemFromInventory();  // Added this option
                    break;

                case "4":
                    Shop.ShopMenu(player, shopItems, player.GetInventory());
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }


    protected void EquipItemFromInventory()
    {
        Console.Clear();
        Console.WriteLine("Select an item to equip:");

        int index = 1;
        foreach (var inventoryItem in player.GetInventory())
        {
            Console.WriteLine($"{index}. {inventoryItem.Key} (Offensive: {inventoryItem.Value.GetOffensiveValue()}, Defensive: {inventoryItem.Value.GetDefensiveValue()})");
            index++;
        }

        Console.WriteLine("\nEnter the number of the item to equip, or 0 to return.");
        string choice = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(choice, out int itemChoice) && itemChoice > 0 && itemChoice <= player.GetInventory().Count)
        {
            var selectedItem = player.GetInventory().ElementAt(itemChoice - 1).Value;

            // Equip item as a weapon or armor based on its values
            if (selectedItem.GetOffensiveValue() > 0)
            {
                player.EquipWeapon(selectedItem);
                Console.WriteLine($"Equipped {selectedItem.GetName()} as a weapon.");
            }
            else if (selectedItem.GetDefensiveValue() > 0)
            {
                player.EquipArmor(selectedItem);
                Console.WriteLine($"Equipped {selectedItem.GetName()} as armor.");
            }
            else
            {
                Console.WriteLine($"{selectedItem.GetName()} cannot be equipped as a weapon or armor.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Console.WriteLine("\nPress any key to return to the menu.");
        Console.ReadKey();
    }

    public void ViewInventory(Player player)
    {
        Console.WriteLine("Inventory:");
        Console.WriteLine($"Gold: {player.GetGold()}");

        if (player.GetInventory().Count == 0)
        {
            Console.WriteLine("Your inventory is empty.");
        }
        else
        {
            foreach (var item in player.GetInventory())
            {
                Console.WriteLine($"{item.Key} - Quantity: {item.Value.GetCurrentQuantity()}");
                Console.WriteLine($"    Defensive Value: {item.Value.GetDefensiveValue()}, Offensive Value: {item.Value.GetOffensiveValue()}");
                Console.WriteLine($"    Description: {item.Value.GetSpecialTraits()}");
            }
        }

        Console.WriteLine("\nEquipped Weapons:");
        foreach (var weapon in player.GetEquippedWeapons())
        {
            Console.WriteLine($"{weapon.GetName()} (Attack Bonus: {weapon.GetAttackBonus()})");
        }

        Console.WriteLine("\nEquipped Armor:");
        foreach (var armor in player.GetEquippedArmor())
        {
            Console.WriteLine($"{armor.GetName()} (Defensive Value: {armor.GetDefensiveValue()})");
        }
    }
}
