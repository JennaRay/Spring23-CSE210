using System;

class PancakeManager
{
    private Stack<Pancake> _pancakes;
    private Dictionary<Topping, int> _toppings;
    private Dictionary<Item, int> _ingredients;
    private int _batter;

    public PancakeManager()
    {
        _pancakes = new Stack<Pancake>();
        _toppings = new Dictionary<Topping, int>()
        {
            {new Topping("BTR", "Butter", 0.25, 1), 4},
            {new Topping("MPL", "Maple Syrup", 0.25, 1), 4}
        };
        _ingredients = new Dictionary<Item, int>();
        _batter = 0;
    }

    public PancakeManager(Stack<Pancake> pancakes, Dictionary<Topping, int> toppings, int batter)
    {
        _pancakes = pancakes;
        _toppings = toppings;
        _batter = batter;
    }

    public void MakeBatter()
    {
        Console.WriteLine("How much batter would you like to make? \n 1. Single Serving (two pancakes)\n 2. Half batch (six pancakes)\n 3. Full batch (12 pancakes)\n 4. Double batch (24 pancakes) ");
        int batch = int.Parse(Console.ReadLine());
        switch (batch)
        {
            case 1:
                _batter += 2;
                break;
            case 2:
                _batter += 6;
                break;
            case 3:
                _batter += 12;
                break;
            case 4:
                _batter += 24;
                break;
        }
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
                foreach (var item in _toppings)
                {
                    Console.WriteLine(item.Key.GetName());
                }
                Console.Write("Enter the topping you'd like to use: ");
                string name = Console.ReadLine();
                foreach (var item in _toppings)
                {
                    if (item.Key.GetName() == name)
                    {
                        pancake.Top(item.Key);
                        _toppings[item.Key] -= 1;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Okay!");
            }
            _pancakes.Push(pancake);
            AddBatter(-1);
            Console.WriteLine("Pancake added to your stack!");
        }
    }

    public int Eat()
    {     
        if (_pancakes.Count > 0)
        {
            Pancake pancake = _pancakes.Pop();
            Console.WriteLine("*nom nom nom*");
            Console.WriteLine($"You now have {_pancakes.Count} pancake(s) left in your stack!");
            return pancake.GetPoints();
        }
        else
        {
            Console.WriteLine("You don't have any pancakes to eat");
            return 0;
        }
    }

    public void CheckIngredients()
    {
        Console.WriteLine("You have: ");
        foreach (var item in _toppings)
        {
            Console.WriteLine($"{item.Value} {item.Key.GetName()}");
        }
        foreach (var item in _ingredients)
        {
            Console.WriteLine($"{item.Value} {item.Key}");
        }
    }

    public void AddtoToppings(Topping item, int quantity)
    {
        _toppings.Add(item, quantity);
    }

    public void AddTool(Item item)
    {

    }
    
    public void AddtoIngredients(Item item, int quantity)
    {
        _ingredients.Add(item, quantity);
    }
}