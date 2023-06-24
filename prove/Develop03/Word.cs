using System;
class Word
{
    private string _text;
    private bool _isHidden;
    
    public Word(string text)
    {
        _text = text;
    }

    public void Display()
    {
        char[] punct = {'.', ',', ':', ';', '"', '-', '!', '?', '(', ')'};
        if (_isHidden)
        {
            foreach (char x in _text)
            {
                if (!punct.Contains(x))
                {
                    Console.Write('_');
                }
            }
            Console.Write(" ");
        }
        else {Console.Write(_text + " ");}
    }

    public void SetIsHidden()
    {
        _isHidden = true;
    }

    public bool GetIsHidden()
    {
        return _isHidden;
    }
}