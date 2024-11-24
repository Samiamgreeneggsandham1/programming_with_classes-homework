using System;

public class ChecklistGoals : Goals
{
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;

    public void SetBonusPoints(int bonusPoints)
    {
        _bonusPoints = bonusPoints;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public void SetTargetCount(int targetCount)
    {
        _targetCount = targetCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public void SetCurrentCount(int currentCount)
    {
        _currentCount = currentCount;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public ChecklistGoals(string goalName = "", string goalDescription = "", int pointsPerEvent = 0, int bonusPoints = 0, int targetCount = 0, int currentCount = 0)
        : base(goalName, goalDescription, pointsPerEvent, "checklist")
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (GetCurrentCount() < GetTargetCount())
        {
            SetCurrentCount(GetCurrentCount() + 1);
            Console.WriteLine($"Progress made on '{GetGoalName()}': {GetCurrentCount()}/{GetTargetCount()} events completed.");
            
            if (GetCurrentCount() >= GetTargetCount())
            {
                Console.WriteLine($"Congratulations! You completed the goal '{GetGoalName()}' and earned {GetBonusPoints()} bonus points!");
                return GetBonusPoints();
            }

            return GetPoints();
        }

        Console.WriteLine("This goal is already complete!");
        return 0;
    }

    public override string ToCsvString()
    {
        return $"{GetGoalName()},{GetGoalDescription()},{GetPoints()},{GetBonusPoints()},{GetTargetCount()},{GetCurrentCount()},{nameof(ChecklistGoals)}";
    }

    public static ChecklistGoals FromCsvString(string csvLine)
    {
        var parts = csvLine.Split(',');

        if (parts.Length == 7 &&
            int.TryParse(parts[2], out int pointsPerEvent) &&
            int.TryParse(parts[3], out int bonusPoints) &&
            int.TryParse(parts[4], out int targetCount) &&
            int.TryParse(parts[5], out int currentCount))
        {
            return new ChecklistGoals(parts[0], parts[1], pointsPerEvent, bonusPoints, targetCount, currentCount);
        }

        return null;
    }

    public override bool isComplete()
    {
        return GetCurrentCount() >= GetTargetCount();
    }

    public override void DisplayGoal()
    {
        string status = isComplete() ? "Completed" : $"In Progress ({GetCurrentCount()}/{GetTargetCount()})";
        Console.WriteLine($"Checklist Goal: {GetGoalName()} - {GetGoalDescription()}\n    Status: {status}\n    Points per event: {GetPoints()}\n    Bonus Completion Points: {GetBonusPoints()}\n");
    }
}
