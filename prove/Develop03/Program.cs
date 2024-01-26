using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // You can add more scriptures to the library
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("John 3:16", "For God so loved the world..."),
            new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart..."),
            // Add more scriptures here
        };

        Random random = new Random();

        foreach (var scripture in scriptures)
        {
            do
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    return;

                // Hide a few random words
                int wordsToHide = random.Next(1, 4); // You can adjust the range
                scripture.HideWords(wordsToHide);
            }
            while (!scripture.AllWordsHidden);
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = new Reference(reference);
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine(reference.ToString());
        foreach (var word in words)
        {
            Console.Write(word.IsHidden ? "***** " : word.Text + " ");
        }
    }

    public void HideWords(int count)
    {
        Random random = new Random();
        var wordsToHide = words.Where(word => !word.IsHidden).OrderBy(_ => random.Next()).Take(count);
        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    public bool AllWordsHidden => words.All(word => word.IsHidden);
}

class Reference
{
    private string reference;

    public Reference(string reference)
    {
        this.reference = reference;
    }

    public override string ToString() => reference;
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
