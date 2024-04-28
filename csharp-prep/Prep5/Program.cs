using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string userName = PromptUsername();
        int userNumber = PromptUserNumber();
        int area = SquareNumber(userNumber);
        DisplayResult(area, userName);
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUsername()
    {
        Console.WriteLine("Please enter your name:");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter your favorite number:");
        string input = Console.ReadLine();
        int userNumber = int.Parse(input);
        return userNumber;
    }

    static int SquareNumber(int userNumber)
    {
        return userNumber * userNumber;
    }

    static void DisplayResult(int area, string userName)
    {
        Console.WriteLine($"{userName}, the square of your number is {area}.");
    }
}
