using System;
using System.Collections.Generic;

public abstract class Goals
{
    private string _goalName;
    private string _goalDescription;
    private int _points;
    private string _goalType;

    public void SetGoalName(string goalName)
    {
        _goalName = goalName;
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public void SetGoalDescription(string goalDescription)
    {
        _goalDescription = goalDescription;
    }

    public string GetGoalDescription()
    {
        return _goalDescription;
    }

    public void SetPoints(int points)
    {
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public void SetGoalType(string goalType)
    {
        _goalType = goalType;
    }

    public string GetGoalType()
    {
        return _goalType;
    }

    public abstract int RecordEvent();
    public abstract string ToCsvString();
    public abstract void DisplayGoal();
    public abstract bool isComplete();

    public Goals(string goalName = "", string goalDescription = "", int points = 0, string goalType = "")
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _points = points;
        _goalType = goalType;
    }

    public void SetGoal()
    {
        Console.Write("Enter the name of your goal: ");
        SetGoalName(Console.ReadLine());

        Console.Write("Enter a short description of your goal: ");
        SetGoalDescription(Console.ReadLine());

        Console.Write("Enter the type of your goal (Simple, Eternal, Checklist): ");
        SetGoalType(Console.ReadLine().ToLower());

        // Declare the points variable inside the if-else blocks to avoid scope issues
        int points;
        
        if (GetGoalType() == "simple")
        {
            Console.Write("Enter the points this goal is worth upon completion: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            SetPoints(points);
        }
        else if (GetGoalType() == "eternal")
        {
            Console.Write("Enter the points this goal is worth per event: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            SetPoints(points);
        }
        else if (GetGoalType() == "checklist")
        {
            Console.Write("Enter the points this goal is worth per event: ");
            while (!int.TryParse(Console.ReadLine(), out points) || points <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number for points.");
            }
            SetPoints(points);

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
