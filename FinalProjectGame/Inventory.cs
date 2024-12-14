using System;

public class Inventory : Items
{
    private int _currentQuantity;

    public Inventory(string name, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits, int initialQuantity = 0) : base(name, monetaryValue, defensiveValue, offensiveValue, specialTraits)
    {
        _currentQuantity = initialQuantity;
    }

    public void SetCurrentQuantity(int quantity)
    {
        _currentQuantity = quantity;
    }

    public int GetCurrentQuantity()
    {
        return _currentQuantity;
    }

    public bool AddItem(int quantity)
    {
        _currentQuantity += quantity;
        Console.WriteLine($"Added {quantity} items. New quantity: {_currentQuantity}.");
        return true;
    }

    public bool RemoveItem(int quantity)
    {
        if (_currentQuantity >= quantity)
        {
            _currentQuantity -= quantity;
            Console.WriteLine($"Removed {quantity} items. New quantity: {_currentQuantity}.");
            return true;
        }
        else
        {
            Console.WriteLine("Not enough items to remove.");
            return false;
        }
    }

    public int GetHealingAmount()
    {
        return GetDefensiveValue();
    }

    public int GetAttackBonus()
    {
        return GetOffensiveValue();
    }

    public void RemoveHealthPotions(int quantity)
    {
        if (quantity <= GetCurrentQuantity())
        {
            SetCurrentQuantity(GetCurrentQuantity() - quantity);
        }
        else
        {
            Console.WriteLine("Not enough health potions to use.");
        }
    }
}