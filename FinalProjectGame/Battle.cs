using System;
using System.Collections.Generic;

public abstract class Battle : Story
{
        public Battle(Player player) : base(player)
    {
        // this.player = player;
    }

    public abstract void StartBattle();
    
    protected void HandleBattle(Dictionary<string, (int attackPower, int health)> enemies, int reward)
    {
        Random random = new Random();
        List<string> enemyNames = new List<string>(enemies.Keys);
        string enemyName = enemyNames[random.Next(enemyNames.Count)];
        var enemyStats = enemies[enemyName];
        int enemyHealth = enemyStats.health;

        Console.Clear();
        Console.WriteLine($"An enemy appears!\n{enemyName} - {enemyHealth} HP");

        bool battleOver = false;
        while (!battleOver)
        {
            Console.WriteLine("\nYour Turn:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Flee");
            Console.WriteLine("3. Use Health Potion");
            string? choice = Console.ReadLine();

            if (choice == null)
            {
                Console.WriteLine("Invalid input. Please try again.");
                continue;
            }

            switch (choice)
            {
                case "1":
                    int playerDamage = player.GetAttackDamage();
                    enemyHealth -= playerDamage;
                    Console.WriteLine($"You dealt {playerDamage} damage to {enemyName}!");
                    Console.WriteLine($"{enemyName} now has {Math.Max(enemyHealth, 0)} HP left.");

                    if (enemyHealth <= 0)
                    {
                        Console.Clear();
                        
                        if (reward == 1000)
                        {
                            Console.WriteLine("Congratulations! You defeated a boss and earned 1000 gold!");
                            player.AddGold(1000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine($"You defeated {enemyName} and earned {reward} gold!");
                            player.AddGold(reward);

                            Console.WriteLine("\nPress ENTER to continue...");
                            Console.ReadKey();

                            battleOver = true;
                        }
                    }
                    else
                    {
                        int enemyDamage = enemyStats.attackPower;
                        player.TakeDamage(enemyDamage);
                        Console.WriteLine($"{enemyName} attacked you for {enemyDamage} damage!");
                        Console.WriteLine($"You now have {player.GetHealth()} HP.");

                        if (player.GetHealth() <= 0)
                        {
                            Console.WriteLine("You have been defeated...");
                            Console.WriteLine("GAME OVER");
                            Environment.Exit(0);
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine("You fled the battle!");

                    Console.WriteLine("\nPress ENTER to continue...");
                    Console.ReadKey();

                    battleOver = true;
                    break;

                case "3":
                    player.UseHealthPotion();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        ShowStoryMenu();
    }
}
