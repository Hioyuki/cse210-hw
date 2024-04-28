using System;

class Program
{
    static void Main(string[] args)
    {


        Console.Write("How is your score?");
        string score = Console.ReadLine();

        int X =int.Parse(score);
        int y =70;

        string letter="";

        if( X >= 90)
        {
            letter="A";
        }
        else if (X >= 80)
        {
            letter="B";
        }
        else if (X >= 70)
        {
            letter="C";
        }
        else if (X >= 60)
        {
            letter="D";
        }
        else
        {
            letter="F";

        }

        Console.WriteLine($"Your grade is {letter}");

        if(X > y)
        {
            Console.WriteLine("Congratulions!");
        }
        else if (X < y)
        {
            Console.WriteLine("Do your best next time!");
        }
        else
        {
            Console.WriteLine("");
        }
    }
}

// This is prep2
