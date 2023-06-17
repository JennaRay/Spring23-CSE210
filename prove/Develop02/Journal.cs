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
        }
        else 
        {
            using (StreamReader file = new StreamReader(_fileName))
            {
                string[] lines = System.IO.File.ReadAllLines(_fileName);
                List<string> entries = new List<string>();
                int count = 0;
                string date = "";
                string prompt = "";
                string content = "";
                foreach (string line in lines)
                {
                    // string[] parts = line.Split("~~~");
                    if (count + 1 == 4)
                    {
                        count = 1;
                    }
                    else
                    {
                        count += 1;
                    }
                    switch (count)
                    {
                        case 1:
                            date = line;
                            break;
                        case 2:
                            prompt = line;
                            break;
                        case 3:
                            content = line;
                            Entry entry = new Entry(date, prompt, content);
                            _entries.Add(entry);
                            break;
                    }
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
                outputFile.WriteLine($"{entry._date}");
                outputFile.WriteLine($"{entry._prompt}");
                outputFile.WriteLine($"{entry._text}");
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