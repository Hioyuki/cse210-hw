using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;

    public ListingActivity() : base("Listing Activity", "List positive things in your life.")
    {
        _prompts = new List<string> { "What made you happy today?", "What are you grateful for?" };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        string input;
        do
        {
            input = Console.ReadLine();
            responses.Add(input);
        } while (!string.IsNullOrEmpty(input));

        _count = responses.Count;
        return responses;
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine(GetRandomPrompt());
        ShowCountDown(3);
        Console.WriteLine("Start listing:");
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items.");
        DisplayEndingMessage();
    }
}