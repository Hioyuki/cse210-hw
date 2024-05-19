using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _questions;

    public ReflectingActivity() : base("Reflecting Activity", "Reflect on your strengths and achievements.")
    {
        _questions = new List<string>
        {
            "What did you accomplish today that you are proud of?",
            "What was a significant challenge you overcame?"
        };
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }

    public override void Run()
    {
        DisplayStartingMessage();
        ShowCountDown(3);
        DisplayQuestions();
        ShowSpinner(_duration);
        DisplayEndingMessage();
    }
}