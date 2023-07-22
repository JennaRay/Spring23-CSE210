using System;

class Pancake
{
    private string _levelCooked;
    private Topping _topping;
    private string _shape;

    public Pancake(string shape = "circle")
    {
        _shape = shape;

    }

    public int GetPoints()
    {
        int points = 0;
        switch (_levelCooked)
        {
            case "raw":
                points += -1;
                break;
            case "undercooked":
                points += 1;
                break;
            case "cooked":
                points += 3;
                break;
            case "overcooked":
                points += 1;
                break;
            case "burnt":
                points += -1;
                break;
        }
        if (_topping is not null)
        {
            points += _topping.GetBoost();
        }
        return points;
    }

    public void Cook()
    {
        Console.WriteLine("Click enter when your pancake is done cooking");
        int start = System.DateTime.Now.Second;
        Console.ReadLine();
        int end = System.DateTime.Now.Second;
        int cook_time = end - start;
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

    public void Top(Topping top)
    {
        _topping = top;
        Console.WriteLine("Yum, good choice!");
    }
}