using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number =randomGenerator.Next(1,100);
        
        int response=0;

        while (response != number)
        {
            Console.WriteLine("What is your guess? ");
            // response = Console.ReadLine();

            response =int.Parse(Console.ReadLine());
            if (number > response)
            {
                Console.WriteLine("Higher");
            }
            else if (number < response)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }

}
