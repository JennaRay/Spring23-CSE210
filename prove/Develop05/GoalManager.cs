using System;

class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level = 0;
    private string[] _levels = {"Egg", "Hatchling", "Chick", "Fledgling", "Birb", "Silly Sparrow", "Fierce Falcon", "Bald Eagle of Power", "Owl Who Knows All", "Raven of Life and Death", "Vulture the Godkiller", "chickadee"};
    private string _FILENAME = "goals.txt";
    private List<string> _menu = new List<string>()
        {
            "Load", "Save", "View Goals", "Create Goal", "Complete Goal", "View Player Info", "Quit"
        };

    public GoalManager()
    {

    }

    public void Start()
    {
        bool playing = true;
        LoadGoals();
        while (playing)
        {
            int action = DisplayMenu();
            switch(action)
            {
                case 1:
                    LoadGoals();
                    break;
                case 2:
                    SaveGoals();
                    break;
                case 3:
                    ListGoals();
                    break;
                case 4:
                    Console.WriteLine("What kind of goal do you want to make?");
                    Console.WriteLine($"1. Simple Goal, 2. Eternal Goal, 3. Checklist Goal");
                    int answer = int.Parse(Console.ReadLine());
                    CreateGoal(answer);
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    DisplayPlayerInfo();
                    break;
                case 7:
                    SaveGoals();
                    Console.WriteLine("K bye");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Please pick a valid option");
                    break;
            }
        }
    }

    private int DisplayMenu()
    {
        int counter = 1;
        foreach (string item in _menu)
        {
            
            Console.WriteLine($"{counter}. {item}");
            counter += 1;
        }
        Console.WriteLine($"Select an option: ");
        int selection = int.Parse(Console.ReadLine());
        return selection;
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score} | Current Level: {_levels[_level]}");
    }

    private void ListGoals()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    private void ListGoalNames()
    {
        foreach (Goal goal in _goals)
        {
            Console.WriteLine(goal.GetName());
        }
    }

    private void CreateGoal(int which)
    {
        Console.Write("What would you like to title this goal? ");
        string title = Console.ReadLine();
        Console.Write("Write a description of the goal: ");
        string description = Console.ReadLine();
        Console.Write("How many points do you get for completing this goal?");
        string points = Console.ReadLine();
        if (which == 1)
        {
            _goals.Add(new SimpleGoal(title, description, points));
        }
        else if (which == 2)
        {
            _goals.Add(new EternalGoal(title, description, points));
        }
        else if (which == 3)
        {   
            Console.Write("How many time do you want to achieve this goal? ");
            int target = int.Parse(Console.ReadLine());
            Console.WriteLine("What will the bonus be for reaching your target?");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(title, description, points, target, bonus));
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("Which goal are you completing?");
        string selected = Console.ReadLine();
        foreach (Goal goal in _goals)
        {
            if (goal.GetName() == selected)
            {
                _score += goal.RecordEvent();
            }
        }
        Console.WriteLine($"Your score is now {_score}");
        int level;
        switch (_score)
        {
            case <= 0:
                level = 0;
                break;
            case >= 0 and < 10:
                level = 1;
                break;
            case >= 10 and < 25:
                level = 2;
                break;
            case >= 25 and < 50:
                level = 3;
                break;
            case >= 50 and < 100:
                level = 4;
                break;
            case >= 100 and < 200:
                level = 5;
                break;
            case >= 200 and < 500:
                level = 6;
                break;
            case >= 500 and < 800:
                level = 7;
                break;
            case >= 800 and < 1500:
                level = 8;
                break;
            case >= 1500 and < 5000:
                level = 9;
                break;
            case >= 3000 and < 10000:
                level = 10;
                break;
            case >= 10000:
                level = 11;
                break;
        }
        if (level != _level)
        {
            Console.WriteLine("    ★  ★★   ★");
            Console.WriteLine("★ Level Up! ★ ★");
            Console.WriteLine("   ★    ★   ★  ");
            Console.WriteLine($"You've reached the level of: {_levels[level]}");
        }
        _level = level;
    }

    private void SaveGoals()
    {
        using (StreamWriter outputFile = new StreamWriter(_FILENAME))
        {
            outputFile.WriteLine(_score + ":" + _level);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    private void LoadGoals()
    {
        if (!File.Exists(_FILENAME))
        {
            using (FileStream fs = File.Create(_FILENAME)){}
        }
        string[] lines = System.IO.File.ReadAllLines(_FILENAME);

         _goals = new List<Goal>();
        int counter = 0;
        foreach (string line in lines)
        {
            counter += 1;
            if (counter == 1)
            {   
                string[] parts = line.Split(":");
                _score = int.Parse(parts[0]);
                _level = int.Parse(parts[1]);
            }
            string[] parts = line.Split(":");
            switch (parts[0])
            {
                case "simple":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], parts[3], bool.Parse(parts[4])));
                    break;
                case "eternal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], parts[3]));
                    break;
                case "checklist":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], parts[3], int.Parse(parts[4]), int.Parse(parts[5])));
                    break;
            }
        }
    }
}