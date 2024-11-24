using System;

public class SimpleGoals : Goals
{
    private bool _isComplete;

    public void SetIsComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    public SimpleGoals(string goalName = "", string goalDescription = "", bool isComplete = false, int points = 0)
        : base(goalName, goalDescription, points, "simple")
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!GetIsComplete())
        {
            SetIsComplete(true);
            Console.WriteLine($"You completed the goal {GetGoalName()} and earned {GetPoints()} points!");
            return GetPoints();
        }

        Console.WriteLine("This goal is already complete!");
        return 0;
    }

    public override string ToCsvString()
    {
        return $"{GetGoalName()},{GetGoalDescription()},{GetPoints()},{GetIsComplete()},{nameof(SimpleGoals)}";
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
        return GetIsComplete();
    }

    public override void DisplayGoal()
    {
        string status = GetIsComplete() ? "Completed" : "Incomplete";
        Console.WriteLine($"Simple Goal: {GetGoalName()} - {GetGoalDescription()}\n    Status: {status}\n    Points: {GetPoints()}\n");
    }
}
