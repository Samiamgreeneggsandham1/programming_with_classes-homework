using System;
using System.Collections.Generic;

public class Items
{
    public string _itemName;
    public decimal _monetaryValue;
    public int _defensiveValue;
    public int _offensiveValue;
    public string _specialTraits;

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
        _monetaryValue = monetaryValue;
    }

    public decimal GetMonetaryValue()
    {
        return _monetaryValue;
    }

    public void SetDefensiveValue(int defensiveValue)
    {
        _defensiveValue = defensiveValue;
    }

    public int GetDefensiveValue()
    {
        return _defensiveValue;
    }

    public void SetOffensiveValue(int offensiveValue)
    {
        _offensiveValue = offensiveValue;
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

    public Items(string itemName, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits)
    {
        _itemName = itemName;
        _monetaryValue = monetaryValue;
        _defensiveValue = defensiveValue;
        _offensiveValue = offensiveValue;
        _specialTraits = specialTraits;
    }
}