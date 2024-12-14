using System;
using System.Collections.Generic;

public class DifficultBattle : Battle
{
    private Dictionary<string, (int attackPower, int health)> enemies;

    public DifficultBattle(Player player) : base(player)
    {
        enemies = new Dictionary<string, (int attackPower, int health)>
        {
            { "Crackhead", (attackPower: 6, health: 40) },
            { "Polonius", (attackPower: 6, health: 40) },
            { "Gorlock the Notorious", (attackPower: 7, health: 40) },
            { "Florida Man", (attackPower: 7, health: 50) },
            { "Crayon Eater", (attackPower: 6, health: 50) },
            { "Big Bad Wolf", (attackPower: 7, health: 45) },
            { "Santa Claus", (attackPower: 6, health: 50) },
            { "Jack Frost", (attackPower: 7, health: 40) },
            { "Babe the Blue Ox", (attackPower: 6, health: 40) },
            { "Mr. Hyde", (attackPower: 7, health: 55) },
            { "The Muffin Man", (attackPower: 5, health: 40) },
            { "Sir Gawain", (attackPower: 6, health: 55) },
            { "Sir Geraint", (attackPower: 6, health: 55) },
            { "Sir Percival", (attackPower: 6, health: 55) },
            { "Sir Bors", (attackPower: 6, health: 55) },
            { "Sir Lamorak", (attackPower: 6, health: 55) },
            { "Sir Kay", (attackPower: 6, health: 55) },
            { "Sir Gareth", (attackPower: 6, health: 55) },
            { "Sir Bedivere", (attackPower: 6, health: 55) },
            { "Sir Gaheris", (attackPower: 6, health: 55) },
            { "Sir Galahad", (attackPower: 6, health: 55) },
            { "Sir Tristan", (attackPower: 6, health: 55) },
            { "Sir Palamedes", (attackPower: 6, health: 55) },
            { "Sir Lancelot", (attackPower: 6, health: 55) },
            { "The Three Bears", (attackPower: 8, health: 55) }
        };
    }

    public override void StartBattle()
    {
        Console.WriteLine("You have entered a Difficult Battle!");
        HandleBattle(enemies, 50);
    }
}