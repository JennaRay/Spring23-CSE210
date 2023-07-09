using System;

class Goal
{
    protected string _name;
    protected string _description;
    protected string _points;

    public Goal(string name, string desc, string points)
    {
        _name = name;
        _description = desc;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public virtual int RecordEvent()
    {
        Console.WriteLine("Keep up the good work!");
        return int.Parse(_points);
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {   
        string mark = " ";
        if (this.IsComplete())
        {
            mark = "X";
        }
        string details = $"[{mark}] " + _name + ": " + _description;
        return details;
    }

    public virtual string GetStringRepresentation()
    {
        return "";
    }
}