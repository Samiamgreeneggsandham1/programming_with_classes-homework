using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static int PlayerScore = 0;

    static void Main(string[] args)
    {
        Console.WriteLine($"Welcome to the Gamified Goals Program!");

        List<Goals> goals = new List<Goals>();

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.Clear();

            Console.WriteLine("Menu:\n    1. Set Goal\n    2. View Goals\n    3. Save Goals\n    4. Load Goals\n    5. Record Event\n    6. View Player Stats\n    7. Quit\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("The types of Goals are:\n    1. Simple Goal\n    2. Eternal Goal\n    3. Checklist Goal\nWhat type of goal would you like to set? ");
                    string goalChoice = Console.ReadLine();
                    Goals newGoal = null;

                    if (goalChoice == "1")
                    {
                        newGoal = new SimpleGoals();
                    }
                    else if (goalChoice == "2")
                    {
                        newGoal = new EternalGoals();
                    }
                    else if (goalChoice == "3")
                    {
                        newGoal = new ChecklistGoals();
                    }

                    if (newGoal != null)
                    {
                        newGoal.SetGoal();
                        goals.Add(newGoal);
                    }
                    break;

                case "2":
                    Console.Clear();
                    Goals.DisplayAllGoals(goals);
                    break;

                case "3":
                    SaveGoalsToFile(goals);
                    break;

                case "4":
                    LoadGoalsFromFile(ref goals);
                    break;

                case "5":
                    Console.WriteLine("Select a goal to record an event for:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].GoalName} ({goals[i].GoalDescription})");
                    }
                
                    Console.Write("Enter the number of the goal to record an event: ");
                    string selectedGoalIndex = Console.ReadLine();

                    if (int.TryParse(selectedGoalIndex, out int goalIndex) && goalIndex > 0 && goalIndex <= goals.Count)
                    {
                        Goals goalToRecord = goals[goalIndex - 1];
                        int pointsEarned = goalToRecord.RecordEvent();
                        PlayerScore += pointsEarned;
                        Console.WriteLine($"You earned {pointsEarned} points! Total Score: {PlayerScore}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please choose a valid goal number.");
                    }
                    Console.WriteLine("Press Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "6":
                    DisplayPlayerStats(goals, PlayerScore);
                    break;

                case "7":
                    Console.WriteLine("Exiting Program, thanks for playing!");
                    exitProgram = true;
                    break;

                default:
                    Console.WriteLine("Please enter a valid choice.");
                    continue;
            }
        }
    }

    private static void SaveGoalsToFile(List<Goals> goals)
    {
        string filePath = "goals.txt";
        List<string> goalLines = new List<string>();

        foreach (var goal in goals)
        {
            goalLines.Add(goal.ToCsvString());
        }

        File.WriteAllLines(filePath, goalLines);
        Console.WriteLine("Goals have been saved.");
    }

    private static void LoadGoalsFromFile(ref List<Goals> goals)
    {
        string filePath = "goals.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');

                if (parts.Length > 0)
                {
                    string goalType = parts.Last(); // Goal type is stored last in the CSV string.

                    Goals newGoal = goalType switch
                    {
                        nameof(SimpleGoals) => SimpleGoals.FromCsvString(line),
                        nameof(EternalGoals) => EternalGoals.FromCsvString(line),
                        nameof(ChecklistGoals) => ChecklistGoals.FromCsvString(line),
                        _ => null
                    };

                    if (newGoal != null)
                    {
                        goals.Add(newGoal);
                    }
                }
            }

            Console.WriteLine("Goals have been loaded.");
        }
        else
        {
            Console.WriteLine("No saved goals file found.");
        }
    }

    private static void DisplayPlayerStats(List<Goals> goals, int playerScore)
    {
        int completedGoals = goals.Count(g => g.isComplete());
        int totalGoals = goals.Count;
        int inProgressGoals = totalGoals - completedGoals;

        Console.Clear();
        Console.WriteLine("Player Stats:");
        Console.WriteLine($"- Total Score: {playerScore}");
        Console.WriteLine($"- Total Goals: {totalGoals}");
        Console.WriteLine($"- Completed Goals: {completedGoals}");
        Console.WriteLine($"- Goals In Progress: {inProgressGoals}");

        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
    }
}
