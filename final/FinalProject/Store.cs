using System;

class Store
{
    private List<Topping> _toppings;
    private ShoppingCart _cart;

    public Store()
    {
        _toppings = new List<Topping>()
        {   
        //toppings
        new Topping("STR", "Strawberries", 2.00, 4),
        new Topping("CHS", "Chocolate Sauce", 1.00, 3),
        new Topping("BTR", "Butter", 0.25, 1),
        new Topping("MPL", "Maple Syrup", 0.25, 1),
        new Topping("PBTR", "Peanut Butter", 0.50, 2),
        new Topping("SPR", "Sprinkles", 0.50, 2),
        new Topping("WPC", "Whipped Cream", 0.50, 2),
        new Topping("BTM", "Buttermilk Syrup", 1.00, 3)
        //tools
        // new Tool("TMR", "Timer", 10.00, 50),
        // new Tool("CSP", "Cooking Spray", 5.00, 20),
        // //Ingredients
        // new Ingredient("EG6", "Egg Carton (small)", 1.50, 6),
        // new Ingredient("EG12", "Egg Carton (regular)", 3.00, 12),
        // new Ingredient("MLK", "Milk", 3.00, 10),
        // new Ingredient("FLR", "Flour", 5.00, 50),
        // new Ingredient("SLT", "Salt", 1.00, 1000)
        };

        _cart = new ShoppingCart();
    }

    public int DisplayMenu()
    {
        List<string> menu = new List<string>()
        {
            "Add item to cart",
            "Remove item from cart",
            "View cart",
            "Checkout"
        };

        int counter = 1;
        foreach (string opt in menu)
        {
            Console.WriteLine($"    {counter}. {opt}");
            counter += 1;
        }
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }

    public void DisplayToppings()
    {  
        Console.WriteLine("Todays Offers:");
        foreach (Topping item in _toppings)
        {
            item.StoreDisplay();
        }
    }

    public void AddItem()
    {
        Console.Write("Enter the 3-4 digit code for the item you'd like to add to your cart: ");
        string code = Console.ReadLine();
        Console.Write("How many would you like to add?");
        int quantity = int.Parse(Console.ReadLine());
        foreach (var item in _toppings)
        {
            if (item.GetCode() == code)
            {
                _cart.AddItem(item, quantity);
                return;
            }
        }
        Console.WriteLine("Silly goose! We aren't selling that item here!");
    }

    public void RemoveItem()
    {
        Console.Write("Enter the 3-4 digit code for the item you'd like to remove from your cart: ");
        string code = Console.ReadLine();
        Console.Write("How many would you like to remove?");
        int quantity = int.Parse(Console.ReadLine());
        _cart.RemoveItem(code, quantity);
    }

    public double Checkout(double money)
    {
        _cart.CalculateTotal();
        if (_cart.GetTotal() > money)
            {
                Console.WriteLine("Oops! You don't have enough money.");
                return 0;
            }
        else
        {
            Console.WriteLine("Thank you for shopping at PancakeMart!");
            return _cart.GetTotal();
        }
    }

    public void GoShopping(PancakeManager game, User user)
    {
        Console.WriteLine("Welcome to Pancake Mart! The Mart for all your Pancakes!");
        Console.WriteLine();
        Console.WriteLine("/--  --  --  --  --  --  --  --  --  --  --  --  --  --'\'");
        Console.WriteLine("|--  --  --  --  --  -[PancakeMart]  --  --  --  --  --|");
        Console.WriteLine("|                                                      |");
        DisplayToppings();
        bool shopping = true;
        while (shopping)
        {
            int choice = DisplayMenu();
            switch (choice)
            {
                case 1:
                    AddItem();
                    break;
                case 2:
                    RemoveItem();
                    break;
                case 3:
                    _cart.DisplayCart(user.GetMoney());
                    break;
                case 4:
                    _cart.DisplayCart(user.GetMoney());
                    double charge = Checkout(user.GetMoney());
                    user.ChangeMoney(-(charge));

                    foreach (var item in _cart._contents)
                    {
                        if (item.Key is Topping)
                        {
                            game.AddtoToppings(item.Key, item.Value);
                        }
                        // else if (item.Key is Tool)
                        // {
                        //     game.AddTool(item.Key);
                        // }
                        // else if (item.Key is Ingredient)
                        // {
                        //     game.AddtoIngredients(item.Key, item.Value);
                        // }
                    }

                    shopping = false;
                    break;
            }
        }
    }
}

class ShoppingCart
{
    public Dictionary<Topping, int> _contents;
    private double _total;

    public ShoppingCart()
    {
        _total = 0.00;
        _contents = new Dictionary<Topping, int>();
    }

    public double GetTotal()
    {
        return _total;
    }

    public void DisplayCart(double money)
    {   
        Console.WriteLine($"Cart:                     Total spendings: ${money}");
        foreach (var product in _contents)
        {
            double price = product.Key.GetPrice() * product.Value;
            Console.WriteLine($"    ${price} {product.Key.GetName()} : {product.Value}");
        }
        CalculateTotal();
        Console.WriteLine($"Total: ${_total}");
    }

    public void AddItem(Topping item, int quantity)
    {
        foreach (var thing in _contents)
        {
            if (thing.Key.GetCode() == item.GetCode())
            {
                _contents[thing.Key] += quantity;
                Console.WriteLine("Successfully added to cart");
                return;
            }
        }
        _contents.Add(item, quantity);
        Console.WriteLine("Successfully added to cart");
    }

    public void RemoveItem(string code, int quantity)
    {
        foreach (var thing in _contents)
        {
            if (thing.Key.GetCode() == code)
            {
                _contents[thing.Key] -= quantity;
                if (_contents[thing.Key] <= 0)
                {
                    _contents.Remove(thing.Key);
                }
            }
        }
    }
    
    public void CalculateTotal()
    {   
        _total = 0;
        foreach (var product in _contents)
        {
            double price = product.Key.GetPrice() * product.Value;
            _total += price;
        }
    }
}