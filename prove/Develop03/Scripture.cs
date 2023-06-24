using System;

class Scripture
{
    private List<Verse> _verses = new List<Verse>{};
    private string _reference;

    
    public Scripture(string reference, string text, int num, int start)
    {
        if (num > 1)
        {  
            string[] verses = text.Split(";");
    
            foreach (string verse in verses)
            {   
                Verse newVerse = new Verse(start, verse);
                _verses.Add(newVerse);
                start += 1;
            }
        }
        else if (num == 1)
        {
            _verses.Add(new Verse(start, text));
        }
        _reference = reference;
    }

    public void Hide()
    {
        foreach (Verse verse in _verses)
        {
            verse.Hide();
        }

    }

    public void Display()
    {   Console.WriteLine($"{_reference}:");
        foreach (Verse verse in _verses)
        {
            verse.Display();
        }
    }

    public bool CheckHidden()
    {
        foreach(Verse verse in _verses)
        {
            if (!(verse.CheckHidden()))
            {
                return false;
            }
            
        }
        return true;
    }

}