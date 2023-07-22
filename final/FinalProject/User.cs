using System;

class User
{
    int _hp;
    int _points;
    double _money;
    Level _level;

    public User()
    {
        _hp = 100;
        _points = 0;
        _money = 10.00;
        _level = new Level1();
    }

    public double GetMoney()
    {
        return _money;
    }

    public void ChangeMoney(double change)
    {
        _money += change;
    }

    public void AddPoints(int change)
    {
        _points += change;
        if (_points > 20 && _points < 50 && _level is not Level2)
        {
                _level = new Level2();
                Console.WriteLine("LevelUp!");
        }
        if (_points >= 50 && _level is not Level3)
        {
            _level = new Level3();
            Console.WriteLine("LevelUp!");
        }
        

    }
}