using System;

class Program
{
    static bool _playing = true;
    static void Main(string[] args)
    {
        while (_playing)
        {SelectFromMenu();}
        

    }

    private static int DisplayMenu()
    {   
        List<string> menu = new List<string>()
        {
            "Breath", 
            "Reflect", 
            "List",
            "Sense",
            "Quit"
        };
        Console.WriteLine("What would you like to do?");
        Console.WriteLine();
        int listing = 1;
        foreach (string item in menu)
        {
            Console.WriteLine($"{listing}. {item}");
            listing += 1;
        }
        return int.Parse(Console.ReadLine());
    }
    
    private static void SelectFromMenu()
    {
        int choice = DisplayMenu();
        switch(choice)
        {
            case 1:
                BreathingActivity breath1 = new BreathingActivity("Let's breathe together", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");
                breath1.Run();
                break;
            case 2:
                ReflectionActivity reflect1 = new ReflectionActivity("Lets reflect together", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
                reflect1.Run();
                break;
            case 3:
                ListingActivity list1 = new ListingActivity("Lets list together", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
                list1.Run();
                break;
            
            case 4:
                SensesActivity sense1 = new SensesActivity("Let's be present together", $"This activity will help you to be grounded in the present moment by having you tune into your senses.");
                sense1.Run();
                break;
            
            case 5:
                _playing = false;
                Console.WriteLine("Namaste");
                break;
            default:
                Console.WriteLine("That wasn't a valid option");
                break;
        }
        
    }
}