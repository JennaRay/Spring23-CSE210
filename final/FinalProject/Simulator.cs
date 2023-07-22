using System;

class Simulator
{
    List<string> _menu = new List<string>()
    {
    "View Instructions", 
    "Make Batter", 
    "Make Pancake", 
    "Eat Pancake", 
    "View Inventory", 
    "Go to Store",
    "Quit"
    };

    private int DisplayMenu()
    {
        int counter = 1;
        foreach (string item in _menu)
        {
            Console.WriteLine($"{counter}. {item}");
            counter += 1;
        }
        Console.Write("What would you like to do?");
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }

    public void Play()
    {
        Console.WriteLine();
        Console.WriteLine("Enter the number for the menu item you want to select.");
        PancakeManager game = new PancakeManager();
        Store store = new Store();
        User user = new User();
        bool playing = true;
        while (playing)
        {
            int choice = DisplayMenu();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("instructions");
                    break;
                case 2:
                    game.MakeBatter();
                    break;
                case 3:
                    game.MakePancakes();
                    break;
                case 4:
                    user.AddPoints(game.Eat());
                    break;
                case 5:
                    game.CheckIngredients();
                    break;
                case 6:
                    store.GoShopping(game, user);
                    break;
                case 7:
                    Console.WriteLine("Thanks for playing!");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Oops that wasn't an option!");
                    break;
            }
            Console.WriteLine();
        }
    }
}