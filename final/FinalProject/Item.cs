using System;

class Item
{
    string _code;
    string _name;
    double _price;

    public Item(string code, string name, double price)
    {
        _code = code;
        _name = name;
        _price = price;
    }

    public double GetPrice()
    {
        return _price;
    }
    public string GetName()
    {
        return _name;
    }

    public string GetCode()
    {
        return _code;
    }
    public virtual void StoreDisplay()
    {
        Console.WriteLine($"{_code}) {_name}: ${_price}");
    }
}

class Topping : Item
{
    int _boost;
    public Topping(string code, string name, double price, int boost) : base(code, name, price)
    {
        _boost = boost;
    }

    public int GetBoost()
    {
        return _boost;
    }
    public override void StoreDisplay()
    {
        base.StoreDisplay();
        Console.WriteLine($" Point Boost: {_boost}");
    }
}

class Tool : Item
{
    int _uses;
    public Tool(string code, string name, double price, int strength) : base(code, name, price)
    {
        _uses = strength;
    }
}

class Ingredient : Item
{
    int _multiple;
    public Ingredient(string code, string name, double price, int multiple) : base(code, name, price)
    {
        _multiple = multiple;
    }

    public int GetMultiple()
    {
        return _multiple;
    }

    public override void StoreDisplay()
    {
        base.StoreDisplay();
        Console.WriteLine($"  Contains ({_multiple}) uses");
    }
}