using System;

public class Assignment
{
    private string _studentName = "";

    private string _topic = "";

    public string GetStudentName()
    {
        return _studentName;
    }

    public void SetStudentName(string studentName)
    {
        _studentName = studentName;
    }

    public string GetTopic()
    {
        return _topic;
    }

    public void SetTopic(string topic)
    {
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}\n";
    }
    // Create a constructor for this class that receives a student name and topic and sets the member variables.
}