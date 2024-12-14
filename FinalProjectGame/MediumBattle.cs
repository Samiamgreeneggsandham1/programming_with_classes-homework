using System;
using System.Collections.Generic;

public class MediumBattle : Battle
{
    private Dictionary<string, (int attackPower, int health)> enemies;

    public MediumBattle(Player player) : base(player)
    {
        enemies = new Dictionary<string, (int attackPower, int health)>
        {
            { "Jack & Jill", (attackPower: 4, health: 40) },
            { "The Tooth Fairy", (attackPower: 5, health: 35) },
            { "Dr. Jekyll", (attackPower: 5, health: 35) },
            { "The Easter Bunny", (attackPower: 5, health: 35) },
            { "Penelope", (attackPower: 5, health: 35) },
            { "Mama Duck", (attackPower: 3, health: 30) },
            { "3 Little Pigs", (attackPower: 5, health: 35) },
            { "Trash Panda", (attackPower: 5, health: 30) },
            { "Stinky College Roommate", (attackPower: 5, health: 35) },
            { "Ichabod Crane", (attackPower: 5, health: 35) },
            { "Pinocchio", (attackPower: 5, health: 35) },
            { "Gepetto", (attackPower: 5, health: 35) }
        };
    }

    public override void StartBattle()
    {
        Console.WriteLine("You have entered a Medium Battle!");
        HandleBattle(enemies, 20);
    }
}