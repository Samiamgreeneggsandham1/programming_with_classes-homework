using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Press ENTER to Start");
        Console.ReadLine();

        // Initialize player and shop
        Player player = new Player(100m);  // Player starts with 100 gold

        Shop healthPotion = new Shop("Health Potion", 20m, 20, 0, "Heals 20 health points", 10);
        List<Shop> shopItems = new List<Shop>
        {
            healthPotion,
            new Shop("Sword (Weak)", 30m, 0, 10, "A basic sword", 5),
            new Shop("Sword (Strong)", 75m, 0, 25, "A powerful sword", 2)
        };
        
        Story story = new Story(player);

        story.ContinueStory();
    }
}
