using System;
using System.Collections.Generic;

public class BossBattle : Battle
{
    private Dictionary<string, (int attackPower, int health)> enemies;

    public BossBattle(Player player) : base(player)
    {
        enemies = new Dictionary<string, (int attackPower, int health)>
        {
            { "Florida Man Crackhead", (attackPower: 16, health: 150) },
            { "King Arthur", (attackPower: 18, health: 150) },
            { "Oediups", (attackPower: 18, health: 150) },
            { "A-10 Warthog", (attackPower: 20, health: 150) },
            { "Odysseus", (attackPower: 18, health: 150) },
            { "Baba Yaga", (attackPower: 18, health: 150) },
            { "Beowulf", (attackPower: 18, health: 150) },
            { "Grendel", (attackPower: 18, health: 150) },
            { "Grendel's Mother", (attackPower: 18, health: 150) },
            { "The Headless Horseman", (attackPower: 18, health: 150) },
            { "Paul Bunyan", (attackPower: 18, health: 150) },
            { "Frankenstein's Monster", (attackPower: 18, health: 150) },
            { "Merlin", (attackPower: 18, health: 150) },
            { "Krampus", (attackPower: 18, health: 150) }
        };
    }

    public override void StartBattle()
    {
        Console.WriteLine("You have entered the Boss Battle!");
        HandleBattle(enemies, 1000); // -1 indicates Boss defeat ends the game
    }
}
