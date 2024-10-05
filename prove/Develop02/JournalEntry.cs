using System;
using System.Net;

public class JournalEntry
{
    public string Date {get; set;}
    public string Prompt {get; set;}
    public string Response {get; set;}

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date} - {Prompt}\n{Response}\n";
    }
}
