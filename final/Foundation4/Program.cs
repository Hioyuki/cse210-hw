using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 6, 1), 30, 5),
            new Cycling(new DateTime(2024, 6, 2), 45, 20),
            new Swimming(new DateTime(2024, 6, 3), 60, 30)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}