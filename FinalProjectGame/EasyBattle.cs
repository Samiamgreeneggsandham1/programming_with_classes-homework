using System;
using System.Collections.Generic;

public class EasyBattle : Battle
{
    private Dictionary<string, (int attackPower, int health)> enemies;

    public EasyBattle(Player player) : base(player)
    {
        enemies = new Dictionary<string, (int attackPower, int health)>
        {
            { "The Itsy Bitsy Spider", (attackPower: 2, health: 20) },
            { "Little Bo Peep", (attackPower: 3, health: 30) },
            { "That One Old Lady That Swallowed a Fly (I don't know why)", (attackPower: 4, health: 25) },
            { "Hansel", (attackPower: 3, health: 30) },
            { "Gretel", (attackPower: 3, health: 30) },
            { "Goldilocks", (attackPower: 3, health: 30) },
            { "The Ugly Duckling", (attackPower: 2, health: 25) },
            { "The Gingerbread Man", (attackPower: 2, health: 10) }
        };
    }

    public override void StartBattle()
    {
        Console.WriteLine("You have entered an Easy Battle!");
        HandleBattle(enemies, 10);
    }
}