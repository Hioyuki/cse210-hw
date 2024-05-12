using System;
using System.Collections.Generic;
using System.Linq;
//Have the program to load scriptures from a files.
class Program
{static void Main()
{
    var scriptureText = "Trust in the LORD with all your heart and lean not on your own understanding";
    var scriptureReference = new Reference("Proverbs", 3, 5);
    var scripture = new Scripture(scriptureReference, scriptureText);

    Console.WriteLine("Scripture Memorization Helper");
    scripture.Display();

    while (!scripture.IsCompletelyHidden())
    {
        Console.WriteLine("\nPress ENTER to hide words or type 'quit' to exit.");
        var input = Console.ReadLine();
        if (input.ToLower() == "quit")
            break;

        Console.Clear();
        scripture.HideRandomWords(3);
        scripture.Display();
    }

    Console.WriteLine("\nAll words are hidden. Good job!");

    Console.WriteLine("Enter the filename of the scripture file:");
    string filename = Console.ReadLine();
    var scripturesFromFile = Scripture.LoadScripturesFromFile(filename);

    foreach (var loadedScripture in scripturesFromFile)
    {
        loadedScripture.Display();
        Console.WriteLine();
    }
}
}

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

public void HideRandomWords(int numberToHide)
{
    var random = new Random();
    var visibleWords = _words.Where(w => !w.IsHidden).ToList();
    for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)
    {
        var wordToHide = visibleWords[random.Next(visibleWords.Count)];
        wordToHide.Hide();
        visibleWords.Remove(wordToHide);
    }
}

public bool IsCompletelyHidden() => _words.All(w => w.IsHidden);


    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
    }

public static List<Scripture> LoadScripturesFromFile(string filename)
{
    var scriptures = new List<Scripture>();
    try
    {
        using (var reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length >= 2)
                {
                    var referenceParts = parts[0].Split(' ');
                    var book = referenceParts[0];
                    var chapterAndVerse = referenceParts[1].Split(':');
                    var chapter = int.Parse(chapterAndVerse[0]);
                    var verse = int.Parse(chapterAndVerse[1]);
                    var reference = new Reference(book, chapter, verse);
                    var scriptureText = parts[1];
                    scriptures.Add(new Scripture(reference, scriptureText));
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error reading file: {ex.Message}");
    }
    return scriptures;
}
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }

    public string GetDisplayText() => $"{Book} {Chapter}:{Verse}";
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
        set { _isHidden = value; }
    }

    public void Hide() => IsHidden = true;

    public string GetDisplayText() => IsHidden ? new string('_', _text.Length) : _text;
}
