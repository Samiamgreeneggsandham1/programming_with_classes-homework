using System;

public class Inventory : Items
{
    private int _maxQuantity;
    private int _currentQuantity;

    public Inventory(string name, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits, int maxQuantity) : base(name, monetaryValue, defensiveValue, offensiveValue, specialTraits)
    {
        _maxQuantity = maxQuantity;
        _currentQuantity = 0;
    }

    public void SetMaxQuantity(int maxQuantity)
    {
        _maxQuantity = maxQuantity;
    }

    public int GetMaxQuantity()
    {
        return _maxQuantity;
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
        if (_currentQuantity + quantity <= _maxQuantity)
        {
            _currentQuantity += quantity;
            return true;
        }
        return false;
    }

    public bool RemoveItem(int quantity)
    {
        if (_currentQuantity >= quantity)
        {
            _currentQuantity -= quantity;
            return true;
        }
        return false;
    }
}