using System;
using System.Collections.Generic;

public abstract class Goals
{
    public string GoalName { get; set; }
    public string GoalDescription { get; set; }
    public int Points { get; set; }
    public string GoalType { get; set; }

    public abstract int RecordEvent();
    public abstract string ToCsvString();
    public abstract void DisplayGoal();
    public abstract bool isComplete();

    public Goals(string goalName = "", string goalDescription = "", int points = 0, string goalType = "")
    {
        GoalName = goalName;
        GoalDescription = goalDescription;
        Points = points;
        GoalType = goalType;
    }

    public void SetGoal()
    {
        Console.Write("Enter the name of your goal: ");
        GoalName = Console.ReadLine();

        Console.Write("Enter a short description of your goal: ");
        GoalDescription = Console.ReadLine();

        Console.Write("Enter the type of your goal (Simple, Eternal, Checklist): ");
        GoalType = Console.ReadLine().ToLower();

        // Declare the points variable inside the if-else blocks to avoid scope issues
        int points;
        
        if (GoalType == "simple")
        {
            Console.Write("Enter the points this goal is worth upon completion: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            Points = points;
        }
        else if (GoalType == "eternal")
        {
            Console.Write("Enter the points this goal is worth per event: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            Points = points;
        }
        else if (GoalType == "checklist")
        {
            Console.Write("Enter the points this goal is worth per event: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            Points = points;

            // Additional logic for checklist goals
            int bonusPoints;
            Console.Write("Enter the bonus points for completing the checklist goal: ");
            while (!int.TryParse(Console.ReadLine(), out bonusPoints) || bonusPoints <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for bonus points.");
            }
        }
    }

    public static void DisplayAllGoals(List<Goals> goals)
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
        else
        {
            Console.WriteLine("Your Goals:");
            foreach (var goal in goals)
            {
                goal.DisplayGoal();
            }
            Console.WriteLine("\nPress Enter to return to the Menu.");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
