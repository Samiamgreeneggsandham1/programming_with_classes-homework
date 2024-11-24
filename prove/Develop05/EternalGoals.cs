using System;

public class EternalGoals : Goals
{
    public EternalGoals(string goalName = "", string goalDescription = "", int pointsPerEvent = 0)
        : base(goalName, goalDescription, pointsPerEvent, "eternal")
    {
    }

    public override int RecordEvent()
    {
        Console.WriteLine($"You earned {GetPoints()} points!"); // Use GetPoints() instead of _pointsPerEvent
        return GetPoints(); // Return GetPoints() from the base class
    }

    public override string ToCsvString()
    {
        return $"{GetGoalName()},{GetGoalDescription()},{GetPoints()},{nameof(EternalGoals)}"; // Use GetPoints()
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
        Console.WriteLine($"Eternal Goal: {GetGoalName()} - {GetGoalDescription()}\n    Points per event: {GetPoints()}\n"); // Use GetPoints()
    }
}
