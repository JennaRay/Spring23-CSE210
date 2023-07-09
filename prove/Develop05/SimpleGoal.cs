using System;

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, string points) : base(name, desc, points)
    {
        _isComplete = false;
    }
    public SimpleGoal(string name, string desc, string points, bool complete) : base(name, desc, points)
    {
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations, you have completed {_name}!");
        return int.Parse(_points);
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        string goal = "simple" + ":" + _name + ":" + _description + ":" + _points + ":" + _isComplete;
        return goal;
    }
}