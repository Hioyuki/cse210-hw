using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;



//Improve the process of saving and loading to save as a .csv file that could be opened in Excel (make sure to account for quotation marks and commas correctly in your content.

class Program
{
    static void Main(string[] args)
    {

        Journal journal = new Journal();
        PromptManager promptManager = new PromptManager();
        bool running =true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choice");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");

            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();
            if(int.TryParse(input,out int number))
            {
                switch(number)
                {
                    case 1:
                        Console.WriteLine("Enter prompt:");
                        string prompt = Console.ReadLine();
                        Console.WriteLine("Enter response:");
                        string response = Console.ReadLine();
                        Console.WriteLine("Enter additional info:");
                        string additionalInfo = Console.ReadLine();
                        journal.AddEntry(prompt, response, additionalInfo);
                        break;
                        
                    case 2:
                        journal.Display();
                        break;

                    case 3:
                        Console.Write("Enter filename to load ");
                        string loadFileName = Console.ReadLine();
                        journal.LoadFromFile(loadFileName);
                        break;

                    case 4:
                        Console.Write("Enter filename to save: ");
                        string saveFileName = Console.ReadLine();
                        journal.SaveToFile(saveFileName);
                        break;

                    case 5:
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}