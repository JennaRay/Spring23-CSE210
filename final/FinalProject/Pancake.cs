using System;

class Pancake
{
    private string _levelCooked;
    private Topping _topping;
    private string _shape;

    public Pancake(string shape = "circle")
    {
        
    }

    public void Cook()
    {
        Console.WriteLine("Click enter when your pancake is done cooking");
        string start = DateTime.Now.ToShortTimeString();
        Console.ReadLine();
        string end = DateTime.Now.ToShortTimeString();
        int cook_time = int.Parse(end) - int.Parse(start);
            if (cook_time <= 5)
            {
                _levelCooked = "raw";
            }
            else if (cook_time < 15)
            {
                _levelCooked = "undercooked";
            }
            else if (cook_time < 26)
            {
                _levelCooked = "cooked";
            }
            else if (cook_time < 50)
            {
                _levelCooked = "overcooked";
            }
            else if (cook_time < 100)
            {
                _levelCooked = "burnt";
            }
            else
            {
                _levelCooked = "on fire! Get an extinguisher stat!";
            }
            Console.WriteLine($"Your pancake is {_levelCooked}");

        
    }

    public void Top(string top)
    {
        _topping = Top;
        Console.WriteLine("Yum, good choice!");
    }
}