using System;
using System.Collections.Generic;

public class Player
{
    private decimal _gold;
    private int _health;
    private int _baseHealth = 100;
    private int _attackDamage;
    private Dictionary<string, Inventory> playerInventory = new Dictionary<string, Inventory>();
    private List<Inventory> equippedWeapons = new List<Inventory>();
    private List<Inventory> equippedArmor = new List<Inventory>();

    public Player(decimal initialGold)
    {
        _gold = initialGold;
        _health = _baseHealth;
        _attackDamage = 10;
    }

    public void AddGold(decimal amount)
    {
        _gold += amount;
    }

    public void RemoveGold(decimal amount)
    {
        if (_gold >= amount)
        {
            _gold -= amount;
        }
        else
        {
            Console.WriteLine("Not enough gold!");
        }
    }

    public decimal GetGold()
    {
        return _gold;
    }

    public void SetGold(decimal amount)
    {
        _gold = amount;
    }

    public int GetHealth()
    {
        return _health;
    }

    public void SetHealth(int amount)
    {
        _health = Math.Clamp(amount, 0, _baseHealth);
    }

    public void AddHealth(int amount)
    {
        _health = Math.Min(_health + amount, _baseHealth);
    }

    public void TakeDamage(int amount)
    {
        _health = Math.Max(_health - amount, 0);
    }

    public int GetBaseHealth()
    {
        return _baseHealth;
    }

    public void SetBaseHealth(int amount)
    {
        _baseHealth = amount;
        _health = Math.Min(_health, _baseHealth);
    }

    public int GetAttackDamage()
    {
        return _attackDamage;
    }

    public void SetAttackDamage(int amount)
    {
        _attackDamage = amount;
    }

    public void AddToMemory(string itemName, Inventory item)
    {
        if (!string.IsNullOrEmpty(itemName) && item != null)
        {
            if (playerInventory.ContainsKey(itemName))
            {
                playerInventory[itemName].AddItem(item.GetCurrentQuantity());
            }
            else
            {
                playerInventory.Add(itemName, item);
                item.SetCurrentQuantity(item.GetCurrentQuantity());
            }
        }
    }

    public Dictionary<string, Inventory> GetInventory()
    {
        return playerInventory;
    }

    public void EquipWeapon(Inventory weapon)
    {
        if (equippedWeapons.Count < 2)
        {
            equippedWeapons.Add(weapon);
            _attackDamage += weapon.GetOffensiveValue();
        }
        else
        {
            Console.WriteLine("You can only equip 2 weapons at a time.");
        }
    }

    public void EquipArmor(Inventory armor)
    {
        equippedArmor.Add(armor);
        _health += armor.GetDefensiveValue();
    }

    public void UnequipWeapon(Inventory weapon)
    {
        if (equippedWeapons.Remove(weapon))
        {
            _attackDamage -= weapon.GetAttackBonus();
        }
    }

    public void UnequipArmor(Inventory armor)
    {
        if (equippedArmor.Remove(armor))
        {
            _health -= armor.GetDefensiveValue();
        }
    }

    public List<Inventory> GetEquippedWeapons()
    {
        return equippedWeapons;
    }

    public List<Inventory> GetEquippedArmor()
    {
        return equippedArmor;
    }

    public void UseHealthPotion()
    {
        if (playerInventory.ContainsKey("Health Potion") && playerInventory["Health Potion"].GetCurrentQuantity() > 0)
        {
            Console.WriteLine("How many health potions would you like to use?");

            string input = Console.ReadLine() ?? string.Empty;

            int potionsToUse = 0;

            if (!int.TryParse(input, out potionsToUse) || potionsToUse <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                return;
            }

            int maxPotions = playerInventory["Health Potion"].GetCurrentQuantity();
            potionsToUse = Math.Min(potionsToUse, maxPotions);

            int healthRestored = potionsToUse * 20;
            AddHealth(healthRestored);

            playerInventory["Health Potion"].RemoveItem(potionsToUse);

            Console.WriteLine($"You used {potionsToUse} health potion(s) and restored {healthRestored} health!");
        }
        else
        {
            Console.WriteLine("You don't have any health potions.");
        }
    }

    public void EquipWeaponMenu()
    {
        Console.WriteLine("\nSelect a weapon to equip:");
        int index = 1;
        foreach (var item in playerInventory)
        {
            if (item.Value.GetAttackBonus() > 0) // Only display items that have an attack bonus
            {
                Console.WriteLine($"{index}: {item.Key} (Attack Bonus: {item.Value.GetAttackBonus()})");
                index++;
            }
        }

        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= playerInventory.Count)
        {
            var selectedItem = new List<Inventory>(playerInventory.Values)[selectedIndex - 1];
            EquipWeapon(selectedItem);
            Console.WriteLine($"Equipped {selectedItem.GetName()}.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void UnequipWeaponMenu()
    {
        Console.WriteLine("\nSelect a weapon to unequip:");
        int index = 1;
        foreach (var weapon in equippedWeapons)
        {
            Console.WriteLine($"{index}: {weapon.GetName()} (Attack Bonus: {weapon.GetAttackBonus()})");
            index++;
        }

        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= equippedWeapons.Count)
        {
            var selectedWeapon = equippedWeapons[selectedIndex - 1];
            UnequipWeapon(selectedWeapon);
            Console.WriteLine($"Unequipped {selectedWeapon.GetName()}.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void EquipArmorMenu()
    {
        Console.WriteLine("\nSelect armor to equip:");
        int index = 1;
        foreach (var item in playerInventory)
        {
            if (item.Value.GetDefensiveValue() > 0) // Only display items with defensive value
            {
                Console.WriteLine($"{index}: {item.Key} (Defensive Value: {item.Value.GetDefensiveValue()})");
                index++;
            }
        }

        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= playerInventory.Count)
        {
            var selectedItem = new List<Inventory>(playerInventory.Values)[selectedIndex - 1];
            EquipArmor(selectedItem);
            Console.WriteLine($"Equipped {selectedItem.GetName()}.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void UnequipArmorMenu()
    {
        Console.WriteLine("\nSelect armor to unequip:");
        int index = 1;
        foreach (var armor in equippedArmor)
        {
            Console.WriteLine($"{index}: {armor.GetName()} (Defensive Value: {armor.GetDefensiveValue()})");
            index++;
        }

        string input = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= equippedArmor.Count)
        {
            var selectedArmor = equippedArmor[selectedIndex - 1];
            UnequipArmor(selectedArmor);
            Console.WriteLine($"Unequipped {selectedArmor.GetName()}.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }
}
