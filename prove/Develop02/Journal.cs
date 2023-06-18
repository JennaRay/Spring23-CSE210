using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries;
    public string _fileName;
    public bool _isLoaded;

    public Journal()
    {
        _entries = new List<Entry>{};
        _isLoaded = false;
    }
    public Journal(string file)
    {
        _fileName = file;
        _entries = new List<Entry>{};
        _isLoaded = false;
    }

    public void Load()
    {   if (!File.Exists(_fileName))
        {   
            Console.WriteLine("File does not exist. New file created.");
            using (FileStream fs = File.Create(_fileName)){}
            Load();
        }
        else 
        {
            using (StreamReader file = new StreamReader(_fileName))
            {
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                foreach (string line in lines)
                {
                    string[] parts = line.Split("~~~");
                    string date = parts[0];
                    string prompt = parts[1];
                    string content = parts[2];
                    
                    Entry entry = new Entry(date, prompt, content);
                    _entries.Add(entry);
                }
            }
            _isLoaded = true;        
        }
        
    }

    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter(_fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~~~{entry._prompt}~~~{entry._text}");
            }
        }
    }

    public void NewEntry()
    {
        Entry entry = new Entry();
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry._date);
            Console.WriteLine(entry._prompt);
            Console.WriteLine(entry._text);
            Console.WriteLine();
        }
    }

}