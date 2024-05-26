using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTrackingApp
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            // Initialize the program, load goals, etc.
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"You have {_score} points.");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("The goals are:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
            Console.WriteLine($"You have {_score} points.");
        }

        public void CreateGoal()
        {
            Console.WriteLine("Select a choice from the menu:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            int choice = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the name of your goal?");
            string name = Console.ReadLine();
            Console.WriteLine("What is a short description of it?");
            string description = Console.ReadLine();
            Console.WriteLine("What is the amount of points associated with this goal?");
            int points = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                _goals.Add(new SimpleGoal(name, description, points));
            }
            else if (choice == 2)
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (choice == 3)
            {
                Console.WriteLine("How many times does this goal need to be accomplished for a bonus?");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("What is the bonus for accomplishing it that many times?");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            }
        }

        public void RecordEvent()
        {
            ListGoalNames();
            Console.WriteLine("Select the goal number to record an event for:");
            int goalNumber = int.Parse(Console.ReadLine());

            // インデックスが範囲内にあるかを確認する
            if (goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal selectedGoal = _goals[goalNumber - 1];
                selectedGoal.RecordEvent();
                _score += selectedGoal.Points;
                if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
                {
                    _score += checklistGoal.Bonus;
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number. Please try again.");
            }
        }

        public void SaveGoals()
        {
            using (StreamWriter outputFile = new StreamWriter("goals.txt"))
            {
                foreach (var goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
        }

        public void LoadGoals()
        {
            Console.WriteLine("What is the filename for the goal file?");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                _goals.Clear();
                foreach (string line in lines)
                {
                    string[] parts = line.Split(":");
                    string type = parts[0];
                    string[] details = parts[1].Split(",");
                    if (type == "SimpleGoal")
                    {
                        SimpleGoal goal = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                        bool isComplete = bool.Parse(details[3]);
                        goal.GetType().GetField("_isComplete", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(goal, isComplete);
                        _goals.Add(goal);
                    }
                    else if (type == "EternalGoal")
                    {
                        EternalGoal goal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                        _goals.Add(goal);
                    }
                    else if (type == "ChecklistGoal")
                    {
                        ChecklistGoal goal = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]));
                        goal.AmountCompleted = int.Parse(details[5]);
                        _goals.Add(goal);
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found. Please try again.");
            }
        }
    }
}