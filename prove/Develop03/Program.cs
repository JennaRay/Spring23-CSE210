using System;

class Program
{   private static List<Scripture> _scriptures = new List<Scripture>{};
    private static Scripture _scripture;
    static void Main(string[] args)
    {   
        StartUp();

        bool playing = true;
        while (playing)
        {   
            string input = Console.ReadLine();
            if (input == "quit" | _scripture.CheckHidden())
            {
                playing = false;
                Console.Clear();
                Console.WriteLine("Thanks for playing!");
            }
            else
            {
                Console.Clear();
                _scripture.Hide();
                _scripture.Display();
            }
        }

    }

    private static void CreateScriptures()
    {
        string[] lines = File.ReadAllLines("scriptures.txt");
        foreach (string line in lines)
        {   
            if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split("- ");

                    string reference = parts[0];
                    string text = parts[1];

                    string[] moreParts = reference.Split(":");
                    int numVerses = 1;
                    int start = moreParts[1][0];
                    if (moreParts[1].Contains("-"))
                    {
                        string[] verses = moreParts[1].Split("-");
                        start = int.Parse(verses[0]);
                        int end = int.Parse(verses[1]);
                        numVerses = end + 1 - start;
                    }
                    
                    Scripture scripture = new Scripture(reference, text, numVerses, start);
                    _scriptures.Add(scripture);
                }
        }       
    }

    private static Scripture PickScripture()
    {
        Random rnd = new Random();
        int num = rnd.Next(_scriptures.Count());
        Scripture scripture = _scriptures[num];
        return scripture;
    }

    private static bool Menu()
    {
        Console.WriteLine("Welcome to the scripture memorizer!");
        Console.WriteLine("Select one of the options to begin:");
        Console.WriteLine();
        Console.WriteLine("1. Input your own scripture");
        Console.WriteLine("2. Use a random scripture");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static void StartUp()
    {   
        if (Menu())
        {
            Console.WriteLine("What is the scripture reference? ");
            string reference = Console.ReadLine();
            Console.WriteLine("Enter the text of the scripture. If there are multiple verses, separate them with a ';' ");
            string text = Console.ReadLine();
            Console.WriteLine("How many verses are there?");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("And what is the number of the starting verse? ");
            int start = int.Parse(Console.ReadLine());
            _scripture = new Scripture(reference, text, num, start);
        }
        else
        {
            CreateScriptures();
            _scripture = PickScripture();
        }
        _scripture.Display();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Hit enter to hide words, or type 'quit' to end program");
    }

}