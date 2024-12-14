using System;

public class GiftRoom : Story
{
    public GiftRoom(Player player) : base(player)
    {
    }

    public void EnterGiftRoom()
    {
        Console.Clear();
        Console.WriteLine("You enter a room filled with mysterious treasures. In the center of the room, you see a glowing chest.");
        Console.WriteLine("Inside the chest, you find a magical artifact: a health potion!");

        Inventory healthPotion = new Inventory("Health Potion", 0m, 20, 0, "Restores 20 health points", 1);
        player.AddToMemory(healthPotion.GetName(), healthPotion);

        Console.WriteLine("You have received a Health Potion!");
        Console.WriteLine("\nPress any key to move on...");
        Console.ReadKey();

        // Progress to next room
        ShowStoryMenu();
    }
}
