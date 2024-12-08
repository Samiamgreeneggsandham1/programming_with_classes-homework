using System;

public class Player
{
    private decimal _gold;

    public Player(decimal initialGold)
    {
        _gold = initialGold;
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
    }

    public decimal GetGold()
    {
        return _gold;
    }

    public void SetGold(decimal amount)
    {
        _gold = amount;
    }
}
