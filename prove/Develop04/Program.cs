using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        ShowSpinner(10); // アニメーションを選択画面の前に表示
        MainMenu menu = new MainMenu();
        menu.Display();
    }

    public static void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string>
        {
            "|",
            "/",
            "-",
            "\\",
            "|",
            "/",
            "-",
            "\\"
        };

        int animationIndex = 0;
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[animationIndex]);
            Thread.Sleep(250); // アニメーションの速度を調整
            Console.Write("\b \b"); // 消去するためのバックスペースとスペース
            animationIndex = (animationIndex + 1) % animationStrings.Count;
        }
        Console.WriteLine();
    }
}



public class MainMenu
{
    public void Display()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start reflecting activity");
            Console.WriteLine("3. Start listing activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Program.ShowSpinner(5); // アニメーションを表示
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    Program.ShowSpinner(5); // アニメーションを表示
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    Program.ShowSpinner(5); // アニメーションを表示
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}