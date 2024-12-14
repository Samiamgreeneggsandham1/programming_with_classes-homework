using System;
using System.Collections.Generic;

public class Items
{
    private string _itemName;
    private decimal _monetaryValue;
    private int _defensiveValue;
    private int _offensiveValue;
    private string _specialTraits;
    private int _quantity;

    public Items(string itemName, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits, int quantity = 0)
    {
        _itemName = itemName;
        _monetaryValue = Math.Max(monetaryValue, 0); // Ensure non-negative value
        _defensiveValue = Math.Max(defensiveValue, 0); // Ensure non-negative value
        _offensiveValue = Math.Max(offensiveValue, 0); // Ensure non-negative value
        _specialTraits = specialTraits;
        _quantity = quantity;
    }

    public int GetQuantity()
    {
        return _quantity;
    }

    public void SetQuantity(int quantity)
    {
        _quantity = Math.Max(quantity, 0);
    }

    public void SetName(string name)
    {
        _itemName = name;
    }

    public string GetName()
    {
        return _itemName;
    }

    public void SetMonetaryValue(decimal monetaryValue)
    {
        _monetaryValue = Math.Max(monetaryValue, 0);
    }

    public decimal GetMonetaryValue()
    {
        return _monetaryValue;
    }

    public void SetDefensiveValue(int defensiveValue)
    {
        _defensiveValue = Math.Max(defensiveValue, 0);
    }

    public int GetDefensiveValue()
    {
        return _defensiveValue;
    }

    public void SetOffensiveValue(int offensiveValue)
    {
        _offensiveValue = Math.Max(offensiveValue, 0);
    }

    public int GetOffensiveValue()
    {
        return _offensiveValue;
    }

    public void SetSpecialTraits(string specialTraits)
    {
        _specialTraits = specialTraits;
    }

    public string GetSpecialTraits()
    {
        return _specialTraits;
    }
}