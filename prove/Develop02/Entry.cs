using System;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
    public string AdditionalInfo { get; set; }

    public Entry(DateTime date, string prompt, string response, string additionalInfo)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
        AdditionalInfo = additionalInfo;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine($"Additional Info: {AdditionalInfo}");
        Console.WriteLine();
    }
}