using System;

public class SimpleGoals : Goals
{
    private bool _isComplete;

    public SimpleGoals(string goalName = "", string goalDescription = "", bool isComplete = false, int points = 0)
        : base(goalName, goalDescription, points, "simple")
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"You completed the goal {GoalName} and earned {Points} points!");
            return Points;
        }

        Console.WriteLine("This goal is already complete!");
        return 0;
    }

    public override string ToCsvString()
    {
        return $"{GoalName},{GoalDescription},{Points},{_isComplete},{nameof(SimpleGoals)}";
    }

    public static SimpleGoals FromCsvString(string csvLine)
    {
        var parts = csvLine.Split(',');

        if (parts.Length == 5 && int.TryParse(parts[2], out int points) && bool.TryParse(parts[3], out bool isComplete))
        {
            return new SimpleGoals(parts[0], parts[1], isComplete, points);
        }

        return null;
    }

    public override bool isComplete()
    {
        return _isComplete;
    }

    public override void DisplayGoal()
    {
        string status = _isComplete ? "Completed" : "Incomplete";
        Console.WriteLine($"Simple Goal: {GoalName} - {GoalDescription}\n    Status: {status}\n    Points: {Points}\n");
    }
}
