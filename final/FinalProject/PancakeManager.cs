using System;

class PancakeManager
{
    Stack<Pancake> _pancakes;
    Dictionary<string, int> _toppings;
    int _batter;

    public PancakeManager()
    {
        _pancakes = new Stack<Pancake>();
        _toppings = new Dictionary<string, int>();
        _batter = 0;
    }

    public PancakeManager(Stack<Pancake> pancakes, Dictionary<string, int> toppings, int batter)
    {
        _pancakes = pancakes;
        _toppings = toppings;
        _batter = batter;
    }

    public void MakeBatter()
    {
        
    }

    private void AddBatter(int num)
    {
        _batter += num;
    }

    public int GetBatter()
    {
        return _batter;
    }

    public void MakePancakes()
    {
        if (_batter == 0)
        {
            Console.WriteLine("Oops, looks like you're out of batter!");
        }
        else
        {
            Pancake pancake = new Pancake();
            pancake.Cook();
            Console.WriteLine("Do you want toppings on this pancake?");
            string top = Console.ReadLine();
            if (top == "yes")
            {
                
            }
            else
            {
                Console.WriteLine("Okay!");
            }
            _pancakes.Add(pancake);
            AddBatter(-1);
            Console.WriteLine("Pancake added to your stack!");
        }
    }

    public void Eat()
    {
        if (_pancakes.Count != 0)
        {
            _pancakes.Pop();
            Console.WriteLine("*nom nom nom*");
            Console.WriteLine($"You now have {_pancakes.Count} pancake(s) left in your stack!");
        }
        else
        {
            Console.WriteLine("You do not have any pancakes to eat");
        }
    }

    public void CheckIngredients()
    {
        Console.WriteLine("You have: ");
        foreach (var item in _toppings)
        {
            Console.WriteLine($"{item.Value} {item.Key}");
        }
    }
}