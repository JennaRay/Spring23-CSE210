using System;

class EternalGoal : Goal
{   
    
    public EternalGoal(string name, string desc, string points) : base(name, desc, points)
    {

    }

    public override string GetStringRepresentation()
    {
        string goal = "eternal" + ":" + _name + ":" + _description + ":" + _points;
        return goal;
    }
}