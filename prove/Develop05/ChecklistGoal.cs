using System;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, string points, int target, int bonus) : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public ChecklistGoal(string name, string desc, string points, int target, int bonus, int numCompleted) : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = numCompleted;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("You have already met your target for this goal");
            return 0;
        }
        else
        {
            _amountCompleted += 1;
            int points = int.Parse(_points);
            if (IsComplete())
            {
                Console.WriteLine($"Congrats! You met your target for this goal!");
                points += _bonus;
            }
            Console.WriteLine($"Good job, you've now completed this goal {_amountCompleted}/{_target} times.");
            return points;
        }

    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
    {
        string details = $"[{_amountCompleted}/{_target}] " + _name + ": " + _description;
        return details;
    }

    public override string GetStringRepresentation()
    {
        string goal = "checklist" + ":" + _description + ":" + _points + ":" + _bonus + ":" + _target + ":" + _amountCompleted;
        return goal;
    }
}