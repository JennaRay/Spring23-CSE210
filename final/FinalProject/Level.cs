using System;

class Level
{
    protected int _griddleSize;
    protected string _title;

    public Level()
    {
        _griddleSize = 1;
        _title = "Frying Pan";

    }
}

class Level1 : Level
{
    public Level1()
    {
        _griddleSize = 1;
        _title = "Rookie";
    }

}

class Level2 : Level
{
    public Level2()
    {
        _griddleSize = 2;
        _title = "Amateur";
    }
}

class Level3 : Level
{
    public Level3()
    {
        _griddleSize = 4;
        _title = "Master";
    }
}

class Fire : Level
{
    public Fire()
    {
        
    }
}