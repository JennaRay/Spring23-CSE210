using System;

class Verse
{
    private int _number;
    private List<Word> _words = new List<Word>{};
    // private bool _isHidden = false;

    public Verse(int verseNumber, string text)
    {
        _number = verseNumber;
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }

    }

    public void Hide()
    {
        foreach (Word word in _words)
        {   
            Random rnd = new Random();
            int hide = rnd.Next(2);
            if (hide == 1)
            {
                word.SetIsHidden();
            }
        }
        
    }

    public void Display()
    {
        Console.WriteLine("    ");
        Console.Write($"{_number}. ");
        foreach (Word word in _words)
        {
            word.Display();
        }
    }

    public bool CheckHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.GetIsHidden())
            {
                return false;
            }
        }
        return true;

    }

}