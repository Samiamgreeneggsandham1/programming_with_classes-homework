using System;

public class Shop : Items
{
    public int _stockQuantity;
    
    public Shop(string itemName, decimal monetaryValue, int defensiveValue, int offensiveValue, string specialTraits, int stockQuantity)
        : base(itemName, monetaryValue, defensiveValue, offensiveValue, specialTraits)
    {
        _stockQuantity = stockQuantity;
    }

    public bool SellItem(Player player, int quantity)
    {
        decimal totalCost = GetMonetaryValue() * quantity;

        if (_stockQuantity >= quantity && player.GetGold() >= totalCost)
        {
            _stockQuantity -= quantity;
            player.RemoveGold(totalCost);
            return true;
        }
        return false;
    }

    public int GetStockQuantity() { return _stockQuantity; }
}
