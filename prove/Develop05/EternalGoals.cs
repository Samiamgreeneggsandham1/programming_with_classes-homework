using System;

public class EternalGoals : Goals
{
    public EternalGoals(string goalName = "", string goalDescription = "", int pointsPerEvent = 0)
        : base(goalName, goalDescription, pointsPerEvent, "eternal")
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You earned {Points} points!"); // Use Points instead of _pointsPerEvent
        return Points; // Return Points from the base class
    }

    public override string ToCsvString()
    {
        return $"{GoalName},{GoalDescription},{Points},{nameof(EternalGoals)}"; // Use Points
    }

    public static EternalGoals FromCsvString(string csvLine)
    {
        var parts = csvLine.Split(',');

        if (parts.Length == 4 && int.TryParse(parts[2], out int pointsPerEvent))
        {
            return new EternalGoals(parts[0], parts[1], pointsPerEvent);
        }

        return null;
    }

    public override bool isComplete()
    {
        return false; // Eternal goals don't have a completion status
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Eternal Goal: {GoalName} - {GoalDescription}\n    Points per event: {Points}\n"); // Use Points
    }
}
