using System;

public class ChecklistGoals : Goals
{
    private int _bonusPoints;
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoals(string goalName = "", string goalDescription = "", int pointsPerEvent = 0, int bonusPoints = 0, int targetCount = 0, int currentCount = 0)
        : base(goalName, goalDescription, pointsPerEvent, "checklist")
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"Progress made on '{GoalName}': {_currentCount}/{_targetCount} events completed.");
            
            if (_currentCount >= _targetCount)
            {
                Console.WriteLine($"Congratulations! You completed the goal '{GoalName}' and earned {_bonusPoints} bonus points!");
                return _bonusPoints;
            }

            return Points;
        }

        Console.WriteLine("This goal is already complete!");
        return 0;
    }

    public override string ToCsvString()
    {
        return $"{GoalName},{GoalDescription},{Points},{_bonusPoints},{_targetCount},{_currentCount},{nameof(ChecklistGoals)}";
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
        return _currentCount >= _targetCount;
    }

    public override void DisplayGoal()
    {
        string status = isComplete() ? "Completed" : $"In Progress ({_currentCount}/{_targetCount})";
        Console.WriteLine($"Checklist Goal: {GoalName} - {GoalDescription}\n    Status: {status}\n    Points per event: {Points}\n    Bonus Completion Points:{_bonusPoints}\n");
    }
}
